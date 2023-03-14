using System;
using System.Collections.Generic;
using System.Linq;
using Ticketing_System.Models;
using Microsoft.EntityFrameworkCore;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Project> Projects { get; set; }

    public DbSet<Issue> Issues { get; set; }

    public DbSet<Label> Labels { get; set; }

    public UserContext(DbContextOptions options) : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Issue>().HasKey(sc => new { sc.AssigneeId, sc.ReporterId });
        // modelBuilder.Entity<Issue>()
        //        .HasOne(m => m.Assignee)
        //        .WithOne(t => t.Assignee)
        //        .HasForeignKey<Issue>(m => m.AssigneeId)
        //        .OnDelete(DeleteBehavior.Restrict);
        // modelBuilder.Entity<Issue>()
        //             .HasOne(m => m.Reporter)
        //             .WithOne(t => t.Reporter)
        //             .HasForeignKey<Issue>(m => m.ReporterId)
        //             .OnDelete(DeleteBehavior.Restrict);
    }

}