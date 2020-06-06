using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("candidate")]
    public class Candidate
    {

        [Column("user_id")]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Column("acceleration_id")]
        public int Acceleration_Id { get; set; }

        [ForeignKey("AccelerationId")]
        public virtual Acceleration Acceleration { get; set; }

        [Column("company_id")]   
        public int Company_Id { get; set; }

        [ForeignKey("Company_Id")]
        public virtual Company Company { get; set; }

        [Required]
        [Column("status")]
        public int Status { get; set; }

        [Required]
        [Timestamp]
        [Column("created_at")]
        public DateTime created_at { get; set; }
    }
}
