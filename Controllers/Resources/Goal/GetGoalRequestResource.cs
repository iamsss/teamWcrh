using System.Collections.Generic;

namespace teamWcrh.Controllers.Resources.Goal
{
    public class GetGoalRequestResource
    {
        public int UserId { get; set; }
        public List<int> ProjectId { get; set; }

        public GetGoalRequestResource(){
            ProjectId = new List<int>();
        }

    }
}