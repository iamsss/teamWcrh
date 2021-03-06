using System;
using System.ComponentModel.DataAnnotations;

namespace teamWcrh.Models
{
    public class JoinRequest
    {
        public int JoinRequestId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(60)]
        public string Email { get; set; }
        [StringLength(500)]
        public string Skill { get; set; }
        public int? ProjectInterestedIn { get; set; }
        [StringLength(500)]
        public string Message { get; set; }
        [StringLength(15)]
        public string MobileNo { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}