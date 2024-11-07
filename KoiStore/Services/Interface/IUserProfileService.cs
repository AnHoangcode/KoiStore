using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IUserProfileService
    {
        List<UserProfile> GetAllUserProfiles();
        UserProfile GetUserProfileById(int id);
        bool UpdateUserProfile(UserProfile o);
        bool DeleteUserProfile(int id);
        bool CreateUserProfile(UserProfile o);
    }
}
