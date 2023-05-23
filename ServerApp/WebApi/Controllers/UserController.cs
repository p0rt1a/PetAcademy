using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.UserOperations.Commands.UpdateUser;
using WebApi.Application.UserOperations.Queries.GetPets;
using WebApi.Application.UserOperations.Queries.UserDetail;
using WebApi.Application.UserOperations.Queries.UserTrainings;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class UserController : ControllerBase
    {
        private readonly IAcademyDbContext _context;
        private readonly IMapper _mapper;

        public UserController(IAcademyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserDetail(int id)
        {
            UserDetailQuery query = new(_context, _mapper);
            query.UserId = id;

            UserDetailQueryValidator validator = new();
            validator.ValidateAndThrow(query);

            var result = query.Handle();

            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}/pets")]
        public IActionResult GetPets(int id)
        {
            GetPetsQuery query = new(_context, _mapper);
            query.UserId = id;

            GetPetsQueryValidator validator = new();
            validator.ValidateAndThrow(query);

            var result = query.Handle();

            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}/trainings")]
        public IActionResult GetTrainings(int id)
        {
            UserTrainingsQuery query = new(_context, _mapper);
            query.UserId = id;

            var result = query.Handle();

            return Ok(result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody]UpdateUserModel model)
        {
            UpdateUserCommand command = new(_context);
            command.UserId = id;
            command.Model = model;

            UpdateUserCommandValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}
