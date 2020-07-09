using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciseTracker.Data;
using ExerciseTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.DataAccessLayer.Repositories.Workouts
{
    public class WorkoutsRepository : Repository<Workout, long>, IWorkoutsRepository
    {
        private readonly ExerciseTrackerDbContext _exerciseTrackerDbContext;
        
        public WorkoutsRepository(ExerciseTrackerDbContext exerciseTrackerDbContext) : base(exerciseTrackerDbContext)
        {
            _exerciseTrackerDbContext = exerciseTrackerDbContext;
        }

        public async Task<Workout> AddWorkoutAsync(Workout workout)
        {
            await _exerciseTrackerDbContext.Workouts.AddAsync(workout);

            var result = await _exerciseTrackerDbContext.SaveChangesAsync();
            if (result == 0)
            {
                return null;
            }

            return workout;
        }

        public Workout AddWorkout(Workout workout)
        {
             _exerciseTrackerDbContext.Workouts.Add(workout);

            var result =  _exerciseTrackerDbContext.SaveChanges();
            if (result == 0)
            {
                return null;
            }

            return workout;
        }

        public async Task<bool> IsActiveWorkoutExistsAsync(long id)
        {
            var result = await _exerciseTrackerDbContext.Workouts.AnyAsync(w => w.Id == id &&
                                                                                                       w.StatusId == (short) Data.Entities.Statuses.Active);

            return result;
        }

        public bool IsActiveWorkoutExists(long id)
        {
            var result = _exerciseTrackerDbContext.Workouts.Any(w => w.Id == id &&
                                                                                   w.StatusId == (short) Data.Entities.Statuses.Active);

            return result;
        }

        public async Task<bool> DeleteWorkoutAsync(long id)
        {
            var workout  = await _exerciseTrackerDbContext.Workouts.FirstOrDefaultAsync(w => w.Id == id);
            if(workout == null)
            {
                return false;
            }

            workout.StatusId = (short) Data.Entities.Statuses.Inactive;

            var result = await _exerciseTrackerDbContext.SaveChangesAsync();
            if (result == 0)
            {
                return false;
            }

            return true;
        }

        public bool DeleteWorkout(long id)
        {
            var workout  = _exerciseTrackerDbContext.Workouts.FirstOrDefault(w => w.Id == id);
            if(workout == null)
            {
                return false;
            }

            workout.StatusId = (short) Data.Entities.Statuses.Inactive;

            var result =  _exerciseTrackerDbContext.SaveChanges();
            if (result == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<List<Workout>> GetAllWorkoutsAsync()
        {
            var workouts = await _exerciseTrackerDbContext.Workouts.ToListAsync();
            if (workouts.Count == 0)
            {
                return null;
            }

            return workouts;
        }

        public List<Workout> GetAllWorkouts()
        {
            var workouts =  _exerciseTrackerDbContext.Workouts.ToList();
            if (workouts.Count == 0)
            {
                return null;
            }

            return workouts;
        }
    }
}