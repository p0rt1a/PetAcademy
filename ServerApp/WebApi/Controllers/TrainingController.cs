﻿using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.TrainingOperations.Commands.CreateTraining;
using WebApi.Application.TrainingOperations.Commands.DeleteTraining;
using WebApi.Application.TrainingOperations.Commands.UpdateTraining;
using WebApi.Application.TrainingOperations.Queries.GetComments;
using WebApi.Application.TrainingOperations.Queries.GetFullTrainings;
using WebApi.Application.TrainingOperations.Queries.GetRunningOutTrainings;
using WebApi.Application.TrainingOperations.Queries.GetTrainingDetail;
using WebApi.Application.TrainingOperations.Queries.GetTrainingPets;
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
        public IActionResult GetTrainings([FromQuery]string title = default, [FromQuery]string city = default, [FromQuery]string genre = default)
        {
            GetTrainingsQuery query = new(_context, _mapper);
            query.Title = title;
            query.City = city;
            query.Genre = genre;
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("runningout")]
        public IActionResult GetRunningOutTrainings()
        {
            GetRunningOutTrainingsQuery query = new(_context, _mapper);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("full")]
        public IActionResult GetFullTrainings()
        {
            GetFullTrainingsQuery query = new(_context, _mapper);
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

        [Authorize]
        [HttpGet("{id}/pets")]
        public IActionResult GetTrainingPets(int id)
        {
            GetTrainingPetsQuery query = new(_context, _mapper);
            query.TrainingId = id;

            GetTrainingPetsQueryValidator validator = new();
            validator.ValidateAndThrow(query);

            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}/comments")]
        public IActionResult GetTrainingComments(int id)
        {
            GetCommentsQuery query = new(_context, _mapper);
            query.TrainingId = id;

            GetCommentsQueryValidator validator = new();
            validator.ValidateAndThrow(query);

            var result = query.Handle();

            return Ok(result);
        }

        [Authorize]
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

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateTraining(int id, [FromBody]UpdateTrainingModel model)
        {
            UpdateTrainingCommand command = new(_context);
            command.TrainingId = id;
            command.Model = model;

            UpdateTrainingCommandValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteTraining(int id)
        {
            DeleteTrainingCommand command = new(_context);
            command.TrainingId = id;

            DeleteTrainingCommandValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}
