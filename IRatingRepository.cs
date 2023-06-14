using NoCookBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        public List<Rating> GetAllRatings();

        public int Insert(Rating rating);
        public int Update(Rating rating);
        public int Delete(int id);
    }
}
