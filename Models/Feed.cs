using System;
using System.ComponentModel.DataAnnotations;

namespace teamWcrh.Models
{
    public class Feed
    {
        public int FeedId { get; set; }
        [StringLength(255)]
        public string FeedPic { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Message { get; set; }
        public string Status { get; set; }
        public bool Spam { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}