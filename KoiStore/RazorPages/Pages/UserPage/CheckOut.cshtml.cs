using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Services.Interface;

namespace RazorPages.Pages.UserPage
{
    public class CheckOutModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IUserProfileService _userProfileService;
        private readonly IKoiProfileService _koiProfileService;
        private readonly IOrderDetailService _orderDetailService;

        public CheckOutModel(IOrderService orderService, IUserProfileService userProfileService, IKoiProfileService koiProfileService, IOrderDetailService orderDetailService)
        {
            _orderService = orderService;
            _userProfileService = userProfileService;
            _koiProfileService = koiProfileService;
            _orderDetailService = orderDetailService;
        }

        [BindProperty]
        public OrderItem OrderItems { get; set; }

        [BindProperty]
        public string DeliveryAddress { get; set; }

        public int Quantity { get; set; }

        public double TotalAmount { get; set; }

        public async Task OnGetAsync()
        {
            int KoiId = (int)HttpContext.Session.GetInt32("KoiId");

            int quantity = (int)HttpContext.Session.GetInt32("KoiQuantity");

            OrderItems = new OrderItem { Koi_Name = _koiProfileService.GetKoiProfileById(KoiId).Koi_Name, Quantity = quantity, UnitPrice = (double)_koiProfileService.GetKoiProfileById(KoiId).Price };

            int UserId = int.Parse(HttpContext.Session.GetString("userId"));

            DeliveryAddress = _userProfileService.GetUserProfileById(UserId).Address;

            TotalAmount = CalculateTotal(OrderItems);

            HttpContext.Session.SetString("TotalAmount", TotalAmount.ToString());

        }

        public async Task<IActionResult> OnPostConfirmOrderAsync()
        {
            int KoiId = (int)HttpContext.Session.GetInt32("KoiId");
            int UserId = int.Parse(HttpContext.Session.GetString("userId"));
            DeliveryAddress = _userProfileService.GetUserProfileById(UserId).Address;
            // Truy xuất TotalAmount từ session
            if (HttpContext.Session.TryGetValue("TotalAmount", out var totalAmountBytes))
            {
                TotalAmount = Convert.ToDouble(System.Text.Encoding.UTF8.GetString(totalAmountBytes));
            }
            else
            {
                TotalAmount = 0; 
            }

            Quantity = (int)HttpContext.Session.GetInt32("KoiQuantity");

            var order = new Order
            {
                User_Id = _userProfileService.GetUserProfileById(UserId).User_Id, 
                Create_At = DateTime.Now,
                Total = TotalAmount,
                Delivery_Address = DeliveryAddress,
                Status = "Pending" 
            };

            _orderService.CreateOrder(order);

            var orderDetail = new OrderDetail
            {
                Order_Id = order.Order_Id,
                User_Id = order.User_Id,
                Koi_Id = _koiProfileService.GetKoiProfileById(KoiId).Koi_Id,
                Quantity = Quantity,
                Total = TotalAmount,
                Order_Detail_Type = null,
                Create_At = DateTime.Now,
                Update_At = DateTime.Now,
                Start_At = DateTime.Now,
                End_At = DateTime.Now,
                Status = "Pending"
            };
            _orderDetailService.CreateOrderDetail(orderDetail);

            TempData["OrderStatus"] = "Order has been placed successfully!";
            return RedirectToPage("/UserPage/OrderHistory");
        }

        private double CalculateTotal(OrderItem item)
        {
            double total = 0;
            total += item.Quantity * item.UnitPrice;
            return total;
        }

        public class OrderItem
        {
            public string Koi_Name { get; set; }
            public int Quantity { get; set; }
            public double UnitPrice { get; set; }
        }
    }
}
