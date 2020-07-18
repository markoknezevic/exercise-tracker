using Newtonsoft.Json;

namespace ExerciseTracker.API.DTOs.Exercises
{
    public class ExerciseDTO
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}