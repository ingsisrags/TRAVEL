using Domain.Library.Configuration.Dtos.Input;
using Domain.Library.Configuration.Dtos.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookOutput>> GetAll();
        Task<BookOutput> GetById(int id);
        Task<BookOutput> Create(CreateBookInput input);
    }
}
