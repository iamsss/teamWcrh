using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace teamWcrh.Controllers.Resources.Event
{
    public class EventResource
    {
         public int EventId { get; set; }
        [Required]
        [StringLength(50)]
        public string  Name { get; set; }
        public IFormFile ImageFile { get; set; }
        
        public string Description { get; set; }
        [Required]
        [StringLength(100)]
        public string Location { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        [StringLength(20)]
        public string StartTime { get; set; }
        [StringLength(20)]
        public string ProjectId { get; set; }
        public string EndTime { get; set; }
        public string CreatedOn { get; set; }
        public int CreatedBy { get; set; }

    }
}