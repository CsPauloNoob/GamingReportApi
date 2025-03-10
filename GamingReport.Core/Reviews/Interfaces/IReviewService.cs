using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingReport.Core.Reviews.Interfaces
{
    public interface IReviewService
    {
        void AddReview(Review review);

        Review GetReviewById(string id);

        void DeleteReview(Review review);

        void UpdateReview(Review review);
    }
}
