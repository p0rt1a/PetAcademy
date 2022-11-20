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
    public class CategoriesController : ControllerBase
    {
        private readonly AcademyContext _context;

        public CategoriesController(AcademyContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _context.Categories.ToList();
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
    }
}
