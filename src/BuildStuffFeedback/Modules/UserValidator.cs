using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.Authentication.Basic;
using Nancy.Security;


namespace BuildStuffFeedback.Modules
{

    public class SampleUserIdentity : IUserIdentity
    {
        public SampleUserIdentity(string userName)
        {
            UserName = userName;
        }

        public IEnumerable<string> Claims
        {
            get { throw new NotImplementedException(); }
        }

        public string UserName { get; private set; }
    }

    public class UserValidator : IUserValidator
    {
        public IUserIdentity Validate(string username, string password)
        {
            if (username == "demo" && password == "demo")
            {
                return new SampleUserIdentity(username);
            }

            return null;
        }
    }

}
