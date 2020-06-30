using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseTracker.Data.Entities
{
    [Table("exercise_workouts")]
    public class ExerciseWorkout : TimestampedEntity<long>
    {
        [Key]
        [Column("id")]
        public override long Id { get; set; }
        
        [Required]
        [Column("series_number")]
        public int SeriesNumber { get; set; }
        
        [Required]
        [Column("repeats")]
        public int Repeats { get; set; }
        
        [Column("weight_value")]
        public double WeightValue { get; set; }
        
        [Required]
        [Column("workout_id")]
        public long WorkoutId { get; set; }
        
        [ForeignKey("WorkoutId")]
        public Workout Workout { get; set; }
        
        [Required]
        [Column("exercise_id")]
        public long ExerciseId { get; set; }
        
        [ForeignKey("ExerciseId")]
        public Exercise Exercise { get; set; }
    }
}