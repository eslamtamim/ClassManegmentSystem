﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ClassManegmentSystem.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Student>()
                .HasMany(s => s.teachers)
                .WithMany(t => t.students)
                .UsingEntity<Class>(
                 j => j
                .HasOne(s => s.teacher)
                .WithMany(c => c.Classes)
                .HasForeignKey(s => s.TeacherId),
                j => j
                .HasOne(s => s.student)
                .WithMany(c => c.Classes)
                .HasForeignKey(s => s.StudentId)   
                );

            model.Entity<Student>(
                s =>
                {
                    s.Property(e => e.StudentNumber)
                    .HasComputedColumnSql("[StudentGrade]+ '-' + [StudentId]+ '-' + [CityId]");
                    s.Property(e => e.CreationDate)
                    .HasDefaultValueSql("GETDATE()");
                    s.HasOne(e => e.city).WithMany(c => c.students);
                    //s.Property(e => e.StudentID).UseIdentityColumn(101, 1);

                }
                );

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Class> classes { get; set; }

    }
}