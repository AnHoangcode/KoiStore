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

        //public async Task<IActionResult> OnGetBuyNowAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    HttpContext.Session.SetInt32("KoiId", (int)id);
        //    HttpContext.Session.SetInt32("KoiQuantity", Quantity);

        //    // Chuyển hướng đến trang Checkout
        //    return RedirectToPage("/UserPage/CheckOut");
        //}


        [BindProperty]

        public string? ErrorMessage { get; set; }

        public KoiProfile KoiProfile { get; set; } = default!;
        public int Quantity { get; set; }

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

        public async Task<IActionResult> OnPost(int id, int quantity)
        {

            var koiprofile = _koiProfileService.GetKoiProfileById(id);
            // Kiểm tra xem giá trị Quantity có được nhận đúng không
            if (quantity > 0)
            {
                // Lưu Quantity vào Session
                HttpContext.Session.SetInt32("KoiId", (int)id);
                HttpContext.Session.SetInt32("KoiQuantity", quantity);

                // Chuyển hướng tới trang Checkout hoặc trang khác
                return RedirectToPage("/UserPage/CheckOut");
            }

            if (quantity > koiprofile.Quantity)
            {
                ErrorMessage = "Out of stock";
                return await OnGetAsync(id); // Trả về trang hiện tại với thông báo lỗi
            }

            return Page();
        }
    }
}
