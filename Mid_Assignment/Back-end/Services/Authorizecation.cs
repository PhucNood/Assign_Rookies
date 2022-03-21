using System.Text;
using Back_end.Entities;
using Back_end.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Back_end.Services
{
    public class Authorizecation : IAuthorizecation
    {
      

       private readonly LibraryContext _context;

       


       public Authorizecation(LibraryContext context)
       {
           _context = context;
           
       }


       
        public string Authenticate(string account, string password)
        {
            var users = _context.Users.ToList();
                 if(!users.Any(user => user.Account.Equals(account) && user.Password.Equals(password))) return null;
                  bool isSuper =users.FirstOrDefault(user=>user.Account.Equals(account)).IsSuper;
                  var tokenHandler = new JwtSecurityTokenHandler();
                  var tokenKey = Encoding.ASCII.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM");
                  var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, account),
                    new Claim(ClaimTypes.Role, isSuper ?"Admin":"User")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
           
    }
}