using ExerciseTracker.Data;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories.Exercises
{
    public class ExercisesRepository : Repository<Exercise, long>, IExercisesRepository
    {
        private readonly ExerciseTrackerDbContext _exerciseTrackerDbContext;
        
        public ExercisesRepository(ExerciseTrackerDbContext exerciseTrackerDbContext) : base(exerciseTrackerDbContext)
        {
            _exerciseTrackerDbContext = exerciseTrackerDbContext;
        }
    }
}