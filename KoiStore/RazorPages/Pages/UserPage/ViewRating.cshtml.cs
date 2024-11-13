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
    public class ViewRatingrModel : PageModel
    {
        private readonly IRatingService _ratingService;

        public ViewRatingrModel(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }
            
        public Rating Rating { get; set; } = default!;

        public IActionResult OnGet(int id, int orderId)
        {
            if (id == 0 || _ratingService.GetAllRatings == null)
            {
                return NotFound();
            }

            var rating = _ratingService.GetRatingbyOrderDetail(id);
            if (rating == null)
            {
                return NotFound();
            }
            else
            {
                Rating = rating;
            }
            ViewData["OrderId"] = orderId;
            return Page();
        }
    }
}
