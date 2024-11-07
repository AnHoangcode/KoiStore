using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class FeedbackDAO
    {
        private static KoiStoreDBContext _context;
        private static FeedbackDAO instance = null;

        public FeedbackDAO()
        {
            _context = new KoiStoreDBContext();
        }
        public static FeedbackDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FeedbackDAO();
                }
                return instance;
            }
        }

        public bool CreateFeedback(Feedback o)
        {
            bool isSucess = false;
            try
            {
                Feedback ca = _context.Feedbacks.SingleOrDefault(c => c.Feedback_Id == o.Feedback_Id);
                if (ca == null)
                {
                    _context.Feedbacks.Add(o);
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

        public bool DeleteFeedback(int id)
        {
            bool isSucess = false;
            try
            {
                Feedback o = GetFeedbackById(id);
                if (o != null)
                {
                    _context.Feedbacks.Remove(o);
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

        public List<Feedback> GetAllFeedbacks() => _context.Feedbacks.ToList();

        public Feedback GetFeedbackById(int id) => _context.Feedbacks.SingleOrDefault(x => x.Feedback_Id == id);

        public bool UpdateFeedback(Feedback o)
        {
            bool isSucess = false;
            try
            {
                isSucess = true;
                _context.Feedbacks.Update(o);
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
