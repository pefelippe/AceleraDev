using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("submission")]
    public class Submission
    {
        
        [Column("user_id")]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public virtual User User { get; set; }

        [Column("challenge_id")]
        public int Challenge_Id { get; set; }
        
        [ForeignKey("Challenge_Id")]
        public virtual Challenge Challenge { get; set; }

        [Required]
        [Column("score")]
        public decimal score;

        [Required]
        [Column("created_at")]
        public DateTime created_at { get; set; }


    }
}
