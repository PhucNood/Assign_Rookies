using System.Net;
using AutoMapper;
using EF_Assignment2.Context;
using EF_Assignment2.Entities;
using EF_Assignment2.Models;
using EF_Assignment2.Services;
using Microsoft.AspNetCore.Mvc;

namespace EF_Assignment2.Controllers;

[ApiController]
[Route("[controller]")]

public class CategoryController : ControllerBase
{
    private readonly IShopService _service;
    private readonly IMapper _mapper;

  


    public CategoryController(IShopService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
     

    }

    [HttpGet("api/Categories")]
    public List<Category> GetCategories(){
        return _mapper.Map<List<Category>>(_service.GetCategories());
    }

   
    [HttpGet("api/Category")]
    public Category GetCategorie(int id){

        return _mapper.Map<Category>(_service.GetCategory(id));
    }
[HttpPost("api/Category")]
 public HttpStatusCode CreateCategory(Category category)
    {

        if (ModelState.IsValid)
        {
           CategoryEntity ce = _mapper.Map<CategoryEntity>(category);
            _service.CreateCategory(ce);
            return HttpStatusCode.OK;
        }

        return HttpStatusCode.BadRequest;
    }
    [HttpDelete("api/category")]
    public HttpStatusCode DeleteCategory(int id){
          if(id!=null){
              _service.DeleteCategory(id);
            return HttpStatusCode.OK;
          }

        return HttpStatusCode.BadRequest;
    }

    [HttpPut("api/category")]
    public HttpStatusCode UpdateProduct(Category category){
             if(ModelState.IsValid){
                  _service.UpdateCategory(_mapper.Map<CategoryEntity>(category)); ;
                  
                 return HttpStatusCode.OK;
             }
        return HttpStatusCode.BadRequest;
    }
}
    

