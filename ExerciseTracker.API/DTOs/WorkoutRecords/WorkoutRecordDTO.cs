using System;
using ExerciseTracker.API.DTOs.Workouts;
using ExerciseTracker.Data.Entities;
using Newtonsoft.Json;

namespace ExerciseTracker.API.DTOs.WorkoutRecords
{
    public class WorkoutRecordDTO
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("workout")]
        public WorkoutDTO Workout { get; set; }
        
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}