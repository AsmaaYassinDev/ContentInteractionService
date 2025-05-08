using ContentInteractionService.Model;

namespace ContentInteractionService.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> AddCommentAsync(Comment comment);
        Task<IEnumerable<Comment>> GetCommentsAsync(string imageId);
    }
}
