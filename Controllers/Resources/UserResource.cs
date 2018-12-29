using System.ComponentModel.DataAnnotations;

namespace teamWcrh.Controllers.Resources
{
    public class UserResource
    {
        public int UserId { get; set; }
        public int UserName { get; set; }
        public int Rp { get; set; }
        public int Cp { get; set; }
        
        public string UserRole { get; set; }
        
        public string Email { get; set; }
        
        public string Address { get; set; }
        
        public string MobileNo { get; set; }
        
        public string WtsUpNo { get; set; }
        
        public string Quote { get; set; }
        
        public string PrimaryOccupation { get; set; }
        
        public string SecondaryOccupation { get; set; }
        
        public string AboutMe { get; set; }
        
        public string Skill1Title { get; set; }
        
        public string Skill2Title { get; set; }
        
        public string Skill3Title { get; set; }
        
        public string Skill1Details { get; set; }
        
        public string Skill2Details { get; set; }
        
 
        public string Skill3Details { get; set; }

        public string MessageTitle { get; set; }

        public string Message { get; set; }
       
        public string ProfileUrl { get; set; }
        public string GalleryImage { get; set; }
    }
}