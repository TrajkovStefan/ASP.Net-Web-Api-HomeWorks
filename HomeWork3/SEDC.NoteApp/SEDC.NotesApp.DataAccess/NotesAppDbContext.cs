using Microsoft.EntityFrameworkCore;
using SEDC.NotesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.DataAccess
{
    public class NotesAppDbContext : DbContext
    {
        public NotesAppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //NOTE
            modelBuilder.Entity<Note>()
                .Property(x => x.Text)
                .HasMaxLength(100) //nvarchar(100)
                .IsRequired(); //not null

            modelBuilder.Entity<Note>()
                .Property(x => x.Color)
                .HasMaxLength(30); //nvarchar(30)

            //relation
            modelBuilder.Entity<Note>()
                .HasOne(x => x.User)
                .WithMany(x => x.Notes)
                .HasForeignKey(x => x.UserId);

            //USER
            modelBuilder.Entity<User>()
                .Property(x => x.FirstName)
                .HasMaxLength(50); //nvarchar(50)

            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .HasMaxLength(50); //nvarchar(50)

            modelBuilder.Entity<User>()
                .Property(x => x.UserName)
                .IsRequired() //not null
                .HasMaxLength(30); //nvarchar(30)

            modelBuilder.Entity<User>()
                .Ignore(x => x.Age); //a column will not be created for age

            //SEEDING


        }
    }
}
