using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("company")]
    public class Company
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(100)]
        public string name { get; set; }

        [Required]
        [Column("slug")]
        [MaxLength(50)]
        public string slug { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime created_at { get; set; }

        public virtual ICollection<Candidate> Candidates {get; set;}
    }

}