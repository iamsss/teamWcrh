using System;

namespace teamWcrh.Models
{
    public class UserGoal
    {
    public int GoalForUserId { get; set; }
    public  DateTime JoinedOn { get; set; }
    public string  Status { get; set; } // must be enum
    public  string  Message { get; set; } // For Self Review Of Goal
    public int UserId { get; set; }
    public User User { get; set; }

    public int GoalId { get; set; }
    public Goal Goal { get; set; }
    }
}