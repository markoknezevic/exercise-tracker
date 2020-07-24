using System.Collections.Generic;
using System.Threading.Tasks;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories.WorkoutRecords
{
    public interface IWorkoutRecordsRepository : IRepository<WorkoutRecord, long>
    {
        Task<WorkoutRecord> AddWorkoutRecordAsync(WorkoutRecord workoutRecord);
        
        WorkoutRecord AddWorkoutRecord(WorkoutRecord workoutRecord);

        Task<bool> IsAnyWorkoutRecordExistsAsync(long workoutId);
        
        bool IsAnyWorkoutRecordExists(long workoutId);

        Task<List<WorkoutRecord>> GetWorkoutRecordsByWorkoutIdAsync(long workoutId);
        
        List<WorkoutRecord> GetWorkoutRecordsByWorkoutId(long workoutId);
    }
}