using System.Collections.Generic;
using System.Threading.Tasks;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.DataAccessLayer.Repositories.Statuses
{
    public interface IStatusesRepository : IRepository<Status, short>
    {
        Task<List<Status>> GetAllStatusesAsync();

        List<Status> GetAllStatuses();
    }
}