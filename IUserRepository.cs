using NoCookBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public int Insert(User user);
        public int Update(User user);
        public int Delete(int id);
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        User FindUserByEmailAndPassword(string email, string password);
        
    }
}
