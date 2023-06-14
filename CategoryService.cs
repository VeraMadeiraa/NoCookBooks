using NoCookBooks.Domain.Entities;
using NoCookBooks.Repositories.Implementations;
using NoCookBooks.Repositories.Interfaces;
using NoCookBooks.Services.Interfaces;
using NoCookBooks.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRecipeRepository _recipeRepository;

        public CategoryService(ICategoryRepository categoryRepository, IRecipeRepository recipeRepository)
        {
            _categoryRepository = categoryRepository;
            _recipeRepository = recipeRepository;
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public int Save(Category category)
        {
            if (category.Id == 0)
                return _categoryRepository.Insert(category);
            else
                return _categoryRepository.Update(category);
        }

        public int Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }

        //estudar
        public CategoryModel GetByIdWithRecipes(int id)
        {
            CategoryModel categoryModel = new CategoryModel
            {
                Category = _categoryRepository.GetById(id),
                Recipes = _recipeRepository.GetByCategoryId(id)

            };

            return categoryModel;
        }
    }
}
