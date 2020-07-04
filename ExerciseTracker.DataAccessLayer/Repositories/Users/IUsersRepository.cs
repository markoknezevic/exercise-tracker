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
    }
}