using Domain.Library.Autors;
using Infrastructure.Library.Implementation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Library.Implementation.Context
{
    public interface IAutorRepository : IGenericRepository<Autor>
    {
    }
}
