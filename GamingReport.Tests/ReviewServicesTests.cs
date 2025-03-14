using GamingReport.Core._Game;
using GamingReport.Core.Interfaces;
using GamingReport.Core.Reviews;
using GamingReport.Core.Reviews.Services;
using Moq;
using Xunit;

namespace GamingReport.Tests
{
    public class ReviewServicesTests
    {
        private readonly Mock<IRepository<Review>> _mockReviewRepository;
        private readonly Mock<IRepository<Game>> _mockGameRepository;
        private readonly ReviewServices _reviewServices;

        public ReviewServicesTests()
        {
            _mockReviewRepository = new Mock<IRepository<Review>>();
            _mockGameRepository = new Mock<IRepository<Game>>();
            
            _reviewServices = new ReviewServices(_mockReviewRepository.Object,
                _mockGameRepository.Object);
        }

        [Fact]
        public void AddReview_ShouldCallAddMethodOfRepository()
        {
            // Arrange
            var review = new Review { Title = "Test Review", Content = "Test Content", Score = 5.0m };

            // Act
            _reviewServices.AddReview(review);

            // Assert
            _mockReviewRepository.Verify(r => r.Add(It.IsAny<Review>()), Times.Once);
        }
    }
}