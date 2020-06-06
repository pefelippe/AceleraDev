using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models

{
    [Table("challenge")]
    public class Challenge
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
        [Timestamp]
        [Column("created_at")]
        public DateTime created_at { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
        public virtual ICollection<Acceleration> Accelerations { get; set; }
    

}
}
