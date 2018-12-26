using System.Collections.Generic;

namespace teamWcrh.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        
       public IList<UserProject> UserProjects { get; set; }

    }
}