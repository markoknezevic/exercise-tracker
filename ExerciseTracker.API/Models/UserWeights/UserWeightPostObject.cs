using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ExerciseTracker.API.Models.UserWeights
{
    public class UserWeightPostObject
    {
        [Required]
        [JsonProperty("value")]
        public double Value { get; set; }
        
        [Required]
        [JsonProperty("user_id")]
        public long UserId { get; set; }
    }
}