using System.Collections;
using System.Collections.Generic;
using BuildStuffFeedback.Models.Admin;

namespace BuildStuffFeedback.ViewModels
{
    public class AdminSessionsViewModel : IEnumerable<SessionSummary>
    {
        private readonly IEnumerable<SessionSummary> _sessions;

        public AdminSessionsViewModel(IEnumerable<SessionSummary> sessions)
        {
            _sessions = sessions;
        }

        public IEnumerator<SessionSummary> GetEnumerator()
        {
            return _sessions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}