using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interface;
using X.PagedList;
using X.PagedList.Extensions;

namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IKoiProfileService _koi;

        public IndexModel(ILogger<IndexModel> logger, IKoiProfileService koi)
        {
            _logger = logger;
            _koi = koi;
        }

        public IPagedList<KoiProfile> KoiProfiles { get; set; }
        public string SearchTerm { get; set; }
        public void OnGet(int? pageNumber, string searchTerm)
        {
            int pageSize = 4; // Số lượng sản phẩm trên mỗi trang

            // Lưu giá trị tìm kiếm để hiển thị trong ô nhập liệu
            SearchTerm = searchTerm;

            // Lấy danh sách sản phẩm từ service
            var koiProfiles = _koi.GetAllKoiProfiles().AsQueryable();

            // Tìm kiếm theo tên sản phẩm hoặc mô tả
            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Tìm kiếm theo tên sản phẩm
                koiProfiles = koiProfiles.Where(p => p.Koi_Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                                               || p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            // Phân trang kết quả
            KoiProfiles = koiProfiles.ToPagedList(pageNumber ?? 1, pageSize);
        }
    }
}
