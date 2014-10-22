using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildStuffFeedback.Models
{
    public  class Session
    {
        public int Id { get; set; }

        public String Title { get; set; }

        public String Speaker { get; set; }

        public String Email { get; set; }

        public Feedback Feedback { get; set; }
    }
}
