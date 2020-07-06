using System;
using System.Threading.Tasks;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories.Users
{
    public interface IUsersRepository : IRepository<User, long>
    {
        Task<User> RegisterUserAsync(User user);

        User RegisterUser(User user);

        Task<bool> IsEmailTakenAsync(string email);
        
        bool IsEmailTaken(string email);

        Task<bool> IsActiveUserExistsAsync(long id);
        
        bool IsActiveUserExists(long id);

        Task<bool> DeleteUserAsync(long id);
        
        bool DeleteUser(long id);
        
        Task<User> EditUserAsync(long id, string firstName, string lastName, string password, DateTime dateOfBirth);
        
        User EditUser(long id, string firstName, string lastName, string password, DateTime dateOfBirth);
    }
}