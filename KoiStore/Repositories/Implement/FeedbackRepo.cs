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
    public class FeedbackRepo : IFeedbackRepo
    {
        public bool CreateFeedback(Feedback o) => FeedbackDAO.Instance.CreateFeedback(o);

        public bool DeleteFeedback(int id) => FeedbackDAO.Instance.DeleteFeedback(id);

        public List<Feedback> GetAllFeedbacks() => FeedbackDAO.Instance.GetAllFeedbacks();

        public Feedback GetFeedbackById(int id) => FeedbackDAO.Instance.GetFeedbackById(id);

        public bool UpdateFeedback(Feedback o) => FeedbackDAO.Instance.UpdateFeedback(o);
    }
}
