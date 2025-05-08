using ContentInteractionService.Interfaces;
using ContentInteractionService.Model;
using Microsoft.Azure.Cosmos;

namespace ContentInteractionService.Service
{
    public class ContentService : IContentService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public ContentService(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
            _container = _cosmosClient.GetContainer("your-database-name", "Images");
        }

        public async Task<ContentItem> GetImageMetadataAsync(string imageId)
        {
            var query = new QueryDefinition("SELECT * FROM c WHERE c.Id = @imageId")
                .WithParameter("@imageId", imageId);

            var resultSet = _container.GetItemQueryIterator<ContentItem>(query);
            var results = await resultSet.ReadNextAsync();

            return results.FirstOrDefault();
        }
    }
}
