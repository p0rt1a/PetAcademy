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
        public async Task<IActionResult> GetTrainingById(int id)
        {
            var training = await _context.Trainings.FindAsync(id);

            if (training == null)
            {
                return NotFound();
            }

            return Ok(training);
        }

        #region GetTrainingDTO
        //[HttpGet("trainingDto/{id}")]
        //public async Task<IActionResult> GetTrainingDTOById(int id)
        //{
        //    var training = await _context.Trainings.FindAsync(id);

        //    List<CategoryTraining> items = await _context.CategoryTraining.Where(x => x.TrainingId == training.Id).ToListAsync();
        //    List<int> categories = new List<int>();
        //    foreach (var item in items)
        //    {
        //        categories.Add(item.CategoryId);
        //    }

        //    if (training == null)
        //    {
        //        return NotFound();
        //    }

        //    TrainingDTO entity = new TrainingDTO()
        //    {
        //        training = training,
        //        categoryIndexes = categories.ToArray()
        //    };

        //    return Ok(entity);
        //}
        #endregion

        [HttpPost("add")]
        public async Task<IActionResult> AddTraining(TrainingDTO entity)
        {
            _context.Trainings.Add(entity.training);
            await _context.SaveChangesAsync();

            var training = await _context.Trainings.FindAsync(entity.training.Id);

            foreach(var item in entity.categoryIndexes) {
                await _context.CategoryTraining.AddAsync(new CategoryTraining() { TrainingId = training.Id, CategoryId = item });
            };

            await _context.SaveChangesAsync();

            #region Many to Many Relationship
            //var training = _context.Trainings.Find(newTraining.training.Id);
            //training.TrainingCategories = newTraining.categoryIndexes.Select(x => new TrainingCategories() { 
            //    CategoryId = x,
            //    TrainingId = training.Id
            //}).ToList();
            //_context.SaveChanges();
            #endregion

            return Ok();
        }

        [HttpGet("trainer/{id}")]
        public IActionResult GetTrainingsByTrainerId(int id)
        {
            var trainings = _context.Trainings.Where(t => t.TrainerId == id).ToList();

            if (trainings == null)
            {
                return NotFound();
            }

            return Ok(trainings);
        }

        [HttpGet("training-by-category/{id}")]
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

        [HttpPut("update-training/{id}")]
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
