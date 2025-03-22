using GamingReport.Core;
using GamingReport.Core.Reviews;
using Microsoft.AspNetCore.Mvc;
using GamingReport.Core.Reviews.Interfaces;
using GamingReportApi.InputModels;
using GamingReportApi.ViewModels;
using Mapster;

namespace GamingReportApi.Controllers
{
    [ApiController]
    [Route("api/review")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewServices;

        public ReviewController(IReviewService reviewServices)
        {
            _reviewServices = reviewServices;
        }

        #region GetRegion
        
        [HttpGet]
        public async Task<IActionResult> GetLastReviews(int pageSize = 5)
        {
            return Ok();
        }

        [HttpGet("/get/{id}")]
        public IActionResult GetById(string id)
        {
            var review = _reviewServices.GetReviewById(id);
            
            return Ok(review);
        }

        [HttpGet("/get-from/{gameName}")]
        public IActionResult GetByGameName(string gameName)
        {
            var response = _reviewServices.GetReviewByGameName(gameName);

            var mappedResponse = response.Data != null
                ? ServiceResponse<ReviewVM>.Success(response.Data.Adapt<ReviewVM>())
                : ServiceResponse<ReviewVM>.Error(response.Message??"Unknown Error");

            return mappedResponse.Status switch
            {
                ResponseStatus.Succes => Ok(mappedResponse),
                ResponseStatus.Error => NotFound(mappedResponse),
                _ => BadRequest(mappedResponse)
            };
        }
        
        #endregion


        #region PostRegion

        [HttpPost]
        public async Task<IActionResult> PostReview(ReviewIM inputReview)
        {
            var review = inputReview.Adapt<Review>();
            _reviewServices.AddReview(review);
            return Created();
        }

        #endregion

    }
}