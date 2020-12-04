using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FridaSchoolWeb.Models;

namespace FridaSchoolWeb.Models
{
    public class FridaSchool : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; } 
        //public DbSet<Group> Groups { get; set; } 

        public FridaSchool(DbContextOptions<FridaSchool> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Teacher>()
            .Property(c => c.Names)
            .IsRequired()
            .HasMaxLength(60);
            modelBuilder.Entity<Teacher>()
            .Property(c => c.MiddleName)
            .IsRequired()
            .HasMaxLength(40);
            modelBuilder.Entity<Teacher>()
            .Property(c => c.LastName)
            .IsRequired()
            .HasMaxLength(40);
            modelBuilder.Entity<Teacher>()
            .Property(c => c.CURP)
            .IsRequired()
            .HasMaxLength(18);
            modelBuilder.Entity<Teacher>()
            .Property(c => c.RFC)
            .IsRequired()
            .HasMaxLength(13);
            modelBuilder.Entity<Teacher>()
            .Property(c => c.Roaster)
            .IsRequired()
            .HasMaxLength(4);
            modelBuilder.Entity<Teacher>()
            .Property(c => c.Password)
            .IsRequired()
            .HasMaxLength(500);
            modelBuilder.Entity<Teacher>()
            .Property(c => c.Gender)
            .IsRequired()
            .HasMaxLength(1);

        }

    }
}
