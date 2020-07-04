using System.Linq;
using System.Threading.Tasks;
using ExerciseTracker.Data;
using ExerciseTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.DataAccessLayer.Repositories.Users
{
    public class UsersRepository : Repository<User, long>, IUsersRepository
    {
        private readonly ExerciseTrackerDbContext _exerciseTrackerDbContext;

        public UsersRepository(ExerciseTrackerDbContext exerciseTrackerDbContext) : base(exerciseTrackerDbContext)
        {
            _exerciseTrackerDbContext = exerciseTrackerDbContext;
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            await _exerciseTrackerDbContext.Users.AddAsync(user);

            var result = await _exerciseTrackerDbContext.SaveChangesAsync();
            if (result == 0)
            {
                return null;
            }

            return user;
        }

        public User RegisterUser(User user)
        {
            _exerciseTrackerDbContext.Users.Add(user);

            var result =  _exerciseTrackerDbContext.SaveChanges();
            if (result == 0)
            {
                return null;
            }

            return user;
        }

        public Task<bool> IsEmailTakenAsync(string email)
        {
            var result = _exerciseTrackerDbContext.Users.AnyAsync(u => u.Email == email);

            return result;
        }

        public bool IsEmailTaken(string email)
        {
            var result = _exerciseTrackerDbContext.Users.Any(u => u.Email == email);

            return result;
        }
    }
}