using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciseTracker.Data;
using ExerciseTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> IsAnyWorkoutRecordExistsAsync(long workoutId)
        {
            var result = await _exerciseTrackerDbContext.WorkoutRecords.AnyAsync(wr => wr.WorkoutId == workoutId);

            return result;
        }

        public bool IsAnyWorkoutRecordExists(long workoutId)
        {
            var result =  _exerciseTrackerDbContext.WorkoutRecords.Any(wr => wr.WorkoutId == workoutId);

            return result;
        }

        public async Task<List<WorkoutRecord>> GetWorkoutRecordsByWorkoutIdAsync(long workoutId)
        {
            var workoutRecords = await _exerciseTrackerDbContext.WorkoutRecords.Where(wr => wr.WorkoutId == workoutId)
                                                                                                .ToListAsync();

            return workoutRecords;
        }

        public List<WorkoutRecord> GetWorkoutRecordsByWorkoutId(long workoutId)
        {
            var workoutRecords =  _exerciseTrackerDbContext.WorkoutRecords.Where(wr => wr.WorkoutId == workoutId)
                                                                                            .ToList();

            return workoutRecords;
        }
    }
}