using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Data;
using ServerApp.DTO;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
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
        
        //confirmed
        [HttpGet]
        public IActionResult GetAll()
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

        [HttpPost]
        public IActionResult Add(TrainingDTO entity)
        {
            _context.Trainings.Add(entity.training);
            _context.SaveChanges();

            var training = _context.Trainings.Find(entity.training.Id);

            foreach(var item in entity.categoryIndexes) {
                _context.CategoryTraining.Add(new CategoryTraining() { TrainingId = training.Id, CategoryId = item });
            };

            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("trainings-by-trainer/{id}")]
        public IActionResult GetTrainingsByTrainerId(int id)
        {
            var trainings = _context.Trainings.Where(t => t.TrainerId == id).ToList();

            if (trainings == null)
            {
                return NotFound();
            }

            return Ok(trainings);
        }

        [HttpGet("trainings-by-category/{id}")]
        public IActionResult GetTrainingsByCategoryId(int id)
        {
            var categoryTrainings = _context.CategoryTraining.Where(x => x.CategoryId == id).ToList();
            
            if (categoryTrainings == null)
            {
                return NotFound();
            }

            List<Training> trainings = new List<Training>();

            for(int i = 0; i < categoryTrainings.Count; i++)
            {
                var training = _context.Trainings.Find(categoryTrainings[i].TrainingId);
                trainings.Add(training);
            }

            return Ok(trainings);
        }

        [HttpGet("training-by-level")]
        public IActionResult GetTrainingsByLevel(string levelName)
        {
            var trainings = _context.Trainings.Where(x => x.Level == levelName).ToList();

            if (trainings == null)
            {
                return NotFound();
            }

            return Ok(trainings);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTraining(int id, Training entity)
        {
            var training = _context.Trainings.Find(id);

            if (training == null)
            {
                return NotFound();
            }

            training.Header = entity.Header;
            training.Level = entity.Level;
            training.Description = entity.Description;
            training.VideoUrl = entity.VideoUrl;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTraining(int id)
        {
            var training = _context.Trainings.Find(id);

            if (training == null)
            {
                return NotFound();
            }

            var categoryTrainings = _context.CategoryTraining.Where(x => x.TrainingId == id).ToList();

            for(int i = 0; i < categoryTrainings.Count; i++)
            {
                _context.CategoryTraining.Remove(categoryTrainings[i]);
            }

            _context.Trainings.Remove(training);
            _context.SaveChanges();

            return Ok();
        }
    }
}
