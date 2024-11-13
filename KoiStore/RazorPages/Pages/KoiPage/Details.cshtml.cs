using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Services.Interface;

namespace RazorPages.Pages.KoiPage
{
    public class DetailsModel : PageModel
    {
        private readonly IKoiProfileService _koiProfileService;
        private readonly IKoiFarmService _koiFarmService;
        private readonly IKoiTypeService _koiTypeService;

        public DetailsModel(IKoiProfileService koiProfileService, IKoiFarmService koiFarmService, IKoiTypeService koiTypeService)
        {
            _koiProfileService = koiProfileService;
            _koiFarmService = koiFarmService;
            _koiTypeService = koiTypeService;
        }

        [BindProperty]
        public KoiProfile KoiProfile { get; set; } = default!;

        [BindProperty]
        public int Quantity { get; set; }

        public string? ErrorMessage { get; set; }

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

        public async Task<IActionResult> OnPostBuyNowAsync(int id, int quantity)
        {
            var koiprofile = _koiProfileService.GetKoiProfileById(id);

            if (koiprofile == null)
            {
                return NotFound();
            }

            if (quantity > koiprofile.Quantity)
            {
                ErrorMessage = "Out of stock";
                return await OnGetAsync(id); // Trả về trang hiện tại với thông báo lỗi
            }

            // Xử lý logic mua hàng (giảm số lượng trong kho và tạo đơn hàng nếu cần)
            koiprofile.Quantity -= quantity;
            //await _koiProfileService.UpdateKoiProfileAsync(koiprofile);

            // Điều hướng đến trang xác nhận hoặc giỏ hàng
            return RedirectToPage("/KoiPage/OrderConfirmation", new { id, quantity });
        }
    }
}
