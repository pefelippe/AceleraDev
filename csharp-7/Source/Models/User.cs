using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("full_name")]
        [MaxLength(100)]
        public string full_name { get; set; }

        [Required]
        [Column("email")]
        [MaxLength(100)]
        public string email { get; set; }

        [Required]
        [Column("nickname")]
        [MaxLength(50)]
        public string nickname { get; set; }

        [Required]
        [Column("password")]
        [MaxLength(255)]
        public string password { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime created_at { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
    }
}

