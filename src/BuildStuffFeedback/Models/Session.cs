using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace BuildStuffFeedback.Models
{
    [TableName("Sessions")]
    [PrimaryKey("Id")]
    public partial class Session
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("SessionId")]
        public string SessionId { get; set; }

        [Column("Title")]
        public String Title { get; set; }

        [Column("Speaker")]
        public String Speaker { get; set; }

        [Column("Email")]
        public String Email { get; set; }

        public Feedback Feedback { get; set; }
    }
}
