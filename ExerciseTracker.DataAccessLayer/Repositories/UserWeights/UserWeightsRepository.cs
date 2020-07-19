using System.Threading.Tasks;
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

        public async Task<UserWeight> AddUserWeightAsync(UserWeight userWeight)
        {
            await _exerciseTrackerDbContext.UserWeights.AddAsync(userWeight);

            var result = await _exerciseTrackerDbContext.SaveChangesAsync();
            if (result == 0)
            {
                return null;
            }

            return userWeight;
        }

        public UserWeight AddUserWeight(UserWeight userWeight)
        {
            _exerciseTrackerDbContext.UserWeights.Add(userWeight);

            var result = _exerciseTrackerDbContext.SaveChanges();
            if (result == 0)
            {
                return null;
            }

            return userWeight;
        }
    }
}