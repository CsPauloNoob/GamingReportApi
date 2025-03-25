using GamingReport.Core._Game;
using GamingReport.Core.Interfaces;
using GamingReport.Core.Response;
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

        public ServiceResponse<bool> AddReview(Review review)
        {
            review.Id = Guid.NewGuid().ToString();
            
            _reviewCtx.Add(review);

            return ServiceResponse<bool>.Success(true);
        }

        public ServiceResponse<bool> DeleteReview(Review review)
        {
            _reviewCtx.Delete(review);

            return ServiceResponse<bool>.Success(true);
        }

        public ServiceResponse<Review> GetReviewById(string id)
        {
            Review review = _reviewCtx?.GetById(id);
            
            if(review is null)
                return ServiceResponse<Review>.NotFound();
            
            return ServiceResponse<Review>.Success(review);
        }

        public List<Review> GetReviews(int maxReviews)
        {
            return new();
        }

        public ServiceResponse<bool> UpdateReview(Review review)
        {
            _reviewCtx.Update(review);
            
            return ServiceResponse<bool>.Success(true);
        }

        public ServiceResponse<Review> GetReviewByGameName(string gameName)
        {
            Game game = _gameCtx?.GetByName(gameName);

            if(game is null)
                return ServiceResponse<Review>.NotFound("Game not found");

            Review review = _reviewCtx.GetWithRelatedItens(game.Id, "GameId").FirstOrDefault()!;

            return ServiceResponse<Review>.Success(review);
        }
    }
}