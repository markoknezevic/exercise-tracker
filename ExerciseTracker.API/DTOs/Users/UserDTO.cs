using System;
using Newtonsoft.Json;

namespace ExerciseTracker.API.DTOs.Users
{
    public class UserDTO
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}