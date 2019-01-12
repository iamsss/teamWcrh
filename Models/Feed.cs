using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teamWcrh.Models
{
    public class Feed
    {
        public int FeedId { get; set; }
        [StringLength(255)]
        public string FeedUserPic { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Message { get; set; }
        public string Status { get; set; }
        public bool Spam { get; set; }
        public string CreatedOn { get; set; }
        public int? ProjectId  { get; set; }
        public Project Project { get; set; }

        public int? UserId {get; set;}
        public User User { get; set; }

        public int? EventId {get; set;}
        public Event Event { get; set; }
        

    }
}