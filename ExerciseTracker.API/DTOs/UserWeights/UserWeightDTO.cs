using ExerciseTracker.API.DTOs.Users;
using Newtonsoft.Json;

namespace ExerciseTracker.API.DTOs.UserWeights
{
    public class UserWeightDTO
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }
    }
}