using BusinessObjects.Models;
using DAOs;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implement
{
    public class UserRepo : IUserRepo
    {
        public bool CreateUser(User user) => UserDAO.Instance.CreateUser(user);

        public bool DeleteUser(int id) => UserDAO.Instance.DeleteUser(id);

        public List<User> GetAllUsers() => UserDAO.GetAllUsers();

        public User GetUserById(int id) => UserDAO.Instance.GetUserById(id);

        public User GetUserByUsername(string username) => UserDAO.Instance.GetUserByUsername(username);

        public bool UpdateUser(User user) => UserDAO.Instance.UpdateUser(user);
    }
}
