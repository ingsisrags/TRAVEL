using Domain.Library.Editorial;
using Infrastructure.Library.Implementation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Library.Implementation.Context
{
    public interface IEditorialRepository : IGenericRepository<Editorial>
    {
    }
}
