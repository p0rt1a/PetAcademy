using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment;
using WebApi.Application.EnrollmentOperations.Commands.DeleteEnrollment;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IAcademyDbContext _context;
        private readonly IMapper _mapper;

        public EnrollmentController(IAcademyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult CreateEnrollment([FromBody]CreateEnrollmentModel model)
        {
            CreateEnrollmentCommand command = new(_context, _mapper);
            command.Model = model;

            CreateEnrollmentCommandValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteEnrollment([FromBody]DeleteEnrollmentModel model)
        {
            DeleteEnrollmentCommand command = new(_context, _mapper);
            command.Model = model;

            DeleteEnrollmentCommandValidator validator = new();
            validator.ValidateAndThrow(command);

            return Ok();
        }
    }
}
