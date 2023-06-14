using NoCookBooks.Domain.Entities;
using NoCookBooks.Repositories.Implementations;
using NoCookBooks.Repositories.Interfaces;
using NoCookBooks.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Services.Implementations
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;

        public RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository)
        {
            _recipeIngredientRepository = recipeIngredientRepository;
        }
        public List<RecipeIngredient> GetAll()
        {
            return _recipeIngredientRepository.GetAll();
        }
        public RecipeIngredient GetById(int id)
        {
            return _recipeIngredientRepository.GetById(id);
        }

        public int Save(RecipeIngredient recipeingredient)
        {
            if (recipeingredient.Id == 0)
                return _recipeIngredientRepository.Insert(recipeingredient);
            else
                return _recipeIngredientRepository.Update(recipeingredient);
        }

        public int Delete(int id)
        {
            return _recipeIngredientRepository.Delete(id);
        }

        public List<RecipeIngredient> GetRecipeIngredientByRecipeId(int id)
        {
            return _recipeIngredientRepository.GetRecipeIngredientByRecipeId(id);
        }
    }
}
