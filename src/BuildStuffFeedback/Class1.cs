using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Hosting.Self;

namespace BuildStuffFeedback
{
    public class Program
    {
        const string DOMAIN = "http://localhost:8888";
        static void Main(string[] args)
        {
            // create a new self-host server
            NancyHost nancyHost = new Nancy.Hosting.Self.NancyHost(new HostConfiguration(){UrlReservations = new UrlReservations(){CreateAutomatically = true}},new Uri(DOMAIN));
            // start
            nancyHost.Start();
            Console.WriteLine("REST service listening on " + DOMAIN);
            // stop with an <Enter> key press
            Console.ReadLine();
            nancyHost.Stop();
        }
    }

    public class Bootstrapper : Nancy.DefaultNancyBootstrapper
    {
        protected virtual Nancy.Bootstrapper.NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return Nancy.Bootstrapper.NancyInternalConfiguration.Default;
            }
        }
    }
}
