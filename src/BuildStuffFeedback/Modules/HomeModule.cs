using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildStuffFeedback.Models;
using BuildStuffFeedback.Providers;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses;

namespace BuildStuffFeedback.Modules
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule()
        {
            var _sessionProvider = new SessionProvider();
            Get["/sessions"] = parameters =>
            {
                return View["Index.cshtml", _sessionProvider.GetAllSessions()];
            };

            Get["/sessions/"] = parameters =>
            {
                return View["Index.cshtml", _sessionProvider.GetAllSessions()];
            };


            Get["/sessions/{id}"] = parameter =>
            {
                return View["Session.cshtml", _sessionProvider.GetSession(parameter.id)];
            };

            Post["/sessions/AddFeedback"] = parameter =>
            {
                var feedback = this.Bind<Feedback>();
                _sessionProvider.AddFeedback(feedback);
                return Response.AsRedirect("/sessions");
            };

        }
    }
}
