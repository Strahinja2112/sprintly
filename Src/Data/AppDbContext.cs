namespace Sprintly.Src.Data;

using Microsoft.EntityFrameworkCore;
using Sprintly.Src.Data.Models;

public class AppDbContext : DbContext {
  public DbSet<Employee> Employees { get; set; }
  public DbSet<UserStory> UserStories { get; set; }
  public DbSet<WorkTask> WorkTasks { get; set; }
  public DbSet<WorkTaskEntry> WorkTaskEntries { get; set; }
  public DbSet<Project> Projects { get; set; }
  public DbSet<Sprint> Sprints { get; set; }
  public DbSet<Distribution> Distributions { get; set; }
  public DbSet<Increment> Increments { get; set; }
  public DbSet<Feature> Features { get; set; }
  public DbSet<Meeting> Meetings { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    optionsBuilder.UseSqlServer($"Server={Environment.MachineName}\\SQLEXPRESS;Database=Sprintra;Trusted_Connection=True;TrustServerCertificate=True;");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    // Employee
    modelBuilder.Entity<Employee>(entity => {
      entity.HasIndex(e => e.Email).IsUnique();
      entity.HasIndex(e => e.Username).IsUnique();
      entity.Property(e => e.Type).HasConversion<string>();
    });

    modelBuilder.Entity<WorkTask>()
      .HasMany(w => w.AssignedEmployees)
      .WithMany(e => e.AssignedTasks)
      .UsingEntity(j => j.ToTable("Employee_AssignedTo_WorkTask"));

    // WorkTask
    modelBuilder.Entity<WorkTask>(entity => {
      entity.HasOne(w => w.UserStory)
          .WithMany(u => u.WorkTasks)
          .HasForeignKey(w => w.UserStoryId)
          .OnDelete(DeleteBehavior.Cascade);

      entity.HasOne(w => w.Sprint)
          .WithMany(s => s.WorkTasks)
          .HasForeignKey(w => w.SprintId)
          .OnDelete(DeleteBehavior.NoAction);
    });

    // WorkTaskEntry (Join tabela sa podacima - Manuelno mapirana)
    modelBuilder.Entity<WorkTaskEntry>(entity => {
      entity.HasOne(we => we.Employee)
          .WithMany()
          .HasForeignKey(we => we.EmployeeId)
          .OnDelete(DeleteBehavior.Cascade);

      entity.HasOne(we => we.WorkTask)
          .WithMany(wt => wt.WorkLogEntries)
          .HasForeignKey(we => we.WorkTaskId)
          .OnDelete(DeleteBehavior.Cascade);
    });

    // Sprint
    modelBuilder.Entity<Sprint>(entity => {
      entity.HasOne(s => s.Project)
          .WithMany(p => p.Sprints)
          .HasForeignKey(s => s.ProjectId)
          .OnDelete(DeleteBehavior.Cascade);

      entity.HasOne(s => s.ScrumMaster)
          .WithMany()
          .HasForeignKey(s => s.ScrumMasterId)
          .OnDelete(DeleteBehavior.Cascade);

      entity.Property(s => s.Status).HasConversion<string>();
    });

    // Distribution
    modelBuilder.Entity<Distribution>()
        .Property(d => d.Environment).HasConversion<string>();

    // Increment
    modelBuilder.Entity<Increment>()
        .HasOne(i => i.Distribution)
        .WithMany()
        .HasForeignKey(i => i.DistributionId)
        .OnDelete(DeleteBehavior.Cascade);

    // Feature
    modelBuilder.Entity<Feature>(entity => {
      entity.HasOne(f => f.Sprint)
          .WithMany()
          .HasForeignKey(f => f.SprintId)
          .OnDelete(DeleteBehavior.Cascade);

      entity.HasOne(f => f.Increment)
          .WithMany()
          .HasForeignKey(f => f.IncrementId)
          .OnDelete(DeleteBehavior.Cascade);
    });

    // Meeting (Many-to-Many: Employee <-> Meeting + TPH)
    modelBuilder.Entity<Meeting>(entity => {
      entity.HasOne(m => m.Sprint)
          .WithMany(s => s.Meetings)
          .HasForeignKey(m => m.SprintId)
          .OnDelete(DeleteBehavior.Cascade);

      entity.Property(m => m.Type).HasConversion<string>();

      // Many-to-Many: Employee <-> Meeting
      entity.HasMany(m => m.Attendees)
          .WithMany(e => e.Meetings)
          .UsingEntity<Dictionary<string, object>>(
              "Employee_Attends_Meeting",
              j => j
                  .HasOne<Employee>()
                  .WithMany()
                  .HasForeignKey("AttendeesId")
                  .OnDelete(DeleteBehavior.NoAction),
              j => j
                  .HasOne<Meeting>()
                  .WithMany()
                  .HasForeignKey("MeetingsId")
                  .OnDelete(DeleteBehavior.Cascade)
          );
    });
  }
}