using Microsoft.EntityFrameworkCore;

namespace Abc.HabitTracker.Api.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
            .Entity<DayOff>(builder =>
            {
                builder.HasNoKey();
            });

        }
        public DbSet<Habit> Habits { get; set; }

        public DbSet<Badge> Badges { get; set; }

        public DbSet<Logs> Logs { get; set; }
    }
}