using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Services.Interface;

namespace RazorPages.Pages.KoiPage
{
    public class IndexModel : PageModel
    {
        private readonly IKoiProfileService _koiProfileService;
        private readonly IKoiFarmService _koiFarmService;
        private readonly IKoiTypeService _koiTypeService;

        public IndexModel(IKoiProfileService koiProfileService, IKoiFarmService koiFarmService, IKoiTypeService koiTypeService)
        {
            _koiProfileService = koiProfileService;
            _koiFarmService = koiFarmService;
            _koiTypeService = koiTypeService;
        }

        public IList<KoiProfile> KoiProfile { get; set; } = default!;
        public List<string> SelectedPriceFilters { get; set; } = new();
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 3;
        public int TotalPages { get; set; } = 1;

        public async Task OnGetAsync(int pageNumber = 1, List<string> priceFilters = null)
        {
            PageNumber = pageNumber;
            SelectedPriceFilters = priceFilters ?? new List<string>();

            // Lấy danh sách cá Koi
            var koiProfiles = _koiProfileService.GetAllKoiProfiles();

            // Áp dụng bộ lọc giá
            koiProfiles = ApplyPriceFilter(koiProfiles, SelectedPriceFilters);

            // Phân trang
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
            koiProfiles.ForEach(koiProfile =>
            {
                if (koiProfile.Type_Id.HasValue)
                {
                    koiProfile.Type = _koiTypeService.GetKoiTypeById(koiProfile.Type_Id.Value);
                }
                else
                {
                    koiProfile.Type = null;
                }
            });
            KoiProfile = koiProfiles;
        }

        private List<KoiProfile> ApplyPriceFilter(List<KoiProfile> koiProfiles, List<string> priceFilters)
        {
            if (priceFilters == null || !priceFilters.Any()) return koiProfiles;

            // Áp dụng các bộ lọc giá cùng lúc nếu nhiều bộ lọc được chọn
            var filteredKoiProfiles = new List<KoiProfile>();

            if (priceFilters.Contains("under100"))
            {
                filteredKoiProfiles.AddRange(koiProfiles.Where(k => k.Price < 100));
            }
            if (priceFilters.Contains("100to200"))
            {
                filteredKoiProfiles.AddRange(koiProfiles.Where(k => k.Price >= 100 && k.Price <= 200));
            }
            if (priceFilters.Contains("200to300"))
            {
                filteredKoiProfiles.AddRange(koiProfiles.Where(k => k.Price > 200 && k.Price <= 300));
            }
            if (priceFilters.Contains("over300"))
            {
                filteredKoiProfiles.AddRange(koiProfiles.Where(k => k.Price > 300));
            }

            return filteredKoiProfiles.Distinct().ToList();
        }
    }
}
