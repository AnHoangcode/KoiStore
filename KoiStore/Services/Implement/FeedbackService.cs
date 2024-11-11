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
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepo _repo = null;

        public FeedbackService()
        {
            if (_repo == null)
            {
                _repo = new FeedbackRepo();
            }
        }
        public bool CreateFeedback(Feedback o) => _repo.CreateFeedback(o);

        public bool DeleteFeedback(int id) => _repo.DeleteFeedback(id);

        public List<Feedback> GetAllFeedbacks() => _repo.GetAllFeedbacks();

        public Feedback GetFeedbackById(int id) => _repo.GetFeedbackById(id);

        public bool UpdateFeedback(Feedback o) => _repo.UpdateFeedback(o);
    }
}
