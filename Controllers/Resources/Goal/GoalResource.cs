using System;
using System.ComponentModel.DataAnnotations;

namespace teamWcrh.Controllers.Resources.Goal
{
    public class GoalResource
    {
        public int GoalId { get; set; }
        [Required]
        public string Name { get; set; }
        public string GoalFor { get; set; } // Contain String Of Id Of User like -> 1# 2# 5#
        public  string GoalJoinedBy { get; set; } 
        public  int ProjectId { get; set; }
        public string Description { get; set; }
        public string GoalType { get; set; } // All,Project Specific,Other
        public  string Deadline { get; set; }
        public string ExpiresOn { get; set; } // Date After which no one can Join the goal
        public int CreatedBy { get; set; }
        public int PriorityLevel { get; set; } // 1 to 5
    }
}
