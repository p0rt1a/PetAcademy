using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.PetOperations.Commands.CreatePet;
using WebApi.Application.PetOperations.Commands.DeletePet;
using WebApi.Application.PetOperations.Commands.UpdatePet;
using WebApi.Application.PetOperations.Queries.PetDetail;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class PetController : ControllerBase
    {
        private readonly IAcademyDbContext _context;
        private readonly IMapper _mapper;

        public PetController(IAcademyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetPetDetail(int id)
        {
            PetDetailQuery query = new(_context, _mapper);
            query.PetId = id;

            var result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreatePet([FromBody]CreatePetModel model)
        {
            CreatePetCommand command = new(_context, _mapper);
            command.Model = model;

            CreatePetCommandValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePet(int id, [FromBody]UpdatePetModel model)
        {
            UpdatePetCommand command = new(_context, _mapper);
            command.PetId = id;
            command.Model = model;

            UpdatePetCommandValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePet(int id)
        {
            DeletePetCommand command = new(_context);
            command.PetId = id;

            DeletePetCommandValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}
