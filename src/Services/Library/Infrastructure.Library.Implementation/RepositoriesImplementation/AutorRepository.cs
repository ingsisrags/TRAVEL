using Domain.Library.Authors;
using Infrastructure.Library.Implementation.Context;
using Infrastructure.Library.Implementation.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Library.Implementation.RepositoriesImplementation
{
    public class AutorRepository  : GenericRepository<Author>, IAutorRepository
    {
        public AutorRepository(ApplicationDbContext context, ILogger logger) : base(context, logger) { }
        public override async Task<IEnumerable<Author>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(Author));
                return new List<Author>();
            }
        }

        public  async Task<bool> Upsert(Author entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == entity.Id)
                                                    .FirstOrDefaultAsync();

                if (existingUser == null)
                    await Add(entity);


                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(Author));
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(Author));
                return false;
            }
        }
    }
}
