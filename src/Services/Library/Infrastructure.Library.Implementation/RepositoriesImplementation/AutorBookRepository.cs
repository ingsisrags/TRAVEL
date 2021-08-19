using Domain.Library.Inventory;
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
    public class AutorBookRepository : GenericRepository<BookAuthor>, IBookAutorRepository
    {
        public AutorBookRepository(ApplicationDbContext context, ILogger logger) : base(context, logger) { }
        public override async Task<IEnumerable<BookAuthor>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(BookAuthor));
                return new List<BookAuthor>();
            }
        }



        public async Task<bool> Upsert(BookAuthor entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.AutorId == entity.AutorId
                && x.BookISBN == entity.BookISBN
                )
                  .FirstOrDefaultAsync();

                if (existingUser == null)
                     await Add(entity);


                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(BookAuthor));
                return false;
            }
        }

        public async Task<bool> Delete(BookAuthor entity)
        {
            try
            {
                var exist = await dbSet.Where(x => x.AutorId == entity.AutorId
                && x.BookISBN == entity.BookISBN
                )
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(BookAuthor));
                return false;
            }
        }
    }
}
