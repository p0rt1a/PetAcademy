using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.AuthOperations.Commands.Login;
using WebApi.Application.AuthOperations.Commands.Register;
using WebApi.DbOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAcademyDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthController(IAcademyDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterModel model)
        {
            RegisterCommand command = new(_context, _mapper);
            command.Model = model;

            RegisterCommandValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPost("login")]
        public ActionResult<Token> Login([FromBody]LoginModel model)
        {
            LoginCommand command = new(_context, _configuration);
            command.Model = model;

            LoginCommandValidator validator = new();
            validator.ValidateAndThrow(command);

            var token = command.Handle();

            return token;
        }
    }
}
