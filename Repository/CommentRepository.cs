using ContentInteractionService.Interfaces;
using ContentInteractionService.Model;
using Microsoft.Azure.Cosmos;

namespace ContentInteractionService.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _commentsContainer;

        public CommentRepository(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
            var database = _cosmosClient.GetDatabase("CommentsRatingsDB");
            _commentsContainer = database.GetContainer("CommentsContainer");
        }

        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            var response = await _commentsContainer.CreateItemAsync(comment, new PartitionKey(comment.ImageId));
            return response.Resource;
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync(string imageId)
        {
            var query = new QueryDefinition("SELECT * FROM c WHERE c.ImageId = @imageId")
                            .WithParameter("@imageId", imageId);

            var iterator = _commentsContainer.GetItemQueryIterator<Comment>(query);
            var comments = new List<Comment>();

            while (iterator.HasMoreResults)
            {
                var resultSet = await iterator.ReadNextAsync();
                comments.AddRange(resultSet);
            }

            return comments;
        }
    }
}