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
    public  class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public User Authenticate(string email, string password)
        {
            User user = _userRepository.FindUserByEmailAndPassword(email, password);
            return user;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }


        public List<User> GetAll()
        {
            return _userRepository.GetAllUsers();
        }


        public int Save(User user)
        {
            if (user.Id == 0)
                return _userRepository.Insert(user);
            else
                return _userRepository.Update(user);

        }


        public int Delete(int id)
        {
            return _userRepository.Delete(id);

        }
    }
}
