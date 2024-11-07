using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IRatingRepo
    {
        bool CreateRating(Rating o);
        bool DeleteRating(int id);
        List<Rating> GetAllRatings();
        Rating GetRatingById(int id);
        bool UpdateRating(Rating o);
    }
}
