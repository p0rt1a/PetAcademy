using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class TrainingController : ControllerBase
    {
        private readonly IAcademyDbContext _context;

        public TrainingController(IAcademyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTrainings()
        {
            return Ok();
        }
    }
}
