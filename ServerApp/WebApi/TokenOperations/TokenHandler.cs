using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.TokenOperations.Models;

namespace WebApi.TokenOperations
{
    public class TokenHandler
    {
        public IConfiguration Configuration { get; set; }

        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Token CreateAccessToken()
        {
            Token tokenModel = new();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            tokenModel.ExpirationDate = DateTime.Now.AddHours(1);

            JwtSecurityToken token = new(
                    issuer: Configuration["Token:Issuer"],
                    audience: Configuration["Token:Audience"],
                    notBefore: DateTime.Now,
                    expires: tokenModel.ExpirationDate,
                    signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler tokenHandler = new();

            tokenModel.AccessToken = tokenHandler.WriteToken(token);
            tokenModel.RefreshToken = CreateRefreshToken();

            return tokenModel;
        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
