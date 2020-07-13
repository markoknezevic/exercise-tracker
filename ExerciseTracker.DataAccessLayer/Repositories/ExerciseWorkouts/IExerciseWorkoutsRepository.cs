using System.Collections.Generic;
using System.Threading.Tasks;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories.ExerciseWorkouts
{
    public interface IExerciseWorkoutsRepository : IRepository<ExerciseWorkout, long>
    {
        Task<List<ExerciseWorkout>> GetExerciseWorkoutsByIdAsync(long id);
        
        List<ExerciseWorkout> GetExerciseWorkoutsById(long id);

        Task<bool> IsWorkoutExistInExerciseWorkoutAsync(long id);
        
        bool IsWorkoutExistInExerciseWorkout(long id);

        Task<List<ExerciseWorkout>> AddExerciseWorkoutListAsync(List<ExerciseWorkout> exerciseWorkouts);
        
        List<ExerciseWorkout> AddExerciseWorkoutList(List<ExerciseWorkout> exerciseWorkouts);
    }
}