using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IFeedbackRepo
    {
        bool CreateFeedback(Feedback o);
        bool DeleteFeedback(int id);
        List<Feedback> GetAllFeedbacks();
        Feedback GetFeedbackById(int id);
        bool UpdateFeedback(Feedback o);
    }
}
