using ExerciseTracker.Data;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories.UserWeights
{
    public class UserWeightsRepository : Repository<UserWeight, long>, IUserWeightsRepository
    {
        private readonly ExerciseTrackerDbContext _exerciseTrackerDbContext;

        public UserWeightsRepository(ExerciseTrackerDbContext exerciseTrackerDbContext) : base(exerciseTrackerDbContext)
        {
            _exerciseTrackerDbContext = exerciseTrackerDbContext;
        }
    }
}