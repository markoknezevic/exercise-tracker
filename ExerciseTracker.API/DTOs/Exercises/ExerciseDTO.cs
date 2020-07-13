using Newtonsoft.Json;

namespace ExerciseTracker.API.DTOs.Exercises
{
    public class ExerciseDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}