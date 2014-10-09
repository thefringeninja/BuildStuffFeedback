using System;
using PetaPoco;

namespace BuildStuffFeedback.Models
{
    [TableName("Feedbacks")]
    [PrimaryKey("Id")]
    public partial class Feedback
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("SessionId")]
        public int SessionId { get; set; }

        [Column("Rating")]
        public int Rating { get; set; }

        [Column("Comments")]
        public String Comments { get; set; }
    }
}