using ExerciseTracker.Data;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories.Workouts
{
    public class WorkoutsRepository : Repository<Workout, long>, IWorkoutsRepository
    {
        private readonly ExerciseTrackerDbContext _exerciseTrackerDbContext;
        
        public WorkoutsRepository(ExerciseTrackerDbContext exerciseTrackerDbContext) : base(exerciseTrackerDbContext)
        {
            _exerciseTrackerDbContext = exerciseTrackerDbContext;
        }
    }
}