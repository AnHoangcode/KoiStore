using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class UserDAO
    {
        private static KoiStoreDBContext _context;
        private static UserDAO instance = null;

        public UserDAO()
        {
            _context = new KoiStoreDBContext();
        }
        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDAO();
                }
                return instance;
            }
        }

        public bool DeleteUser(int id)
        {
            bool isSucess = false;
            try
            {
                User o = GetUserById(id);
                if (o != null)
                {
                    _context.Roles.Remove(o);
                    _context.SaveChanges();
                    _context.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    isSucess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSucess;
        }

        public static List<User> GetAllUsers() => _context.Users.ToList();

        public User GetUserById(int id) => _context.Users.SingleOrDefault(x => x.User_Id == id);

        public User GetUserByUsername(string username) => _context.Users.SingleOrDefault(y => y.Username == username);

        public bool CreateUser(User o)
        {
            bool isSucess = false;
            try
            {
                User ca = _context.Users.SingleOrDefault(c => c.Username == o.Username);
                if (ca == null)
                {
                    _context.Users.Add(o);
                    _context.SaveChanges();
                    _context.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    isSucess = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSucess;
        }

        public bool UpdateUser(User o)
        {
            bool isSucess = false;
            try
            {
                isSucess = true;
                _context.Roles.Update(o);
                _context.SaveChanges();
                _context.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSucess;
        }
    }
}
