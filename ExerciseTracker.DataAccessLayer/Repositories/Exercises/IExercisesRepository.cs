using System.Collections.Generic;
using System.Threading.Tasks;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories.Exercises
{
    public interface IExercisesRepository : IRepository<Exercise, long>
    {
        Task<List<Exercise>> GetAllExercisesAsync();
        
        List<Exercise> GetAllExercises();
    }
}