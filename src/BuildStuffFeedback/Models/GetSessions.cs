using System.Collections.Generic;
using BuildStuffFeedback.Models.Admin;

namespace BuildStuffFeedback.Models
{
    public delegate IEnumerable<SessionSummary> GetSessions();

    public delegate SessionDetail GetSession(string id);
}