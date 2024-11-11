using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using DAOs;

namespace RazorPages.Pages.AdminPage
{
    public class CreateModel : PageModel
    {
        private readonly DAOs.KoiStoreDBContext _context;

        public CreateModel(DAOs.KoiStoreDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Farm_Id"] = new SelectList(_context.KoiFarms, "Farm_Id", "Farm_Id");
        ViewData["Type_Id"] = new SelectList(_context.KoiTypes, "Type_Id", "Type_Id");
            return Page();
        }

        [BindProperty]
        public KoiProfile KoiProfile { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.KoiProfiles == null || KoiProfile == null)
            {
                return Page();
            }

            _context.KoiProfiles.Add(KoiProfile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
