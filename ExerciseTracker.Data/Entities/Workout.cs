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
        
        public ICollection<WorkoutRecord> WorkoutRecords { get; set; }
        
        public ICollection<ExerciseWorkout> ExerciseWorkouts { get; set; }
    }
}