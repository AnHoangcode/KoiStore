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

namespace RazorPages.Pages.AdminPage
{
    public class EditModel : PageModel
    {
        private readonly DAOs.KoiStoreDBContext _context;

        public EditModel(DAOs.KoiStoreDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public KoiProfile KoiProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.KoiProfiles == null)
            {
                return NotFound();
            }

            var koiprofile =  await _context.KoiProfiles.FirstOrDefaultAsync(m => m.Koi_Id == id);
            if (koiprofile == null)
            {
                return NotFound();
            }
            KoiProfile = koiprofile;
           ViewData["Farm_Id"] = new SelectList(_context.KoiFarms, "Farm_Id", "Farm_Id");
           ViewData["Type_Id"] = new SelectList(_context.KoiTypes, "Type_Id", "Type_Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(KoiProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
          return (_context.KoiProfiles?.Any(e => e.Koi_Id == id)).GetValueOrDefault();
        }
    }
}
