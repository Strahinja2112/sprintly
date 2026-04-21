namespace Sprintra.Data;

using Microsoft.EntityFrameworkCore;
using Sprintra.Models;

public class AppDbContext : DbContext {
  public DbSet<Employee> Employees { get; set; }
  public DbSet<Client> Clients { get; set; }
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
    optionsBuilder.UseSqlServer(@"Server=DESKTOP-RUAM7G4\SQLEXPRESS;Database=Sprintra;Trusted_Connection=True;TrustServerCertificate=True;");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    // Employee Mapiranja
    modelBuilder.Entity<Employee>(entity => {
      entity.HasIndex(e => e.Email).IsUnique();
      entity.HasIndex(e => e.Username).IsUnique();
      entity.Property(e => e.Type).HasConversion<string>();
    });

    // Client Mapiranja
    modelBuilder.Entity<Client>()
        .HasIndex(c => c.Email).IsUnique();

    // UserStory Mapiranja
    modelBuilder.Entity<UserStory>()
        .HasOne(u => u.Client)
        .WithMany(c => c.UserStories)
        .HasForeignKey(u => u.ClientId)
        .OnDelete(DeleteBehavior.SetNull);

    // WorkTask Mapiranja
    modelBuilder.Entity<WorkTask>()
        .HasOne(w => w.UserStory)
        .WithMany()
        .HasForeignKey(w => w.UserStoryId)
        .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<WorkTask>()
        .HasOne(w => w.Sprint)
        .WithMany(s => s.WorkTasks)
        .HasForeignKey(w => w.SprintId)
        .OnDelete(DeleteBehavior.Restrict);

    // WorkTaskEntry Mapiranja (Many-to-Many sa dodatnim podacima)
    modelBuilder.Entity<WorkTaskEntry>(entity => {
      entity.HasKey(we => new { we.EmployeeId, we.WorkTaskId, we.WorkDate });

      entity.HasOne(we => we.Employee)
          .WithMany()
          .HasForeignKey(we => we.EmployeeId)
          .OnDelete(DeleteBehavior.Cascade);

      entity.HasOne(we => we.WorkTask)
          .WithMany(wt => wt.WorkLogEntries)
          .HasForeignKey(we => we.WorkTaskId)
          .OnDelete(DeleteBehavior.Cascade);
    });

    // Project Mapiranja (Many-to-Many implicitna)
    modelBuilder.Entity<Project>()
        .HasMany(p => p.Members)
        .WithMany(e => e.Projects)
        .UsingEntity(j => j.ToTable("Employee_WorksOn_Project"));

    // Sprint Mapiranja
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

    // Distribution Mapiranja
    modelBuilder.Entity<Distribution>()
        .Property(d => d.Environment).HasConversion<string>();

    // Increment Mapiranja
    modelBuilder.Entity<Increment>()
        .HasOne(i => i.Distribution)
        .WithMany()
        .HasForeignKey(i => i.DistributionId)
        .OnDelete(DeleteBehavior.Cascade);

    // Feature Mapiranja
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

    // Meeting Mapiranja (TPH)
    modelBuilder.Entity<Meeting>(entity => {
      entity.HasOne(m => m.Sprint)
          .WithMany(s => s.Meetings)
          .HasForeignKey(m => m.SprintId)
          .OnDelete(DeleteBehavior.Cascade);

      entity.Property(m => m.Type).HasConversion<string>();
    });
  }
}