using Microsoft.EntityFrameworkCore;
using teamWcrh.Models;

namespace teamWcrh.Persistence
{
    public class teamWCRHDbContext : DbContext
    {
        public teamWCRHDbContext(DbContextOptions<teamWCRHDbContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many To Many Relation Configuration for UserEvent

            modelBuilder.Entity<UserEvent>().HasKey(ue => new { ue.UserId, ue.EventId });

            modelBuilder.Entity<UserEvent>()
          .HasOne<User>(sc => sc.User)
        .WithMany(s => s.UserEvents)
        .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<UserEvent>()
                .HasOne<Event>(sc => sc.Event)
                .WithMany(s => s.UserEvents)
                .HasForeignKey(sc => sc.EventId);

            // Many To Many Relation Configuration for UserProject

            modelBuilder.Entity<UserProject>().HasKey(ue => new { ue.UserId, ue.ProjectId });
            // Many To Many Relation Configuration for UserGoal

            modelBuilder.Entity<UserGoal>().HasKey(ue => new { ue.UserId, ue.GoalId });


        }

        public DbSet<JoinRequest> JoinRequests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<UserGoal> UserGoal {get; set;}
        

    }
}