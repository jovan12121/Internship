using Microsoft.EntityFrameworkCore;
using TaskTracker.Models;

namespace TaskTracker.Infrastructure
{
    public class TaskTrackerContext : DbContext
    {
        public TaskTrackerContext(DbContextOptions<TaskTrackerContext> options) : base(options) { }
        public DbSet<Task_> Tasks { get; set;}
        public DbSet<Project> Projects { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task_>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Task_>().Property(t => t.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Project>()
                 .HasKey(p => p.Id);
            modelBuilder.Entity<Project>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tasks)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId); 


            base.OnModelCreating(modelBuilder);
        }
    }
}
