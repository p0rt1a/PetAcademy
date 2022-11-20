using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServerApp.Data;
using ServerApp.DTO;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDTO entity)
        {
            var user = new User()
            {
                Name = entity.Name,
                UserName = entity.Username,
                Email = entity.Email,
            };

            var result = await _userManager.CreateAsync(user, entity.Password);

            if (result.Succeeded)
            {
                return StatusCode(201);
            }

            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDTO entity)
        {
            var user = await _userManager.FindByNameAsync(entity.Username);

            if (user == null)
            {
                return BadRequest(new { message = "Username is incorrect"});
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, entity.Password, false);

            if (result.Succeeded)
            {
                return Ok(new { token = GenerateJwtToken(user) });
            }

            return Unauthorized();
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
