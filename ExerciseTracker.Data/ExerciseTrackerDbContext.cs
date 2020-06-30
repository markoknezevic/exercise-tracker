using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExerciseTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Data
{
    public class ExerciseTrackerDbContext : DbContext
    {
        public DbSet<Status> Statuses { get; set; }
        
        public DbSet<User> Users { get; set; }

        public DbSet<UserWeight> UserWeights { get; set; }
        
        public DbSet<Workout> Workouts { get; set; }
        
        public DbSet<WorkoutRecord> WorkoutRecords { get; set; }

        public ExerciseTrackerDbContext(DbContextOptions<ExerciseTrackerDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is ITimestampable && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((ITimestampable)entity.Entity).CreatedAt = DateTime.UtcNow;
                }

                ((ITimestampable)entity.Entity).UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}