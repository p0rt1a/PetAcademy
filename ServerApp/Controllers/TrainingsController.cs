using Microsoft.AspNetCore.Mvc;
using ServerApp.Data;
using ServerApp.DTO;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ServerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingsController : ControllerBase
    {
        private AcademyContext _context;

        public TrainingsController(AcademyContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetTrainings()
        {
            var trainings = _context.Trainings.ToList();
            if (trainings == null)
            {
                return NotFound();
            }
            return Ok(trainings);
        }

        [HttpGet("{id}")]
        public IActionResult GetTrainingById(int id)
        {
            var training = _context.Trainings.Find(id);
            if (training == null)
            {
                return NotFound();
            }
            return Ok(training);
        }

        [HttpPost("add")]
        public IActionResult AddTraining(Training newTraining)
        {
            _context.Trainings.Add(newTraining);
            _context.SaveChanges();

            return Ok();
        }
    }
}
