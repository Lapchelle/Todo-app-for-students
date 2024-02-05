using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public partial class PostgresContext : DbContext
{
    

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Target> Targets { get; set; }

    public virtual DbSet<Models.Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Status_targets> StatusTargets { get; set; }

    public virtual DbSet<Status_Tasks> StatusTasks { get; set; }

    public virtual DbSet<User_contacts> UserContacts { get; set; }
    public virtual DbSet<User_targets> User_Targets { get; set; }
    public virtual DbSet<User_tasks> User_Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User_contacts>()
                .HasKey(pc => new { pc.UserId, pc.ContactId });
        modelBuilder.Entity<User_contacts>()
                .HasOne(p => p.User)
                .WithMany(pc => pc.User_contacts)
                .HasForeignKey(p => p.UserId);
        modelBuilder.Entity<User_contacts>()
                .HasOne(p => p.Contact)
                .WithMany(pc => pc.User_contacts)
                .HasForeignKey(c => c.ContactId);


        modelBuilder.Entity<User_targets>()
               .HasKey(pc => new { pc.UserId, pc.TargetId });
        modelBuilder.Entity<User_targets>()
                .HasOne(p => p.User)
                .WithMany(pc => pc.User_Targets)
                .HasForeignKey(c => c.UserId);
        modelBuilder.Entity<User_targets>()
                .HasOne(p => p.Target)
                .WithMany(pc => pc.User_Targets)
                .HasForeignKey(c => c.TargetId);


        modelBuilder.Entity<User_tasks>()
               .HasKey(pc => new { pc.UserId, pc.TaskId });
        modelBuilder.Entity<User_tasks>()
                .HasOne(p => p.User)
                .WithMany(pc => pc.User_tasks)
                .HasForeignKey(c => c.UserId);
        modelBuilder.Entity<User_tasks>()
                .HasOne(p => p.Task)
                .WithMany(pc => pc.User_tasks)
                .HasForeignKey(c => c.TaskId);


        modelBuilder.Entity<Status_Tasks>()
               .HasKey(pc => new { pc.StatusId, pc.TaskId });
        modelBuilder.Entity<Status_Tasks>()
                .HasOne(p => p.Status)
                .WithMany(pc => pc.Status_Tasks)
                .HasForeignKey(c => c.StatusId);
        modelBuilder.Entity<Status_Tasks>()
                .HasOne(p => p.Task)
                .WithMany(pc => pc.Status_Tasks)
                .HasForeignKey(c => c.TaskId);

        modelBuilder.Entity<Status_targets>()
               .HasKey(pc => new { pc.StatusId, pc.TargetId });
        modelBuilder.Entity<Status_targets>()
                .HasOne(p => p.Status)
                .WithMany(pc => pc.Status_targets)
                .HasForeignKey(c => c.StatusId);
        modelBuilder.Entity<Status_targets>()
                .HasOne(p => p.Target)
                .WithMany(pc => pc.Status_targets)
                .HasForeignKey(c => c.TargetId);

    }

}   
