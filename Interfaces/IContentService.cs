using ContentInteractionService.Model;

namespace ContentInteractionService.Interfaces
{
    public interface IContentService

    {
        Task<ContentItem> GetImageMetadataAsync(string imageId);
    }
}
