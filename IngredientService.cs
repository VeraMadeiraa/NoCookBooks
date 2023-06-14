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
    public class IngredientService: IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public List<Ingredient> GetAll()
        {
            return _ingredientRepository.GetAll();
        }

        public Ingredient GetById(int id)
        {
            return _ingredientRepository.GetById(id);
        }

        public int Save(Ingredient ingredient)
        {
            if (ingredient.Id == 0)
                return _ingredientRepository.Insert(ingredient);
            else
                return _ingredientRepository.Update(ingredient);
        }

        public int Delete(int id)
        {
            return _ingredientRepository.Delete(id);
        }

        // estudar

        public List<Ingredient> GetRecipesByIngredientId(int id)
        {
            return _ingredientRepository.GetRecipesByIngredientId(id);
        }
    }
}
