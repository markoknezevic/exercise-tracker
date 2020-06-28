using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ExerciseTracker.Data
{
    public class ExerciseTrackerDbConfigurationFactory : IDesignTimeDbContextFactory<ExerciseTrackerDbContext>
    {
        public ExerciseTrackerDbContext CreateDbContext(string[] args)
        {
            var dbContextConfiguration = new ExerciseTrackerDbContextConfiguration();
            var dbContextBuilder = new DbContextOptionsBuilder<ExerciseTrackerDbContext>();
            dbContextBuilder.UseNpgsql(dbContextConfiguration.ConnectionString); 
            return new ExerciseTrackerDbContext(dbContextBuilder.Options);
        }
    }
}