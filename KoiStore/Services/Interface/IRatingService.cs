using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IRatingService
    {
        List<Rating> GetAllRatings();
        Rating GetRatingById(int id);
        bool UpdateRating(Rating o);
        bool DeleteRating(int id);
        bool CreateRating(Rating o);
        Rating GetRatingbyOrderDetail(int order_Detail_Id);
    }
}
