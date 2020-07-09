using Newtonsoft.Json;

namespace ExerciseTracker.API.DTOs.Workouts
{
    public class WorkoutDTO
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("user_id")]
        public long UserId { get; set; }
    }
}