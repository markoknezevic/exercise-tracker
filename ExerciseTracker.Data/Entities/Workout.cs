using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseTracker.Data.Entities
{
    [Table("workouts")]
    public class Workout : TimestampedEntity<long>
    {
        [Key]
        [Column("id", Order = 1)]
        public override long Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        [Column("name", Order = 2)]
        public string Name { get; set; }
        
        [MaxLength(255)]
        [Column("description", Order = 3)]
        public string Description { get; set; }
        
        [Required]
        [Column("user_id", Order = 2)]
        public long UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }
        
        [Required]
        [Column("status_id")]
        public short StatusId { get; set; }
        
        [ForeignKey("StatusId")]
        public Status Status { get; set; }

        public ICollection<WorkoutRecord> WorkoutRecords { get; set; }
        
        public ICollection<ExerciseWorkout> ExerciseWorkouts { get; set; }
    }
}