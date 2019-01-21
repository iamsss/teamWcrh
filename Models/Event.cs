using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace teamWcrh.Models
{
    public class Event
    {
        public int EventId { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [Required]
        [StringLength(50)]
        public string  Name { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        [StringLength(100)]
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [StringLength(20)]
        public string StartTime { get; set; }
        [StringLength(20)]
        public string EndTime { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<UserEvent> UserEvents { get; set; }

        public Event(){
            UserEvents = new Collection<UserEvent>(); 
        }
        
    }
}