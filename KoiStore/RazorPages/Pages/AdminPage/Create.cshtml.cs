using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using DAOs;
using Services.Interface;

namespace RazorPages.Pages.AdminPage
{
    public class CreateModel : PageModel
    {
        private readonly IKoiProfileService _koiProfileService;
        private readonly IKoiFarmService _koiFarmService;
        private readonly IKoiTypeService _koiTypeService;
        public CreateModel(IKoiProfileService koiProfileService, IKoiFarmService koiFarmService, IKoiTypeService koiTypeService)
        {
            _koiProfileService = koiProfileService;
            _koiFarmService = koiFarmService;
            _koiTypeService = koiTypeService;
        }

        public IActionResult OnGet()
        {
            ViewData["Farm_Id"] = new SelectList(_koiFarmService.GetAllKoiFarms(), "Farm_Id", "Farm_Name");
            ViewData["Type_Id"] = new SelectList(_koiTypeService.GetAllKoiTypes(), "Type_Id", "Type_Name");
            return Page();
        }

        [BindProperty]
        public KoiProfile KoiProfile { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("KoiProfile.Farm");
            ModelState.Remove("KoiProfile.Type");
            if (!ModelState.IsValid)
            {
                ViewData["Farm_Id"] = new SelectList(_koiFarmService.GetAllKoiFarms(), "Farm_Id", "Farm_Name");
                return Page();
            }
            if (!ModelState.IsValid)
            {
                ViewData["Type_Id"] = new SelectList(_koiTypeService.GetAllKoiTypes(), "Type_Id", "Type_Name");
                return Page();
            }
            _koiProfileService.CreateKoiProfile(KoiProfile);
            return RedirectToPage("./Index");
        }
    }
}
