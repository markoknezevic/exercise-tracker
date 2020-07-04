using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ExerciseTracker.API.Models.Users
{
    public class RegisterUserPostObject
    {
        [Required]
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        
        [Required]
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        
        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
        
        [Required]
        [JsonProperty("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
    }
}