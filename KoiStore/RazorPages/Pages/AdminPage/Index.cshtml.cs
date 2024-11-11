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
    public class IndexModel : PageModel
    {
        private readonly IKoiProfileService _koiProfileService;
        private readonly IKoiFarmService _koiFarmService;

        public IndexModel(IKoiProfileService koiProfileService, IKoiFarmService koiFarmService)
        {
            _koiProfileService = koiProfileService;
            _koiFarmService = koiFarmService;
        }

        public IList<KoiProfile> KoiProfile { get;set; } = default!;

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 3;
        public int TotalPages { get; set; } = 1;
        public async Task OnGetAsync(int pageNumber = 1)
        {
            PageNumber = pageNumber;

            var koiProfiles = _koiProfileService.GetAllKoiProfiles();

            var totalItems = koiProfiles.Count;
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
            koiProfiles = koiProfiles.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();

            koiProfiles.ForEach(koiProfile =>
            {
                if (koiProfile.Farm_Id.HasValue)
                {
                    koiProfile.Farm = _koiFarmService.GetKoiFarmById(koiProfile.Farm_Id.Value); 
                }
                else
                {
                    koiProfile.Farm = null; 
                }
            });
            KoiProfile = koiProfiles;
        }
    }
}
