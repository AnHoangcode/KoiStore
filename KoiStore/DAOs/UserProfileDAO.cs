using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class UserProfileDAO
    {
        private static KoiStoreDBContext _context;
        private static UserProfileDAO instance = null;

        public UserProfileDAO()
        {
            _context = new KoiStoreDBContext();
        }
        public static UserProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserProfileDAO();
                }
                return instance;
            }
        }

        public static UserProfile GetUserProfileById(int id) => _context.UserProfiles.SingleOrDefault(x => x.Profile_Id == id);

        public static bool UpdateUserProfile(UserProfile o)
        {
            bool isSucess = false;
            try
            {
                isSucess = true;
                _context.UserProfiles.Update(o);
                _context.SaveChanges();
                _context.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSucess;
        }

        public bool CreateUserProfile(UserProfile o)
        {
            bool isSucess = false;
            try
            {
                UserProfile ca = _context.UserProfiles.SingleOrDefault(c => c.User_Id == o.User_Id);
                if (ca == null)
                {
                    _context.UserProfiles.Add(o);
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

        public bool DeleteUserProfile(int id)
        {
            bool isSucess = false;
            try
            {
                UserProfile o = GetUserProfileById(id);
                if (o != null)
                {
                    _context.UserProfiles.Remove(o);
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

        public List<UserProfile> GetAllUserProfiles()
        {
            return _context.UserProfiles.ToList();
        }
    }
}
