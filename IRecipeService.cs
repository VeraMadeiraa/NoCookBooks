using NoCookBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Services.Interfaces
{
    public interface IRecipeService
    {
        List<Recipe> GetAll();
        Recipe GetById(int id);
        int Save(Recipe recipe, List<Ingredient> ingredients, List<RecipeIngredient> recipeIngredients);
        int Delete(int id);
    }
}
