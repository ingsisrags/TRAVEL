using Domain.Library.Autors;
using Domain.Library.Books;
using Domain.Library.Editorial;
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
        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookAutor> BookAutors { get; set; }
        public virtual DbSet<Editorial> Editorial { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        ////protected override void OnModelCreating(ModelBuilder modelBuilder)
        ////{
        ////    modelBuilder.Entity<BookAutor>()
        ////  .HasKey(o => new { o.AutorId, o.BookISBN });
        ////    base.OnModelCreating(modelBuilder);
        ////}
    }
}
