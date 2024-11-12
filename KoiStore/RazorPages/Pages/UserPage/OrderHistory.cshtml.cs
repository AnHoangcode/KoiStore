using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interface;  // Nếu sử dụng service để lấy dữ liệu
using BusinessObjects.Models;  // Các mô hình dữ liệu (Product, Order...)

namespace RazorPages.Pages.UserPage
{
    public class OrderHistoryModel : PageModel
    {
        private readonly IOrderService _orderService;  // Sử dụng service để lấy dữ liệu

        public List<Order> Orders { get; set; }

        public OrderHistoryModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public void OnGet()
        {
            // Giả sử userId được lưu trong session
            var userId = int.Parse(HttpContext.Session.GetString("userId"));

            // Lấy danh sách đơn hàng của người dùng từ service
            Orders = _orderService.GetOrdersByUserId(userId);
        }
    }
}
