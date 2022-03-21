using Microsoft.AspNetCore.Mvc;
using Back_end.Services;
using Back_end.Entities;
using Back_end.Models;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace Back_end.Controllers
{
    [EnableCors()]
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IService<User> _userService;
        private readonly IMapper _mapper;

        public UserController(IService<User> userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
      //  [Authorize(Roles = "Admin")]
        [HttpGet("api/Users")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserModel>))]
        public IActionResult GetUsers()
        {
            var user = _mapper.Map<List<UserModel>>(_userService.GetAll());
            if (!ModelState.IsValid) return BadRequest(user);
            return Ok(user);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("api/User")]
        [ProducesResponseType(200, Type = typeof(UserModel))]

        public IActionResult GetUser(int id)
        {
            if (!_userService.Existed(id)) return NotFound();
            var user = _mapper.Map<UserModel>(_userService.GetById(id));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(user);
        }

        [HttpPost("api/User")]
        [ProducesResponseType(200, Type = typeof(UserModel))]

        public IActionResult PostUser(UserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);

            if (userModel == null) return BadRequest(ModelState);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "May be not have the user or request");
            }


            if (ModelState.IsValid)
            {

                _userService.Add(user);
                return Ok(userModel);
            }
            return BadRequest(ModelState);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("api/User")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult UpdateUser(UserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);

            if (userModel == null) return BadRequest(ModelState);
            if (_userService.IsIncorrectFK(user))
            {
                ModelState.AddModelError("InvalidFK", "May be Invalid some foreign key ");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "May be not have the user or request");
            }


            if (ModelState.IsValid)
            {

                _userService.Update(user);
                return Ok(userModel);
            }
            return BadRequest(ModelState);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("api/User")]
        [ProducesResponseType(200, Type = typeof(UserModel))]

        public IActionResult DeleteUser(int id)
        {
            if (id == null) return BadRequest();
            if (!_userService.Existed(id)) return NotFound();
            var user = _userService.GetById(id);
            if (_userService.Existed(id))
            {
                _userService.Remove(user);
            }
            return Ok(user);
        }
    }
}