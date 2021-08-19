using Domain.Library.Books;
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
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context, ILogger logger) : base(context, logger) { }
        public override async Task<IEnumerable<Book>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(Book));
                return new List<Book>();
            }
        }

        public IQueryable<Book> GetAll()
        {
            try
            {
                IQueryable<Book> query = dbSet;
                return query;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(Book));
                return null;
            }
        }


        public async Task<bool> Upsert(Book entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.ISBN == entity.ISBN)
                                                    .FirstOrDefaultAsync();

                if (existingUser == null)
                    await Add(entity);


                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(Book));
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.ISBN == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(Book));
                return false;
            }
        }
    }
}
