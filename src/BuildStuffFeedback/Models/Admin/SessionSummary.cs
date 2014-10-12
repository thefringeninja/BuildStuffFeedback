using System;

namespace BuildStuffFeedback.Models.Admin
{
    public class SessionSummary
    {
        public int Id { get; set; }

        public string SessionId { get; set; }

        public String Title { get; set; }

        public String Speaker { get; set; }
    }

    public class SessionDetail
    {
        public int Id { get; set; }

        public string SessionId { get; set; }

        public String Title { get; set; }

        public String Speaker { get; set; }

        public string Email { get; set; }
    }

    public enum Level
    {
        Red,
        Yellow,
        Green
    }
}