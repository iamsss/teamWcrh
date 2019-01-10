using System.ComponentModel.DataAnnotations;

namespace teamWcrh.Controllers.Resources.Project
{
    public class ProjectResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
        
