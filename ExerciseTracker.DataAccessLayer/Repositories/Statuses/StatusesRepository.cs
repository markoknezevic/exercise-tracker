using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciseTracker.Data;
using ExerciseTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.DataAccessLayer.Repositories.Statuses
{
    public class StatusesRepository : Repository<Status, short>, IStatusesRepository
    {
        private readonly ExerciseTrackerDbContext _exerciseTrackerDbContext;
        
        public StatusesRepository(ExerciseTrackerDbContext exerciseTrackerDbContext) : base(exerciseTrackerDbContext)
        {
            _exerciseTrackerDbContext = exerciseTrackerDbContext;
        }

        public async Task<List<Status>> GetAllStatusesAsync()
        {
            var statuses = await _exerciseTrackerDbContext.Statuses.ToListAsync();

            return statuses;
        }

        public List<Status> GetAllStatuses()
        {
            var statuses = _exerciseTrackerDbContext.Statuses.ToList();

            return statuses;
        }
    }
}