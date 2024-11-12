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
        public int UserId { get; private set; }

        public async Task<IActionResult> OnGetAsync()
        {


            int UserId = int.Parse(HttpContext.Session.GetString("userId"));

            UserProfile = _userProfileService.GetUserProfileById(UserId);

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

            _userProfileService.UpdateUserProfile(UserProfile);
            
            return RedirectToPage("/UserPage/UserProfile", new { id = UserProfile.Profile_Id });
        }
    }
}
