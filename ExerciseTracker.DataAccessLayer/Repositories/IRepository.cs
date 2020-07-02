using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories
{
    public interface IRepository <T, TK> where T : Entity<TK> where TK : struct
    {
        
    }
}