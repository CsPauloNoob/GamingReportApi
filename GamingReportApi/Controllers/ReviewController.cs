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

        [HttpGet("/get")]
        public IActionResult GetById()
        {
            var reviews = _reviewServices.GetReviewById("10a9521d-fdeb-4ebd-ab05-c6a980a65f88");
            return Ok(reviews);
        }

        [HttpGet("/get/{gameName}")]
        public IActionResult GetByGameName(string gameName)
        {
            var review = _reviewServices.GetReviewByGameName(gameName);
            return Ok(review);
        }
        //TODO: Implementar mapster, implementar padrão de retorno.

    }
}