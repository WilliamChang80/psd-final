using Microsoft.EntityFrameworkCore;

namespace Abc.HabitTracker.Api.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Habit> Habits { get; set; }

        public DbSet<Badge> Badges { get; set; }
    }
}