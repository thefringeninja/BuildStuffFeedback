using System.Collections.Generic;
using Nancy.ViewEngines.Razor;

namespace BuildStuffFeedback
{
    public class RazorConfig : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            yield return "BuildStuffFeedback";
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            yield return "BuildStuffFeedback";
        }

        public bool AutoIncludeModelNamespace
        {
            get { return true; }
        }
    }
}