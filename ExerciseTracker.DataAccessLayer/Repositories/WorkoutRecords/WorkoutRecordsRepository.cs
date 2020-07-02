using ExerciseTracker.Data;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories.WorkoutRecords
{
    public class WorkoutRecordsRepository : Repository<WorkoutRecord, long>, IWorkoutRecordsRepository
    {
        private readonly ExerciseTrackerDbContext _exerciseTrackerDbContext;
        
        public WorkoutRecordsRepository(ExerciseTrackerDbContext exerciseTrackerDbContext) : base(exerciseTrackerDbContext)
        {
            _exerciseTrackerDbContext = exerciseTrackerDbContext;
        }
    }
}