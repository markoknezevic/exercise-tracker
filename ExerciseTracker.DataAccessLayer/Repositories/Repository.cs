using ExerciseTracker.Data;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories
{
    public class Repository <T, TK> : IRepository<T, TK> where T : Entity<TK> where TK : struct
    {
        private ExerciseTrackerDbContext _exerciseTrackerDbContext;

        public Repository(ExerciseTrackerDbContext exerciseTrackerDbContext)
        {
            _exerciseTrackerDbContext = exerciseTrackerDbContext;
        }
    }
}