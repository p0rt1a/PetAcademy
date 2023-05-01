using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.TrainingOperations.Commands.CreateTraining;
using WebApi.Application.TrainingOperations.Commands.UpdateTraining;
using WebApi.Application.TrainingOperations.Queries.GetTrainingDetail;
using WebApi.Application.TrainingOperations.Queries.GetTrainings;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class TrainingController : ControllerBase
    {
        private readonly IAcademyDbContext _context;
        private readonly IMapper _mapper;

        public TrainingController(IAcademyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTrainings()
        {
            GetTrainingsQuery query = new(_context, _mapper);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetTrainingDetail(int id)
        {
            GetTrainingDetailQuery query = new(_context, _mapper);
            query.TrainingId = id;

            GetTrainingDetailQueryValidator validator = new();
            validator.ValidateAndThrow(query);

            var result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateTraining([FromBody]CreateTrainingModel model)
        {
            CreateTrainingCommand command = new(_context, _mapper);
            command.Model = model;

            CreateTrainingCommandValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTraining(int id, [FromBody]UpdateTrainingModel model)
        {
            UpdateTrainingCommand command = new(_context);
            command.TrainingId = id;
            command.Model = model;

            command.Handle();

            return Ok();
        }
    }
}
