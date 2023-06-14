using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NoCookBooks.Domain.Entities;
using NoCookBooks.Services.Interfaces;
using NoCookBooks.Services.Models;
using System.Collections.Generic;
using System.IO;

namespace NoCookBooks.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _environment;

        public RecipeController(IRecipeService recipeService, IWebHostEnvironment environment, ICategoryService categoryService)
        {
            _recipeService = recipeService;
            _categoryService = categoryService;
            _environment = environment; 
        }

        public IActionResult GetAll()
        {
            List<Recipe> recipes = _recipeService.GetAll();
            return View(recipes);
        }

        public IActionResult CreateRecipe()
        {
            var recipeModel = new RecipeModel()
            {
                Categories = _categoryService.GetAll()
            };

            return View(recipeModel);
        }

        public IActionResult SaveRecipe(Recipe recipe, List<Ingredient>ingredients, List<RecipeIngredient>recipeIngredients)
        {
            _recipeService.Save(recipe, ingredients, recipeIngredients);

            if (recipe.ImageUrl != null)
            {
                var file = Path.Combine(_environment.WebRootPath, "img", recipe.ImageUrl.FileName);
                var fileStream = new FileStream(file, FileMode.Create);

                recipe.ImageUrl.CopyToAsync(fileStream);
            }

            List<Recipe>recipes = _recipeService.GetAll();
            return View("GetAll", recipes);
        }

    }
}
