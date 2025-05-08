using ContentInteractionService.Interfaces;
using ContentInteractionService.Model;

namespace ContentInteractionService.Service
{
    public class CommentService : ICommentService
    {
        private readonly IContentService _contentService;

        public CommentService(IContentService contentService)
        {
            _contentService = contentService;
        }

        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            var imageMetadata = await _contentService.GetImageMetadataAsync(comment.ImageId);

            comment.ImageTitle = imageMetadata.Title;
            comment.ImageCaption = imageMetadata.Caption;
            comment.ImageLocation = imageMetadata.Location;

            comment.Id = Guid.NewGuid().ToString();
            comment.CreatedAt = DateTime.UtcNow;

            // Save the comment to DB (Repository layer should be called here)
            // await _commentRepository.AddCommentAsync(comment);
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync(string imageId)
        {
            // Fetch comments from the repository
            // var comments = await _commentRepository.GetCommentsAsync(imageId);
            // For simplicity, returning an empty list here
            return new List<Comment>();
        }
    }
}
