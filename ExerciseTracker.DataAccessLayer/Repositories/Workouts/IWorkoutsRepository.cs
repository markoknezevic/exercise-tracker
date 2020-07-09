using System.Threading.Tasks;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories.Workouts
{
    public interface IWorkoutsRepository : IRepository<Workout, long>
    {
        Task<Workout> AddWorkoutAsync(Workout workout);
        
        Workout AddWorkout(Workout workout);

        Task<bool> IsActiveWorkoutExistsAsync(long id);
        
        bool IsActiveWorkoutExists(long id);

        Task<bool> DeleteWorkoutAsync(long id);
        
        bool DeleteWorkout(long id);
    }
}