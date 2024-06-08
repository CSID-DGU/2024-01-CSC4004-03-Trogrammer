using System.Collections.Generic;

namespace MyApiProject.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Food> Ingredients { get; set; }
    }
}
