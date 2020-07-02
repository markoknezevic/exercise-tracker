using ExerciseTracker.Data;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories.Statuses
{
    public class StatusesRepository : Repository<Status, short>, IStatusesRepository
    {
        private readonly ExerciseTrackerDbContext _exerciseTrackerDbContext;
        
        public StatusesRepository(ExerciseTrackerDbContext exerciseTrackerDbContext) : base(exerciseTrackerDbContext)
        {
            _exerciseTrackerDbContext = exerciseTrackerDbContext;
        }
    }
}