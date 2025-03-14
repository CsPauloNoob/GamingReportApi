using Microsoft.AspNetCore.Mvc;
using GamingReport.Core.Reviews.Interfaces;

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

        [HttpGet]
        public async Task<IActionResult> GetLastReviews(int pageSize = 5)
        {
            _reviewServices
        }

        [HttpGet("/get/{id}")]
        public IActionResult GetById(string id)
        {
            var review = _reviewServices.GetReviewById(id);
            
            return Ok(review);
        }

        [HttpGet("/get-gamename/{game-name}")]
        public IActionResult GetByGameName(string gameName)
        {
            var review = _reviewServices.GetReviewByGameName(gameName);
            return Ok(review);
        }
        //TODO: Implementar mapster, implementar padrão de retorno.

    }
}