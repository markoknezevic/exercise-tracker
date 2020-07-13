using System.ComponentModel.DataAnnotations;
using ExerciseTracker.API.DTOs.Exercises;
using Newtonsoft.Json;

namespace ExerciseTracker.API.Models.ExerciseWorkouts
{
    public class ExerciseWorkoutPostObject
    {
        [Required]
        [JsonProperty("series_number")]
        public int SeriesNumber { get; set; }
        
        [Required]
        [JsonProperty("repeats")]
        public int Repeats { get; set; }
        
        [JsonProperty("weight_value")]
        public double WeightValue { get; set; }

        [Required]
        [JsonProperty("exercise_id")]
        public long ExerciseId { get; set; }
        
        [Required]
        [JsonProperty("workout_id")]
        public long WorkoutId { get; set; }
    }
}