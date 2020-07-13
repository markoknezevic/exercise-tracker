using System;
using ExerciseTracker.API.DTOs.Exercises;
using Newtonsoft.Json;

namespace ExerciseTracker.API.DTOs.ExerciseWorkouts
{
    public class ExerciseWorkoutDTO
    {
        [JsonProperty("series_number")]
        public int SeriesNumber { get; set; }
        
        [JsonProperty("repeats")]
        public int Repeats { get; set; }
        
        [JsonProperty("weight_value")]
        public double WeightValue { get; set; }
        
        [JsonProperty("workout_id")]
        public long WorkoutId { get; set; }
        
        [JsonProperty("exercise")]
        public ExerciseDTO Exercise { get; set; }
        
        [JsonProperty("status")]
        public String Status { get; set; }
    }
}