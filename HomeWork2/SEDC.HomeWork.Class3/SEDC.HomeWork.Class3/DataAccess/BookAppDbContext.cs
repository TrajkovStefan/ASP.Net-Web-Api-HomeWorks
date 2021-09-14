using Microsoft.EntityFrameworkCore;
using SEDC.HomeWork.Class3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.HomeWork.Class3.DataAccess
{
    public class BookAppDbContext : DbContext
    {
        public BookAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
                .HasData(new Book() { Id = 1, Title = "Book1", Author = "Author1" },
                         new Book() { Id = 2, Title = "Book2", Author = "Author2" },
                         new Book() { Id = 3, Title = "Book3", Author = "Author3" });

        }
    }
}
