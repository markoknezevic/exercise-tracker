using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseTracker.Data.Entities
{
    [Table("workouts")]
    public class Workout : TimestampedEntity<long>
    {
        [Key]
        [Column("id")]
        public override long Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        [Column("name")]
        public string Name { get; set; }
        
        [MaxLength(255)]
        [Column("description")]
        public string Description { get; set; }
    }
}