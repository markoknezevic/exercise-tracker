
using System.Threading.Tasks;
using ExerciseTracker.Data;
using ExerciseTracker.DataAccessLayer.Repositories.Exercises;
using ExerciseTracker.DataAccessLayer.Repositories.ExerciseWorkouts;
using ExerciseTracker.DataAccessLayer.Repositories.Statuses;
using ExerciseTracker.DataAccessLayer.Repositories.Users;
using ExerciseTracker.DataAccessLayer.Repositories.UserWeights;
using ExerciseTracker.DataAccessLayer.Repositories.WorkoutRecords;
using ExerciseTracker.DataAccessLayer.Repositories.Workouts;
using Newtonsoft.Json.Serialization;

namespace ExerciseTracker.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExerciseTrackerDbContext _exerciseTrackerDbContext;

        public UnitOfWork(ExerciseTrackerDbContext exerciseTrackerDbContext)
        {
            _exerciseTrackerDbContext = exerciseTrackerDbContext;
        }


        private IExercisesRepository _exercisesRepository;
        public IExercisesRepository ExercisesRepository => this._exercisesRepository ??
                                                           (this._exercisesRepository =
                                                               new ExercisesRepository(_exerciseTrackerDbContext));
        
        private IExerciseWorkoutsRepository _exerciseWorkoutsRepository;
        public IExerciseWorkoutsRepository ExerciseWorkoutsRepository => this._exerciseWorkoutsRepository ?? (this._exerciseWorkoutsRepository =
                                                                                                                new ExerciseWorkoutsRepository(_exerciseTrackerDbContext));
            
        private IStatusesRepository _statusesRepository;
        public IStatusesRepository StatusesRepository => this._statusesRepository ??
                                                          (this._statusesRepository =
                                                              new StatusesRepository(_exerciseTrackerDbContext));
        
        private IUsersRepository _usersRepository;
        public IUsersRepository UsersRepository => this._usersRepository ??
                                                      (this._usersRepository =
                                                          new UsersRepository(_exerciseTrackerDbContext));
        
        private IUserWeightsRepository _userWeightsRepository;
        public IUserWeightsRepository UserWeightsRepository => this._userWeightsRepository ??
                                                                (this._userWeightsRepository =
                                                                    new UserWeightsRepository(_exerciseTrackerDbContext));
        
        private IWorkoutRecordsRepository _workoutRecordsRepository;
        public IWorkoutRecordsRepository WorkoutRecordsRepository => this._workoutRecordsRepository ??
                                                            (this._workoutRecordsRepository =
                                                                new WorkoutRecordsRepository(_exerciseTrackerDbContext));
        
        private IWorkoutsRepository _workoutsRepository;
        public IWorkoutsRepository WorkoutsRepository => this._workoutsRepository ??
                                                      (this._workoutsRepository =
                                                          new WorkoutsRepository(_exerciseTrackerDbContext));

        public Task SaveChangesAsync()
        {
            return _exerciseTrackerDbContext.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _exerciseTrackerDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _exerciseTrackerDbContext.Dispose();
        }
    }
}