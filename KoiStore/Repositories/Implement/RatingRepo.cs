using BusinessObjects.Models;
using DAOs;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implement
{
    public class RatingRepo : IRatingRepo
    {
        public bool CreateRating(Rating o) => RatingDAO.Instance.CreateRating(o);

        public bool DeleteRating(int id) => RatingDAO.Instance.DeleteRating(id);

        public List<Rating> GetAllRatings() => RatingDAO.Instance.GetAllRatings();

        public Rating GetRatingById(int id) => RatingDAO.Instance.GetRatingById(id);

        public Rating GetRatingbyOrderDetail(int order_Detail_Id)
        {
            return RatingDAO.Instance.GetRatingbyOrderDetail(order_Detail_Id);
        }

        public bool UpdateRating(Rating o) => RatingDAO.Instance.UpdateRating(o);
    }
}
