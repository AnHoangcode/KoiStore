using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using System.Threading.Tasks;
using Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace RazorPages.Pages.UserPage
{
    public class UserProfileModel : PageModel
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileModel(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [BindProperty]
        public UserProfile UserProfile { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {


            int UserId = int.Parse(HttpContext.Session.GetString("userId"));

            UserProfile = _userProfileService.GetUserProfileById(UserId);

            HttpContext.Session.SetString("userProfileId", UserProfile.Profile_Id.ToString());

            if (UserProfile == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                int UserId = int.Parse(HttpContext.Session.GetString("userId"));
                int UserProfileId = int.Parse(HttpContext.Session.GetString("userProfileId"));
                UserProfile.Profile_Id = UserProfileId;
                UserProfile.User_Id = UserId;
                _userProfileService.UpdateUserProfile(UserProfile);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Page();
        }
    }
}
