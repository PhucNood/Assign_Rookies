using Microsoft.AspNetCore.Mvc;
using Back_end.Services;
using Back_end.Entities;
using Back_end.Models;
using AutoMapper;
namespace Back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IService<Category> _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(IService<Category> categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("api/Categories")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryModel>))]
        public IActionResult GetCategory()
        {
            var category = _mapper.Map<List<CategoryModel>>(_categoryService.GetAll());
            if (!ModelState.IsValid) return BadRequest(category);
            return Ok(category);
        }

        [HttpGet("api/Category")]
        [ProducesResponseType(200, Type = typeof(CategoryModel))]

        public IActionResult GetCategory(int id)
        {
            if (!_categoryService.Existed(id)) return NotFound();
            var category = _mapper.Map<CategoryModel>(_categoryService.GetById(id));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(category);
        }

        [HttpPost("api/Category")]
        [ProducesResponseType(200, Type = typeof(CategoryModel))]

        public IActionResult PostCategory(CategoryModel CategoryModel)
        {
            var category = _mapper.Map<Category>(CategoryModel);

            if (CategoryModel == null) return BadRequest(ModelState);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "May be not have the category or request");
            }


            if (ModelState.IsValid)
            {

                _categoryService.Add(category);
                return Ok(category);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("api/category")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult UpdateCategory(CategoryModel categoryModel)
        {
            var category = _mapper.Map<Category>(categoryModel);

            if (categoryModel == null) return BadRequest(ModelState);
            if (_categoryService.IsIncorrectFK(category))
            {
                ModelState.AddModelError("InvalidFK", "May be Invalid some foreign key ");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "May be not have the category or request");
            }


            if (ModelState.IsValid)
            {

                _categoryService.Update(category);
                return Ok(categoryModel);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("api/Category")]
        [ProducesResponseType(200, Type = typeof(CategoryModel))]

        public IActionResult DeleteCategory(int id)
        {
            if (id == null) return BadRequest();
            if (!_categoryService.Existed(id)) return NotFound();
            var category = _categoryService.GetById(id);
            if (_categoryService.Existed(id))
            {
                _categoryService.Remove(category);
            }
             return Ok(category);
        }


    }
}