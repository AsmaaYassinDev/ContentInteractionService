using ContentInteractionService.Interfaces;
using ContentInteractionService.Model;

namespace ContentInteractionService.Service
{
    public class RatingService : IRatingService
    {
        private readonly IContentService _contentService;

        public RatingService(IContentService contentService)
        {
            _contentService = contentService;
        }

        public async Task<Rating> AddRatingAsync(Rating rating)
        {
            var imageMetadata = await _contentService.GetImageMetadataAsync(rating.ImageId);

            rating.ImageTitle = imageMetadata.Title;
            rating.ImageCaption = imageMetadata.Caption;
            rating.ImageLocation = imageMetadata.Location;

            rating.Id = Guid.NewGuid().ToString();
            rating.CreatedAt = DateTime.UtcNow;

            // Save the rating to DB (Repository layer should be called here)
            // await _ratingRepository.AddRatingAsync(rating);
            return rating;
        }

        public async Task<double> GetAverageRatingAsync(string imageId)
        {
            // Fetch ratings from the repository
            // var ratings = await _ratingRepository.GetRatingsAsync(imageId);
            // For simplicity, returning a hardcoded average here
            return 4.5;
        }
    }
}
