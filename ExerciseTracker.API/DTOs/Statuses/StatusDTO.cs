using Newtonsoft.Json;

namespace ExerciseTracker.API.DTOs.Statuses
{
    public class StatusDTO
    {
        [JsonProperty("id")]
        public short Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}