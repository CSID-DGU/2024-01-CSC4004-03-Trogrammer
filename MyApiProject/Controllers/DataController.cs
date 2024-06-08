using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MyApiProject.Models;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet("foods")]
        public IEnumerable<Food> GetFoods()
        {
            return Database.Foods;
        }

        [HttpGet("recipes")]
        public IEnumerable<Recipe> GetRecipes()
        {
            return Database.Recipes;
        }

        [HttpPost("addFood")]
        public IActionResult AddFood([FromBody] Food food)
        {
            Database.Foods.Add(food);
            return Ok();
        }
    }
}
