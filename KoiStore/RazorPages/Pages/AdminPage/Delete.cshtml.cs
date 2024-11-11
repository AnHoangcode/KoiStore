using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using DAOs;

namespace RazorPages.Pages.AdminPage
{
    public class DeleteModel : PageModel
    {
        private readonly DAOs.KoiStoreDBContext _context;

        public DeleteModel(DAOs.KoiStoreDBContext context)
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

            var koiprofile = await _context.KoiProfiles.FirstOrDefaultAsync(m => m.Koi_Id == id);

            if (koiprofile == null)
            {
                return NotFound();
            }
            else 
            {
                KoiProfile = koiprofile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.KoiProfiles == null)
            {
                return NotFound();
            }
            var koiprofile = await _context.KoiProfiles.FindAsync(id);

            if (koiprofile != null)
            {
                KoiProfile = koiprofile;
                _context.KoiProfiles.Remove(KoiProfile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
