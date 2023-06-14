using NoCookBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Repositories.Interfaces
{
    public interface IRecipeIngredientRepository
    {
        public List<RecipeIngredient> GetAll();
        public RecipeIngredient GetById(int id);

        public int Insert(RecipeIngredient recipeingredient);
        public int Update(RecipeIngredient recipeingredient);
        public int Delete(int id);

        // estudar este aqui

        public List<RecipeIngredient> GetRecipeIngredientByRecipeId(int recipeId);
    }
}
