using System;

namespace teamWcrh.Models
{
    public class Feed
    {
        public int FeedId { get; set; }
        public string FeedPic { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}