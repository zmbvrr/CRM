using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using TP_CRM.Controllers;

namespace TP_CRM
{
    public class JwtAuthenticationManager
    {
        public static CrmContext context = new();
        private readonly string key;
        private Dictionary<string, string> users = new();

        public JwtAuthenticationManager(string key)
        {
            this.key = key;
            foreach(User u in context.Users)
            {
                users.Add(u.Email, u.Password);               
            }
        }

        public string Authenticate(string email, string password)
        {
            if(!users.Any(u => u.Key == email && u.Value == password))
            {
                return null;
            }

            JwtSecurityTokenHandler tokenHandler = new();
            var tokenKey = Encoding.ASCII.GetBytes(key);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, email)
                }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}