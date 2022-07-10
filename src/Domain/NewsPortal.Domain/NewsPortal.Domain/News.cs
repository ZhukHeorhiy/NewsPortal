namespace NewsPortal.Domain
{
    public class News
    {
        public string Author { get; }
        public string Title { get; }
        public string Description { get; }
        public string Url { get; }
        public string ImageUrl { get; }
        public DateTime PublishedAt { get; }
        public string Content { get; }

        public News(string author, string title, string description, string url, string imageUrl, DateTime publishedAt, string content)
        {
            Author = author ?? throw new ArgumentNullException(nameof(author));
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            ImageUrl = imageUrl ?? throw new ArgumentNullException(nameof(imageUrl));
            Content = content ?? throw new ArgumentNullException(nameof(content));

            if (string.IsNullOrEmpty(url)) throw new ApplicationException("Url can't be empty.");
            if (!url.Contains("https://")) throw new ApplicationException("Wrong url format.");
            if (publishedAt.Year < 2000) throw new ApplicationException("Content is outdated.");

            PublishedAt = publishedAt;
            Url = url;
        }

        public bool IsImportant() => Title.ToLower().Contains("war") && Title.ToLower().Contains("czech");
    }
}
