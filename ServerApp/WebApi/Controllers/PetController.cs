using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.PetOperations.Commands.CreatePet;
using WebApi.Application.PetOperations.Commands.UpdatePet;
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
        public IActionResult UpdatePet([FromBody]UpdatePetModel model)
        {
            UpdatePetCommand command = new(_context, _mapper);
            command.Model = model;

            command.Handle();

            return Ok();
        }
    }
}
