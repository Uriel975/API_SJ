using APIServices.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace APIServices.Handlers
{
    public class TokenCreatorHandler
    {
        private readonly IConfiguration _config;

        public TokenCreatorHandler(IConfiguration config) { _config = config; }
        public string TokenCreator(Usuarios user)
        {
            string secretKey = _config.GetValue<string>("JWT:SecretKey");
            byte[] key = Encoding.Unicode.GetBytes(secretKey);

            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim("Id", user.Id.ToString()));
            claims.AddClaim(new Claim(ClaimTypes.Name, user.Usuario));
            claims.AddClaim(new Claim(ClaimTypes.Email, user.Correo));
            claims.AddClaim(new Claim(ClaimTypes.Role, user.Rol));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            string bearer_token = tokenHandler.WriteToken(createdToken);
            return bearer_token;
        }
    }
}
