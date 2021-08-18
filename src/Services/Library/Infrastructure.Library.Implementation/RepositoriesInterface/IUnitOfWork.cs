using Infrastructure.Library.Implementation.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Library.Implementation.RepositoriesInterface
{
    public interface IUnitOfWork
    {
        IAutorRepository Autors { get; }
        IBookAutorRepository BookAutor { get; }
        IEditorialRepository Editorial { get; }
        IBookRepository Book { get; }

        Task CompleteAsync();
    }
}
