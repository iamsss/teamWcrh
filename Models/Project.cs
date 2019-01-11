using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace teamWcrh.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [StringLength(25)]
        public string Status { get; set; }
        
        public ICollection<UserProject> UserProjects { get; set; }

        public Project(){
            UserProjects =  new Collection<UserProject>();          
        }

    }
}