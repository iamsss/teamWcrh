using System;
using System.Collections.Generic;

namespace teamWcrh.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Image { get; set; }
        public string  Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public IList<UserEvent> UserEvents { get; set; }
        
    }
}