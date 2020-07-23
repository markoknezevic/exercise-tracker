using System.Threading.Tasks;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories.WorkoutRecords
{
    public interface IWorkoutRecordsRepository : IRepository<WorkoutRecord, long>
    {
        Task<WorkoutRecord> AddWorkoutRecordAsync(WorkoutRecord workoutRecord);
        
        WorkoutRecord AddWorkoutRecord(WorkoutRecord workoutRecord);
    }
}