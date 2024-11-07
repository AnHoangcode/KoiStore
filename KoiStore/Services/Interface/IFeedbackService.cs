using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IFeedbackService
    {
        List<Feedback> GetAllFeedbacks();

        Feedback GetFeedbackById(int id);

        bool DeleteFeedback(int id);

        bool UpdateFeedback(Feedback o);

        bool CreateFeedback(Feedback o);
    }
}
