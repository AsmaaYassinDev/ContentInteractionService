using ContentInteractionService.Model;

namespace ContentInteractionService.Interfaces
{
    public interface IRatingService
    {
        Task<Rating> AddRatingAsync(Rating rating);
        Task<double> GetAverageRatingAsync(string imageId);
    }
}
