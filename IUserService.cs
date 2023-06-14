using NoCookBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetUserById(int id);

        int Save(User user);
        int Delete(int id);

        User Authenticate(string email, string password);
    }
}
