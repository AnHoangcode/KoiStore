using BusinessObjects.Models;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implement
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepo? _userProfileRepo;
        public bool CreateUserProfile(UserProfile o) => _userProfileRepo.CreateUserProfile(o);

        public bool DeleteUserProfile(int id) => _userProfileRepo.DeleteUserProfile(id);

        public List<UserProfile> GetAllUserProfiles() => _userProfileRepo.GetAllUserProfiles();

        public UserProfile GetUserProfileById(int id) => _userProfileRepo.GetUserProfileById(id);

        public bool UpdateUserProfile(UserProfile o) => _userProfileRepo.UpdateUserProfile(o);
    }
}
