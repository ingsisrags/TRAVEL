using Domain.Library.Configuration.Dtos.Input;
using Domain.Library.Configuration.Dtos.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Interfaces
{
    public interface IEditorialService
    {
        Task<IEnumerable<EditorialOutput>> GetAll();
        Task<EditorialOutput> GetById(int id);
        Task<EditorialOutput> Create(CreateEditorialInput input);
    }
}
