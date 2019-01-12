namespace teamWcrh.Models
{
    public class UserGoal
    {
    public int UserId { get; set; }
    public User User { get; set; }

    public int GoalId { get; set; }
    public Goal Goal { get; set; }
    }
}