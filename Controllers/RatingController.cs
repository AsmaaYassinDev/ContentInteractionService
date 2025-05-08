using ContentInteractionService.Interfaces;
using ContentInteractionService.Model;
using Microsoft.AspNetCore.Mvc;

namespace ContentInteractionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        public async Task<IActionResult> AddRating(Rating rating)
        {
            var addedRating = await _ratingService.AddRatingAsync(rating);
            return CreatedAtAction(nameof(AddRating), new { id = addedRating.Id }, addedRating);
        }

        [HttpGet("{imageId}/average")]
        public async Task<IActionResult> GetAverageRating(string imageId)
        {
            var averageRating = await _ratingService.GetAverageRatingAsync(imageId);
            return Ok(averageRating);
        }
    }
}