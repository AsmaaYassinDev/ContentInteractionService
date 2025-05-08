using ContentInteractionService.Interfaces;
using ContentInteractionService.Model;
using Microsoft.Azure.Cosmos;

namespace ContentInteractionService.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _ratingsContainer;

        public RatingRepository(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
            var database = _cosmosClient.GetDatabase("CommentsRatingsDB");
            _ratingsContainer = database.GetContainer("RatingsContainer");
        }

        public async Task<Rating> AddRatingAsync(Rating rating)
        {
            var response = await _ratingsContainer.CreateItemAsync(rating, new PartitionKey(rating.ImageId));
            return response.Resource;
        }

        public async Task<double> GetAverageRatingAsync(string imageId)
        {
            var query = new QueryDefinition("SELECT AVG(c.RatingValue) FROM c WHERE c.ImageId = @imageId")
                            .WithParameter("@imageId", imageId);

            var iterator = _ratingsContainer.GetItemQueryIterator<double>(query);
            var resultSet = await iterator.ReadNextAsync();

            return resultSet.FirstOrDefault();
        }
    }
}