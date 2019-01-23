using teamWcrh.Controllers.Resources.User;

namespace teamWcrh.Controllers.Resources
{
    public class AuthenticateResource
    {
        public ProfileResource UserResource { get; set; }
        public bool Status { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}