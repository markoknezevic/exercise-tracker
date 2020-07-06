using System;
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

        public async Task<bool> IsEmailTakenAsync(string email)
        {
            var result = await _exerciseTrackerDbContext.Users.AnyAsync(u => u.Email == email);

            return result;
        }

        public bool IsEmailTaken(string email)
        {
            var result = _exerciseTrackerDbContext.Users.Any(u => u.Email == email);

            return result;
        }

        public async Task<bool> IsActiveUserExistsAsync(long id)
        {
            var result = await _exerciseTrackerDbContext.Users.AnyAsync(u => u.Id == id && u.StatusId == (short) Data.Entities.Statuses.Active);

            return result;
        }

        public bool IsActiveUserExists(long id)
        {
            var result = _exerciseTrackerDbContext.Users.Any(u => u.Id == id && u.StatusId == (short) Data.Entities.Statuses.Active);

            return result;
        }

        public async Task<bool> DeleteUserAsync(long id)
        {
            var user = await _exerciseTrackerDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return false;
            }

            user.StatusId = (short) Data.Entities.Statuses.Inactive;

            var result = await _exerciseTrackerDbContext.SaveChangesAsync();

            if (result == 0)
            {
                return false;
            }

            return true;
        }

        public bool DeleteUser(long id)
        {
            var user =  _exerciseTrackerDbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return false;
            }

            user.StatusId = (short) Data.Entities.Statuses.Inactive;

            var result =  _exerciseTrackerDbContext.SaveChanges();

            if (result == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<User> EditUserAsync(long id, string firstName, string lastName, string password,  DateTime dateOfBirth)
        {
            var user = await _exerciseTrackerDbContext.Users.FirstOrDefaultAsync(u => u.Id == id &&
                                                                                                     u.StatusId == (short) Data.Entities.Statuses.Active);

            user.FirstName = firstName;
            user.LastName = lastName;
            user.Password = password;
            user.DateOfBirth = dateOfBirth;

            var result = await _exerciseTrackerDbContext.SaveChangesAsync();

            if (result == 0)
            {
                return null;
            }

            return user;
        }

        public User EditUser(long id, string firstName, string lastName, string password, DateTime dateOfBirth)
        {
            var user = _exerciseTrackerDbContext.Users.FirstOrDefault(u => u.Id == id &&
                                                                                 u.StatusId == (short) Data.Entities.Statuses.Active);
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Password = password;
            user.DateOfBirth = dateOfBirth;

            var result = _exerciseTrackerDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return user;
        }
    }
}