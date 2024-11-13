using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using DAOs;
using Services.Interface;

namespace RazorPages.Pages.UserPage
{
    public class CreateRatingModel : PageModel
    {
        private readonly IRatingService _ratingService;

        public CreateRatingModel(IRatingService ratingService   )
        {
            _ratingService = ratingService;
            Rating = new Rating();
        }
        public int userId {  get; set; }
        public int orderDetailId { get; set; }
        [BindProperty]
        public Rating Rating { get; set; } = default!;
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost(int id, int orderId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            orderDetailId = id;
            string userIdString = HttpContext.Session.GetString("userId");
            if (!string.IsNullOrEmpty(userIdString) && int.TryParse(userIdString, out var parsedUserId)) // Ensure safe parsing
            {
                userId = parsedUserId;
            }
            Rating.User_Id = userId;
            Rating.Order_Detail_Id = orderDetailId;
            Rating.Status = "Visible";
            Rating.Create_At = DateTime.Now;

            _ratingService.CreateRating(Rating);

            return RedirectToPage("./DetailsOrderDetail", new { id = orderId });
        }
    }
}
