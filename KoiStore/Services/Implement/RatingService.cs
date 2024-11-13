using BusinessObjects.Models;
using Repositories.Implement;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implement
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepo _repo = null;

        public RatingService()
        {
            if (_repo == null)
            {
                _repo = new RatingRepo();
            }
        }
        public bool CreateRating(Rating o) => _repo.CreateRating(o);

        public bool DeleteRating(int id) => _repo.DeleteRating(id);

        public List<Rating> GetAllRatings() => _repo.GetAllRatings();

        public Rating GetRatingById(int id) => _repo.GetRatingById(id);

        public Rating GetRatingbyOrderDetail(int order_Detail_Id)
        {
            return _repo.GetRatingbyOrderDetail(order_Detail_Id);
        }

        public bool UpdateRating(Rating o) => _repo.UpdateRating(o);
    }
}
