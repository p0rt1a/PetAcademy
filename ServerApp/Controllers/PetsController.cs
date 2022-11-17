using Microsoft.AspNetCore.Mvc;
using ServerApp.Data;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        AcademyContext _context;

        public PetsController(AcademyContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetPets()
        {
            var pets = _context.Pets.ToList();
            if (pets == null)
            {
                return NotFound();
            }
            return Ok(pets);
        }
    }
}
