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
    public class UserProfileRepo : IUserProfileRepo
    {
        public bool CreateUserProfile(UserProfile o) => UserProfileDAO.Instance.CreateUserProfile(o);

        public bool DeleteUserProfile(int id) => UserProfileDAO.Instance.DeleteUserProfile(id);

        public List<UserProfile> GetAllUserProfiles() => UserProfileDAO.Instance.GetAllUserProfiles();

        public UserProfile GetUserProfileById(int id) => UserProfileDAO.GetUserProfileById(id);

        public bool UpdateUserProfile(UserProfile o) => UserProfileDAO.UpdateUserProfile(o);
    }
}
