using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("acceleration")]
    public class Acceleration
    {
        
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column("slug")]
        [MaxLength(50)]
        public string Slug { get; set; }

        [Column("challenge_id")]
        public int Challenge_Id { get; set; }

        [Required]
        [Timestamp]
        [Column("created_at")]
        public DateTime created_At { get; set; }

        [ForeignKey("ChallengeId")]
        public virtual Challenge Challenge { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }
    }
}
