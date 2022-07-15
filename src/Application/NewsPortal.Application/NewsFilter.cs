using NewsPortal.Domain;

namespace NewsPortal.Application
{
    public class NewsFilter
    {
        public Country Country { get; set; }
        public bool? Important { get; set; }
    }
}
