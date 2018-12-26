namespace teamWcrh.Models
{
    public class JoinRequest
    {
        public int JoinRequestId { get; set; }
        public string Name { get; set; }

        public string skill { get; set; }
        public int? ProjectInterestedIn { get; set; }

        public string Message { get; set; }

        public string MobileNo { get; set; }

    }
}