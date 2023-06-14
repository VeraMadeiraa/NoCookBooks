using NoCookBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Repositories.Interfaces
{
    public  interface ICategoryRepository
    {
        public List<Category> GetAll();
        public Category GetById(int id);

        public int Insert(Category category);
        public int Update(Category category);
        public int Delete(int id);
    }
}
