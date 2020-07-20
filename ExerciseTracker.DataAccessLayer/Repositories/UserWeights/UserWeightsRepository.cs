using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciseTracker.Data;
using ExerciseTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> IsAnyUserWeightExistsAsync(long userId)
        {
            var result = await _exerciseTrackerDbContext.UserWeights.AnyAsync(uw => uw.UserId == userId);

            return result;
        }

        public bool IsAnyUserWeightExists(long userId)
        {
            var result = _exerciseTrackerDbContext.UserWeights.Any(uw => uw.UserId == userId);
            
            return result;
        }

        public async Task<List<UserWeight>> GetUserWeightsAsync(long userId)
        {
            var userWeights = await _exerciseTrackerDbContext.UserWeights.Where(uw => uw.UserId == userId)
                                                                                       .ToListAsync();

            return userWeights;
        }

        public List<UserWeight> GetUserWeights(long userId)
        {
            var userWeights = _exerciseTrackerDbContext.UserWeights.Where(uw => uw.UserId == userId)
                                                                                  .ToList();

            return userWeights;
        }
    }
}