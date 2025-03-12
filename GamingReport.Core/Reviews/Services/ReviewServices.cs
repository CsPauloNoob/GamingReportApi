using GamingReport.Core._Game;
using GamingReport.Core.Interfaces;
using GamingReport.Core.Reviews.Interfaces;

namespace GamingReport.Core.Reviews.Services
{
    public class ReviewServices : IReviewService
    {
        private readonly IRepository<Review> _reviewCtx;
        private readonly IRepository<Game> _gameCtx;

        public ReviewServices(IRepository<Review> reviewCtx, IRepository<Game> gameCtx)
        {
            _reviewCtx = reviewCtx;
            _gameCtx = gameCtx;
        }

        public void AddReview(Review review)
        {
            _reviewCtx.Add(review);
        }

        public void DeleteReview(Review review)
        {
            _reviewCtx.Delete(review);
        }

        public Review GetReviewById(string id)
        {
            return _reviewCtx.GetById(id);
        }

        public void UpdateReview(Review review)
        {
            _reviewCtx.Update(review);
        }

        public Review GetReviewByGameName(string gameName)
        {
            var review = _reviewCtx.GetByCondition(r => r.) 
            
            return review;
        }
    }
}