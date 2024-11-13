using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class RatingDAO
    {
        private static KoiStoreDBContext _context;
        private static RatingDAO instance = null;

        public RatingDAO()
        {
            _context = new KoiStoreDBContext();
        }
        public static RatingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RatingDAO();
                }
                return instance;
            }
        }

        public bool CreateRating(Rating o)
        {
            bool isSucess = false;
            try
            {
                _context.Ratings.Add(o);
                _context.SaveChanges();
                _context.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                isSucess = true;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSucess;
        }

        public bool DeleteRating(int id)
        {
            bool isSucess = false;
            try
            {
                Rating o = GetRatingById(id);
                if (o != null)
                {
                    _context.Ratings.Remove(o);
                    _context.SaveChanges();
                    _context.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    isSucess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSucess;
        }

        public List<Rating> GetAllRatings() => _context.Ratings.ToList();

        public Rating GetRatingById(int id) => _context.Ratings.SingleOrDefault(x => x.Rating_Id == id);

        public Rating GetRatingbyOrderDetail(int order_Detail_Id)
        {
            return _context.Ratings.SingleOrDefault(x => x.Order_Detail_Id == order_Detail_Id);
        }

        public bool UpdateRating(Rating o)
        {
            bool isSucess = false;
            try
            {
                isSucess = true;
                _context.Ratings.Update(o);
                _context.SaveChanges();
                _context.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSucess;
        }
    }
}
