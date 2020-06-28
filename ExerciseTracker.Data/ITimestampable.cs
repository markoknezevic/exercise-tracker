using System;

namespace ExerciseTracker.Data
{
    public interface ITimestampable
    {
        DateTime CreatedAt { get; set; }
        
        DateTime UpdatedAt { get; set; }
    }
}