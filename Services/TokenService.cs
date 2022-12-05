using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Curso.Models;
using Curso.Services.Interfaces;

namespace Curso.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config )
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token"]));
        }

        string ITokenService.CreateToken(User usuario)
        {
          var claims = new List<Claim>
          {
              new Claim(JwtRegisteredClaimNames.NameId, usuario.Email)
          };

          var credemtials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
        
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(2),
                SigningCredentials = credemtials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}