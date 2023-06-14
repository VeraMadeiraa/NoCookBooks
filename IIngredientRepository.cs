using NoCookBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        public List<Ingredient>GetAll();
        public Ingredient GetById(int id);

        public int Insert(Ingredient ingredient);
        public int Update(Ingredient ingredient);
        public int Delete(int id);

        // Estudar isto aqui
        public List<Ingredient> GetByRecipeId(int recipeId);

        public List<Ingredient> GetRecipesByIngredientId(int id);

    }
}
