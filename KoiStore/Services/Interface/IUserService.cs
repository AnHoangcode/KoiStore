using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByUsername(string username);
        bool UpdateUser (User user);
        bool DeleteUser (int id);
        bool CreateUser (User user);
    }
}
