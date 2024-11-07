using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IUserProfileRepo
    {
        bool CreateUserProfile(UserProfile o);
        bool DeleteUserProfile(int id);
        List<UserProfile> GetAllUserProfiles();
        UserProfile GetUserProfileById(int id);
        bool UpdateUserProfile(UserProfile o);
    }
}
