using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using DAOs;
using Services.Interface;

namespace RazorPages.Pages.AdminPage
{
    public class DeleteModel : PageModel
    {
        private readonly IKoiProfileService _koiProfileService;
        private readonly IKoiFarmService _koiFarmService;
        private readonly IKoiTypeService _koiTypeService;
        public DeleteModel(IKoiProfileService koiProfileService, IKoiFarmService koiFarmService, IKoiTypeService koiTypeService)
        {
            _koiProfileService = koiProfileService;
            _koiFarmService = koiFarmService;
            _koiTypeService = koiTypeService;
        }

        [BindProperty]
        public KoiProfile KoiProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koiprofile = _koiProfileService.GetKoiProfileById((int)id);

            if (koiprofile == null)
            {
                return NotFound();
            }
            else
            {
                koiprofile.Farm = _koiFarmService.GetKoiFarmById((int)koiprofile.Farm_Id);
                koiprofile.Type = _koiTypeService.GetKoiTypeById((int)koiprofile.Type_Id);
                KoiProfile = koiprofile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var koiprofile = _koiProfileService.GetKoiProfileById((int)id);

            if (koiprofile != null)
            {
                KoiProfile = koiprofile;
                _koiProfileService.DeleteKoiProfile(KoiProfile.Koi_Id);
            }

            return RedirectToPage("./Index");
        }
    }
}
