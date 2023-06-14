using NoCookBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Services.Interfaces
{
    public interface IRecipeIngredientService
    {
        List<RecipeIngredient> GetAll();
        RecipeIngredient GetById(int id);
        int Save(RecipeIngredient recipeingredient);
        int Delete(int id);
    }
}
