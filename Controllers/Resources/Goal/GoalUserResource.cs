using System;

namespace teamWcrh.Controllers.Resources.Goal
{
    public class GoalUserResource
    {
    

    public int GoalId { get; set; }    
     public string Name { get; set; }
     public string Description { get; set; }
     public  DateTime Deadline { get; set; }
     public int CreatedBy { get; set; }
    public int PriorityLevel { get; set; } // 1 to 5
    public  DateTime CreatedOn { get; set; }
    public  int? ProjectId {get; set;}
    public string  Status { get; set; } // must be enum
    public  string  Message { get; set; } // For Self Review Of Goal
    public  DateTime JoinedOn { get; set; }
     
    }
}