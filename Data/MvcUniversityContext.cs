using System;
using Microsoft.EntityFrameworkCore;
using MvcUniversity.Models;

public class MvcUniversityContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Student> Students { get; set; }

    public string DbPath { get; private set; }

    public MvcUniversityContext()
    {
        // Path to SQLite database file
        DbPath = "MvcUniversity.db";
    }
    // The following configures EF to create a SQLite database file locally
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Use SQLite as database
        options.UseSqlite($"Data Source={DbPath}");
        // Optional: log SQL queries to console
        //options.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
    }

}
