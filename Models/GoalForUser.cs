using System;

namespace teamWcrh.Models
{
    public class GoalForUser
    {
        public int GoalForUserId { get; set; }
        public  DateTime JoinedOn { get; set; }
        public string  Status { get; set; }
        public  string  Message { get; set; } // For Self Review Of Goal
        public int GoalId { get; set; }
        public Goal Goal { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}