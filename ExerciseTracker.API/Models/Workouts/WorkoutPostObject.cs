using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ExerciseTracker.API.Models.Workouts
{
    public class WorkoutPostObject
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("user_id")]
        public long UserId { get; set; }
    }
}