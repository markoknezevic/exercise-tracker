using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseTracker.Data.Entities
{
    [Table("workout_records")]
    public class WorkoutRecord : TimestampedEntity<long>
    {
        [Key]
        [Column("id", Order = 1)]
        public override long Id { get; set; }
        
        [Required]
        [Column("user_id", Order = 2)]
        public long UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }
        
        [Required]
        [Column("workout_id", Order = 3)]
        public long WorkoutId { get; set; }
        
        [ForeignKey("WorkoutId")]
        public Workout Workout { get; set; }
    }
}