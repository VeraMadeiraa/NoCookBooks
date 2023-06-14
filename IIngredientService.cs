using NoCookBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Services.Interfaces
{
    public interface IIngredientService
    {
        List<Ingredient> GetAll();
        Ingredient GetById(int id); 
        int Save(Ingredient ingredient);
        int Delete(int id);
    }
}
