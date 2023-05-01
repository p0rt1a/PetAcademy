﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
            GetTrainingsQuery query = new GetTrainingsQuery(_context, _mapper);
            var result = query.Handle();

            return Ok(result);
        }
    }
}
