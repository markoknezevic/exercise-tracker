using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseTracker.Data.Entities
{
    [Table("users")]
    public class User : TimestampedEntity<long>
    {
        [Key] [Column("id", Order = 1)] public override long Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("first_name", Order = 2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("last_name", Order = 3)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("email", Order = 4)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("password", Order = 5)]
        public string Password { get; set; }

        [Required]
        [Column("date_of_birth", Order = 6)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Column("status_id", Order = 7)]
        public short StatusId { get; set; }

        [ForeignKey("StatusId")] 
        public Status Status { get; set; }

        public ICollection<UserWeight> UserWeights { get; set; }
    }
}