namespace ContentInteractionService.Model
{
    public class Comment
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ImageId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImageTitle { get; set; }
        public string ImageCaption { get; set; }
        public string ImageLocation { get; set; }
    }
}
