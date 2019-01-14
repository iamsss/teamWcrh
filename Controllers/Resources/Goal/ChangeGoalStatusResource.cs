namespace teamWcrh.Controllers.Resources.Goal
{
    public class ChangeGoalStatusResource
    {
        public int GoalId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
    }
}