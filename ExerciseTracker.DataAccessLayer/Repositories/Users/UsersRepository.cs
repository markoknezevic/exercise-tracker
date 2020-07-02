using ExerciseTracker.Data;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories.Users
{
    public class UsersRepository : Repository<User, long>, IUsersRepository
    {
        private readonly ExerciseTrackerDbContext _exerciseTrackerDbContext;

        public UsersRepository(ExerciseTrackerDbContext exerciseTrackerDbContext) : base(exerciseTrackerDbContext)
        {
            _exerciseTrackerDbContext = exerciseTrackerDbContext;
        }
    }
}