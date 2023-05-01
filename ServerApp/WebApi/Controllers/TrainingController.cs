using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.TrainingOperations.Queries.GetTrainingsQuery;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class TrainingController : ControllerBase
    {
        private readonly IAcademyDbContext _context;
        private readonly IMapper _mapper;

        public TrainingController(IAcademyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTrainings()
        {
            GetTrainingsQuery query = new(_context, _mapper);
            var result = query.Handle();

            return Ok(result);
        }
    }
}
