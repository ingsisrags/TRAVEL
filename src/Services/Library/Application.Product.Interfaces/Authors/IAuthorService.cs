using Domain.Library.Configuration.Dtos.Input;
using Domain.Library.Configuration.Dtos.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Interfaces.Authors
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorOutput>> GetAll();
        Task<AuthorOutput> GetById(int id);
        Task<AuthorOutput> Create(CreateAuthorInput input);
    }
}
