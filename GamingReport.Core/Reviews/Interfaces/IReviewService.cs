using GamingReport.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingReport.Core.Reviews.Interfaces
{
    public interface IReviewService
    {
        ServiceResponse<bool> AddReview(Review review);

        ServiceResponse<Review> GetReviewById(string id);

        ServiceResponse<bool> DeleteReview(Review review);

        ServiceResponse<bool> UpdateReview(Review review);
        
        ServiceResponse<Review> GetReviewByGameName(string gameName);

        public List<Review> GetReviews(int maxReviews);
    }
}
