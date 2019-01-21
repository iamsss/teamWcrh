using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace teamWcrh.Models
{
    public class Goal
    {
        public int GoalId { get; set; }
        public string Name { get; set; }
        public string GoalFor { get; set; } // Contain String Of Id Of User like -> 1# 2# 5#
        public  string GoalJoinedBy { get; set; } // Contains user Id who joined the goal like 1# 2# Extra Work For my covinence
        public string GoalRejectedBy { get; set; } // Contains All user who reject this goal
        public string Description { get; set; }
        public string GoalType { get; set; } // All,Project Specific,Other
        public string EndTime { get; set; } // Time to which goal Ended
        public  DateTime Deadline { get; set; }
        public DateTime ExpiresOn { get; set; } // Date After which no one can Join the goal
        public int CreatedBy { get; set; }
        public int PriorityLevel { get; set; } // 1 to 5
        public  DateTime CreatedOn { get; set; }

        public  int? ProjectId {get; set;}
        public Project Project { get; set; }

       public ICollection<UserGoal> Users { get; set; }

       public Goal(){
           Users = new Collection<UserGoal>();
       }
        




    }
}