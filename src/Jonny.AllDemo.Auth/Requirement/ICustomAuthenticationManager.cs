using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Jonny.AllDemo.Auth.Requirement
{
    public interface ICustomAuthenticationManager
    {
        string Authenticate(string username, string password);

        IDictionary<string, string> Tokens { get; }
    }
    public class CustomAuthenticationManager : ICustomAuthenticationManager
    {
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            { "admin", "admin" },
            { "jonny", "jonny" },
            { "xhl", "xhl" },
            { "james", "james" }
        };

        public IDictionary<string, string> Tokens { get; } = new Dictionary<string, string>();

        public string Authenticate(string username, string password)
        {
            var claimsIdentity = new ClaimsIdentity(new[]{
                new Claim(ClaimTypes.Name,username)
            });
            if (!users.Any(u => u.Key == username && u.Value == password))
            {
                return null;
            }
            if (username == "admin")
            {
                claimsIdentity.AddClaims(new[]
                {
                    new Claim( ClaimTypes.Email, "xhl.jonny@gmail.com"),
                    new Claim( "ManageId", "admin"),
                    new Claim(ClaimTypes.Role,"admin")
                });
            }
            var handler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.Now.AddMinutes(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretsecretsecret")), SecurityAlgorithms.HmacSha256),
            };
            var securityToken = handler.CreateToken(tokenDescriptor);
            var token = handler.WriteToken(securityToken);
            Tokens.Add(token, username);
            return token;
        }
    }
}
