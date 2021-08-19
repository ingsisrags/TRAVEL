using Domain.Library.Authors;
using Domain.Library.Books;
using Domain.Library.Editorials;
using Domain.Library.Inventory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Library.Implementation.Context
{

    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookAuthor> BookAutors { get; set; }
        public virtual DbSet<Editorial> Editorial { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void
       OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(x => new { x.BookISBN, x.AutorId });
        }
    }
}
