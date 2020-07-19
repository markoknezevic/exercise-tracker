using System.Threading.Tasks;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories.UserWeights
{
    public interface IUserWeightsRepository : IRepository<UserWeight, long>
    {
        Task<UserWeight> AddUserWeightAsync(UserWeight userWeight);
        
        UserWeight AddUserWeight(UserWeight userWeight);
    }
}