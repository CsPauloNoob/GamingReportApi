using GamingReport.Core.Interfaces;
using GamingReport.Core.Reviews.Interfaces;

namespace GamingReport.Core.Reviews.Services
{
    public class ReviewServices : IReviewService
    {
        private readonly IRepository<Review> _context;

        public ReviewServices(IRepository<Review> repository)
        {
            _context = repository;
        }

        public void AddReview(Review review)
        {
            _context.Add(review);
        }

        public void DeleteReview(Review review)
        {
            _context.Delete(review);
        }

        public Review GetReviewById(string id)
        {
            return _context.GetById(id);
        }

        public void UpdateReview(Review review)
        {
            _context.Update(review);
        }
    }
}