using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ExerciseTracker.API.Models.WorkoutRecords
{
    public class WorkoutRecordPostObject
    {
        [Required]
        [JsonProperty("workout_id")]
        public long WorkoutId { get; set; }
    }
}