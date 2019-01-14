using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace teamWcrh.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        public int Rp { get; set; }
        public int Cp { get; set; }

        public string UserRole { get; set; }
        
        [StringLength(100)]
        public string Email { get; set; }
        
        [StringLength(500)]
        public string Address { get; set; }
        
        [StringLength(15)]
        public string MobileNo { get; set; }
        
        [StringLength(15)]
        public string WtsUpNo { get; set; }
        
        [StringLength(500)]
        public string Quote { get; set; }
        
        [StringLength(50)]
        public string PrimaryOccupation { get; set; }
        
        [StringLength(50)]
        public string SecondaryOccupation { get; set; }
        
        [StringLength(1000)]
        public string AboutMe { get; set; }
        
        [StringLength(50)]
        public string Skill1Title { get; set; }
        
        [StringLength(50)]
        public string Skill2Title { get; set; }
        
        [StringLength(50)]
        public string Skill3Title { get; set; }
        
        [StringLength(500)]
        public string Skill1Details { get; set; }
        
        [StringLength(500)]
        public string Skill2Details { get; set; }
        
        [StringLength(500)]
        public string Skill3Details { get; set; }
        
        [StringLength(100)]
        public string MessageTitle { get; set; }
        
        [StringLength(1000)]
        public string Message { get; set; }
        
        [StringLength(255)]
        public string ProfileUrl { get; set; }
        public string GalleryImage { get; set; }

       public ICollection<UserEvent> UserEvents { get; set; }
       
       public ICollection<UserGoal> Goals { get; set; }
       public ICollection<UserProject> UserProjects { get; set; }

      public User()
        {
            UserEvents = new Collection<UserEvent>(); 
            UserProjects = new Collection<UserProject>();     
            Goals = new Collection<UserGoal>();     
    }
}
}