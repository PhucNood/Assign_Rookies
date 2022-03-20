using Microsoft.AspNetCore.Mvc;
using Back_end.Services;
using Back_end.Entities;
using Back_end.Models;
using AutoMapper;
using Microsoft.AspNetCore.Cors;

namespace Back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizeController : ControllerBase
    {
         private readonly IAuthorizecation _authorization;
         
         public AuthorizeController(IAuthorizecation authorization)
         {
             _authorization = authorization;
         }

        [HttpPost("api/Token")]
          public IActionResult CreateToken(AccountModel acc){
              var token = _authorization.Authenticate(acc.Account,acc.Password);
              if(token == null) return Unauthorized();
                return Ok(token);
          }
    }
}