namespace NewsPortal.Application
{
    public class NewsModel
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Content { get; set; }
        public bool IsImportant { get; set; }
    }
}
