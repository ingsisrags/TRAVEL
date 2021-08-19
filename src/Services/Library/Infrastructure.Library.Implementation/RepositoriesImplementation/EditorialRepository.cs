using Domain.Library.Editorials;
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
    public class EditorialRepository : GenericRepository<Editorial>, IEditorialRepository
    {
        public EditorialRepository(ApplicationDbContext context, ILogger logger) : base(context, logger) { }
        public override async Task<IEnumerable<Editorial>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(Editorial));
                return new List<Editorial>();
            }
        }

        public async Task<bool> Upsert(Editorial entity)
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
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(Editorial));
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
                _logger.LogError(ex, "{Repo} Delete function error", typeof(Editorial));
                return false;
            }
        }
    }
}
