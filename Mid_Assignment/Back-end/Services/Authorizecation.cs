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
        private readonly IDictionary<string, string>  users;

       private readonly LibraryContext _context;

       public string Key { get; set; }


       public Authorizecation(LibraryContext context)
       {
           _context = context;
           users = _context.Users.ToList().ToDictionary(user => user.Account, user => user.Password);
       }


       
        public string Authenticate(string username, string password)
        {
                  if(!users.Any(user => user.Key == username && user.Value == password)) return null;

                  var tokenHandler = new JwtSecurityTokenHandler();
                  var tokenKey = Encoding.ASCII.GetBytes(Key);
                  var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Admin")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
           
    }
}