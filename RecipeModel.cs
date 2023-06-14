using Microsoft.AspNetCore.Http;
using NoCookBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Services.Models
{
    public class RecipeModel
    {
        public Recipe Recipe { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Recipe> Recipes { get; set; }

        public List<Category> Categories { get; set; }
        public Ingredient Ingredient { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; }
        public RecipeIngredient Recipeingredient { get; set; }
        public Rating Rating { get; set; }
        public List<Rating> Ratings { get; set; }

        public IFormFile ImageUrl { get; set; }



    }
}
