using System.Collections.Generic;
using System.Threading.Tasks;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories.UserWeights
{
    public interface IUserWeightsRepository : IRepository<UserWeight, long>
    {
        Task<UserWeight> AddUserWeightAsync(UserWeight userWeight);
        
        UserWeight AddUserWeight(UserWeight userWeight);

        Task<bool> IsAnyUserWeightExistsAsync(long userId);
        
        bool IsAnyUserWeightExists(long userId);

        Task<List<UserWeight>> GetUserWeightsAsync(long userId);
        
        List<UserWeight> GetUserWeights(long userId);
    }
}