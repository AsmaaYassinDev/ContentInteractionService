namespace ContentInteractionService.Model
{
    public class Rating
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ImageId { get; set; }
        public int RatingValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImageTitle { get; set; }
        public string ImageCaption { get; set; }
        public string ImageLocation { get; set; }
    }
}
