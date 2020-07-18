using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciseTracker.Data;
using ExerciseTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.DataAccessLayer.Repositories.Exercises
{
    public class ExercisesRepository : Repository<Exercise, long>, IExercisesRepository
    {
        private readonly ExerciseTrackerDbContext _exerciseTrackerDbContext;
        
        public ExercisesRepository(ExerciseTrackerDbContext exerciseTrackerDbContext) : base(exerciseTrackerDbContext)
        {
            _exerciseTrackerDbContext = exerciseTrackerDbContext;
        }

        public async Task<List<Exercise>> GetAllExercisesAsync()
        {
            var exercises = await _exerciseTrackerDbContext.Exercises.ToListAsync();

            return exercises;
        }

        public List<Exercise> GetAllExercises()
        {
            var exercises =  _exerciseTrackerDbContext.Exercises.ToList();

            return exercises;
        }
    }
}