using ExerciseTracker.Data;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories.ExerciseWorkouts
{
    public class ExerciseWorkoutsRepository : Repository<ExerciseWorkout, long>, IExerciseWorkoutsRepository
    {
        private readonly ExerciseTrackerDbContext _exerciseTrackerDbContext;
        
        public ExerciseWorkoutsRepository(ExerciseTrackerDbContext exerciseTrackerDbContext) : base(exerciseTrackerDbContext)
        {
            _exerciseTrackerDbContext = exerciseTrackerDbContext;
        }
    }
}