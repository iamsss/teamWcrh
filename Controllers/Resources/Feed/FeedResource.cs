using System.ComponentModel.DataAnnotations;

namespace teamWcrh.Controllers.Resources.Feed
{
    public class FeedResource
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
        public string CreatedOn { get; set; }
        public int? ProjectId  { get; set; }

        public int? UserId {get; set;}
        public int? EventId {get; set;}
    }
}