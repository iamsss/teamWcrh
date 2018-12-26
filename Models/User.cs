using System.Collections.Generic;

namespace teamWcrh.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
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
       public IList<UserEvent> UserEvents { get; set; }
       public IList<UserProject> UserProjects { get; set; }

    }
}