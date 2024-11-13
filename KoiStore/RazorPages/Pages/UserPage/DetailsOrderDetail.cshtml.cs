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

namespace RazorPages.Pages.UserPage
{
    public class DetailsOrderDetailModel : PageModel
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IRatingService _ratingService;

        public DetailsOrderDetailModel(IOrderDetailService orderDetailService, IRatingService ratingService) // Inject IRatingService
        {
            _orderDetailService = orderDetailService;
            _ratingService = ratingService;
        }

        public IList<OrderDetail> OrderDetail { get; set; } = default!;
        public int Order_Id { get; set; }
        public Dictionary<int, bool> HasRating { get; set; } = new Dictionary<int, bool>(); // Dictionary to store rating existence

        public void OnGet(int id)
        {
            Order_Id = id;
            if (_orderDetailService.GetOrderDetailByOrderId(id) != null)
            {
                OrderDetail = _orderDetailService.GetOrderDetailByOrderId(id);

                // Check for existing ratings
                foreach (var orderDetail in OrderDetail)
                {
                    HasRating[orderDetail.Order_Detail_Id] = _ratingService.GetRatingbyOrderDetail(orderDetail.Order_Detail_Id) != null;
                }
            }
        }
    }
}
