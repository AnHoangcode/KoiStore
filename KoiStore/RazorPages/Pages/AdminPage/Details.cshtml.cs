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
    public class DetailsModel : PageModel
    {
        private readonly DAOs.KoiStoreDBContext _context;

        public DetailsModel(DAOs.KoiStoreDBContext context)
        {
            _context = context;
        }

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
    }
}
