using System.Threading.Tasks;
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

        public async Task<WorkoutRecord> AddWorkoutRecordAsync(WorkoutRecord workoutRecord)
        {
            await _exerciseTrackerDbContext.WorkoutRecords.AddAsync(workoutRecord);

            var result = await _exerciseTrackerDbContext.SaveChangesAsync();
            if (result == 0)
            {
                return null;
            }

            return workoutRecord;
        }

        public WorkoutRecord AddWorkoutRecord(WorkoutRecord workoutRecord)
        {
            _exerciseTrackerDbContext.WorkoutRecords.Add(workoutRecord);

            var result = _exerciseTrackerDbContext.SaveChanges();
            if (result == 0)
            {
                return null;
            }

            return workoutRecord;
        }
    }
}