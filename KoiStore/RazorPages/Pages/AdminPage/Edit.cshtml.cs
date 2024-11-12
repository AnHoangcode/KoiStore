using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using DAOs;
using Services.Interface;

namespace RazorPages.Pages.AdminPage
{
    public class EditModel : PageModel
    {
        private readonly IKoiProfileService _koiProfileService;
        private readonly IKoiFarmService _koiFarmService;
        private readonly IKoiTypeService _koiTypeService;
        public EditModel(IKoiProfileService koiProfileService, IKoiFarmService koiFarmService, IKoiTypeService koiTypeService)
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
            KoiProfile = koiprofile;
           ViewData["Farm_Id"] = new SelectList(_koiFarmService.GetAllKoiFarms(), "Farm_Id", "Farm_Name");
           ViewData["Type_Id"] = new SelectList(_koiTypeService.GetAllKoiTypes(), "Type_Id", "Type_Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
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

            try
            {
                _koiProfileService.UpdateKoiProfile(KoiProfile);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KoiProfileExists(KoiProfile.Koi_Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool KoiProfileExists(int id)
        {
          return _koiProfileService.GetKoiProfileById(id) != null;
        }
    }
}
