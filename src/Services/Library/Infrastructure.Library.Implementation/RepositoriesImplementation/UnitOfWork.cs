using Infrastructure.Library.Implementation.Context;
using Infrastructure.Library.Implementation.RepositoriesInterface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Library.Implementation.RepositoriesImplementation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public IAutorRepository Autors { get; private set; }
        public IBookRepository Book { get; private set; }
        public IEditorialRepository Editorial { get; private set; }

        public IBookAutorRepository BookAutor { get; private set; }

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            Autors = new AutorRepository(context, _logger);
            Book = new BookRepository(context, _logger);
            BookAutor = new AutorBookRepository(context, _logger);
            Editorial = new EditorialRepository(context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
