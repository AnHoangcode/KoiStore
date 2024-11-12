using BusinessObjects.Models;
using Repositories.Implement;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implement
{
    public class UserService : IUserService
    {
        private readonly IUserRepo? _userRepo = null;
        public UserService()
        {
            if (_userRepo == null)
            {
                _userRepo = new UserRepo();
            }
        }
        public bool CreateUser(User user)
        {
            return _userRepo.CreateUser(user);
        }

        public bool DeleteUser(int id)
        {
            return _userRepo.DeleteUser(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepo.GetUserById(id);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepo.GetUserByUsername(username);
        }

        public bool UpdateUser(User user)
        {
            return _userRepo.UpdateUser(user);
        }
    }
}
