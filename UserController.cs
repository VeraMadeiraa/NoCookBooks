using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NoCookBooks.Domain.Entities;
using NoCookBooks.Services.Interfaces;
using NoCookBooks.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace NoCookBooks.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _environment;

       

        public UserController(IRecipeService recipeService, IWebHostEnvironment environment, ICategoryService categoryService, IUserService userService)
        {
            _recipeService = recipeService;
            _categoryService = categoryService;
            _environment = environment;
            _userService = userService;
           
        }

        
        public IActionResult CreateRecipeUser()
        {
            var recipeModel = new RecipeModel()
            {
                Categories = _categoryService.GetAll()
            };

            return View(recipeModel);
        }


       
       

        public IActionResult GetAllRecipeUser()
        {
            List<Recipe> recipes = _recipeService.GetAll();
            return View(recipes);
        }

        public IActionResult Index()
        {
            return View();
        }

        

    }
}
