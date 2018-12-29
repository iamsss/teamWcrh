namespace teamWcrh.Controllers.Resources
{
    public class AuthenticateResource
    {
        public UserResource UserResource { get; set; }
        public bool Status { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}