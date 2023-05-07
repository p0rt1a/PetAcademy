using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
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

        //TODO: Delete this method before product
        [HttpGet]
        public IActionResult GetEnrollments()
        {
            var result = _context.Enrollments.ToList();

            return Ok(result);
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
    }
}
