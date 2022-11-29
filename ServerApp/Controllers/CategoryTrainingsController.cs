using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class CategoryTrainingsController : ControllerBase
    {
        private readonly AcademyContext _context;

        public CategoryTrainingsController(AcademyContext context)
        {
            this._context = context;
        }

        [HttpGet("getCategories/{id}")]
        public IActionResult GetCategoriesByTrainingId(int id)
        {
            var allTable = _context.CategoryTraining.Where(x => x.TrainingId == id).ToList();

            if (allTable == null)
            {
                return BadRequest();
            }
            return Ok(allTable);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCategoryTraining(CategoryTrainingDTO entity)
        {
            CategoryTraining categoryTraining = new CategoryTraining()
            {
                CategoryId = entity.CategoryId,
                TrainingId = entity.TrainingId
            };

            await _context.CategoryTraining.AddAsync(categoryTraining);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("getTrainings")]
        public IActionResult GetTrainingsByCategoryId(int id)
        {
            var allTable = _context.CategoryTraining.Where(x => x.CategoryId == id).ToList();

            if (allTable == null)
            {
                return BadRequest();
            }

            return Ok(allTable);
        }
    }
}
