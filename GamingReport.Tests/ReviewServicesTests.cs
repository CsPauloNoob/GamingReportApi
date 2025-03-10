using GamingReport.Core.Interfaces;
using GamingReport.Core.Reviews;
using GamingReport.Core.Reviews.Services;
using Moq;
using Xunit;

namespace GamingReport.Tests
{
    public class ReviewServicesTests
    {
        private readonly Mock<IRepository<Review>> _mockRepository;
        private readonly ReviewServices _reviewServices;

        public ReviewServicesTests()
        {
            _mockRepository = new Mock<IRepository<Review>>();
            _reviewServices = new ReviewServices(_mockRepository.Object);
        }

        [Fact]
        public void AddReview_ShouldCallAddMethodOfRepository()
        {
            // Arrange
            var review = new Review { Title = "Test Review", Content = "Test Content", Score = 5.0f };

            // Act
            _reviewServices.AddReview(review);

            // Assert
            _mockRepository.Verify(r => r.Add(It.IsAny<Review>()), Times.Once);
        }
    }
}