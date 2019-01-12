using System;

namespace teamWcrh.Controllers.Resources.Goal
{
    public class GoalResource
    {
        public int GoalId { get; set; }
        public string Name { get; set; }
        public string GoalFor { get; set; } // Contain String Of Id Of User like -> 1# 2# 5#
        public string Description { get; set; }
        public string GoalType { get; set; } // All,Project Specific,Other
        public  DateTime Deadline { get; set; }
        public int PriorityLevel { get; set; } // 1 to 5
    }
}