using NoCookBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        public List<Recipe> GetAll();

        public Recipe GetById(int id);
        public List<Recipe> GetByCategoryId(int categoryId);
        public int Insert(Recipe recipe);
        public int Update(Recipe recipe);
        public int Delete(int id);
    }
}
