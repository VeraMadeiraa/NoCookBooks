using NoCookBooks.Domain.Entities;
using NoCookBooks.Repositories.Interfaces;
using NoCookBooks.Services.Interfaces;
using NoCookBooks.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Services.Implementations
{
    public class RecipeService: IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;


        public RecipeService(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository, IRecipeIngredientRepository recipeIngredientRepository)
        {
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientRepository;
            _recipeIngredientRepository = recipeIngredientRepository;
        }

        public List<Recipe> GetAll()
        {
            return _recipeRepository.GetAll();
        }

        public Recipe GetById(int id)
        {
            return _recipeRepository.GetById(id);
        }

        public int Save(Recipe recipe, List<Ingredient> ingredients, List<RecipeIngredient> recipeIngredients)
        {

            if (recipe.Id == 0)
            {
                _recipeRepository.Insert(recipe);
                ingredients.ForEach(ingredient =>
                {
                    _ingredientRepository.Insert(ingredient);
                    
                }); // esta linha permite.me inserir todos os ingredients
                recipeIngredients.ForEach(recipeIngredient =>
                {
                    _recipeIngredientRepository.Insert(recipeIngredient);

                });
                return 0;
            }
                
            else
            {
                _recipeRepository.Update(recipe);
                ingredients.ForEach(ingredient =>
                {
                    _ingredientRepository.Insert(ingredient);

                }); // esta linha permite.me inserir todos os ingredients
                recipeIngredients.ForEach(recipeIngredient =>
                {
                    _recipeIngredientRepository.Insert(recipeIngredient);

                });
                return 0;
            }
            
        }

        public int Delete(int id)
        {
            return _recipeRepository.Delete(id);
        }

        //estudar esta parte
        public RecipeModel GetByIdWithIngredients(int id)
        {
            RecipeModel recipeModel = new RecipeModel
            {
                Recipe = _recipeRepository.GetById(id),
                Ingredients = _ingredientRepository.GetByRecipeId(id),
                RecipeIngredients = _recipeIngredientRepository.GetRecipeIngredientByRecipeId(id)
            };

            return recipeModel;
        }
    }
}
