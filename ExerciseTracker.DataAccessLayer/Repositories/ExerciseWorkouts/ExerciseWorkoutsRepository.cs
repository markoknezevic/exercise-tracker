using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciseTracker.Data;
using ExerciseTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.DataAccessLayer.Repositories.ExerciseWorkouts
{
    public class ExerciseWorkoutsRepository : Repository<ExerciseWorkout, long>, IExerciseWorkoutsRepository
    {
        private readonly ExerciseTrackerDbContext _exerciseTrackerDbContext;
        
        public ExerciseWorkoutsRepository(ExerciseTrackerDbContext exerciseTrackerDbContext) : base(exerciseTrackerDbContext)
        {
            _exerciseTrackerDbContext = exerciseTrackerDbContext;
        }

        public async Task<List<ExerciseWorkout>> GetExerciseWorkoutsByIdAsync(long id)
        {
            var exerciseWorkout  = await _exerciseTrackerDbContext.ExerciseWorkouts.Include(ew => ew.Exercise)
                                                                                                      .Where(ew => ew.WorkoutId == id && 
                                                                                                                                 ew.StatusId == (short) Data.Entities.Statuses.Active)
                                                                                                      .ToListAsync();

            return exerciseWorkout;
        }

        public List<ExerciseWorkout> GetExerciseWorkoutsById(long id)
        {
            var exerciseWorkout  =  _exerciseTrackerDbContext.ExerciseWorkouts.Include(ew => ew.Exercise)
                                                                                                 .Where(ew => ew.WorkoutId == id && 
                                                                                                                            ew.StatusId == (short) Data.Entities.Statuses.Active)
                                                                                                 .ToList();

            return exerciseWorkout;
        }

        public async Task<bool> IsWorkoutExistInExerciseWorkoutAsync(long workoutId)
        {
            var result = await _exerciseTrackerDbContext.ExerciseWorkouts.AnyAsync(ew => ew.WorkoutId == workoutId);

            return result;
        }

        public bool IsWorkoutExistInExerciseWorkout(long workoutId)
        {
            var result = _exerciseTrackerDbContext.ExerciseWorkouts.Any(ew => ew.WorkoutId == workoutId);

            return result;
        }

        public async Task<List<ExerciseWorkout>> AddExerciseWorkoutListAsync(List<ExerciseWorkout> exerciseWorkouts)
        {
            await _exerciseTrackerDbContext.ExerciseWorkouts.AddRangeAsync(exerciseWorkouts);

            var result = await _exerciseTrackerDbContext.SaveChangesAsync();
            if (result != exerciseWorkouts.Count)
            {
                return null;
            }

            return exerciseWorkouts;
        }

        public List<ExerciseWorkout> AddExerciseWorkoutList(List<ExerciseWorkout> exerciseWorkouts)
        {
             _exerciseTrackerDbContext.ExerciseWorkouts.AddRange(exerciseWorkouts);

            var result = _exerciseTrackerDbContext.SaveChanges();
            if (result != exerciseWorkouts.Count)
            {
                return null;
            }

            return exerciseWorkouts;
        }
    }
}