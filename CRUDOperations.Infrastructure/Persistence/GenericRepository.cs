using CRUDOperation.Application.Repository;
using CRUDOperations.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperations.Infrastructure.Persistence
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : class
    {
        private readonly BrandDbContext _dbContext;
        
        public GenericRepository(BrandDbContext dbContext)
        {
            _dbContext = dbContext;
        }
            
        public async Task<int> Add(FormattableString sqlQuery)
        {
            var result = _dbContext.Database.SqlQuery<int>(sqlQuery).FirstOrDefaultAsync();
            await _dbContext.SaveChangesAsync();
            if(result != null)
            {
                return 1;
            }
            return 0                                                          ;
        }
        
        public async Task<int> Insert(FormattableString sqlQuery)
        {
            var result = await _dbContext.Database.ExecuteSqlInterpolatedAsync(sqlQuery);
            await _dbContext.SaveChangesAsync();
            return result;                                                        ;
        }

        public async Task<int> Delete(FormattableString sqlQuery)
        {
            var result = _dbContext.Database.ExecuteSqlInterpolated(sqlQuery);
            await _dbContext.SaveChangesAsync();
            return result;
               
         }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string query)
        {
            return await _dbContext.Set<TEntity>().FromSqlRaw(query).ToListAsync();
        }

        public async Task<TEntity> GetBrandById(FormattableString sqlQuery)
        {
            List<TEntity> query = await _dbContext.Set<TEntity>().FromSqlInterpolated(sqlQuery).ToListAsync();
            return query.FirstOrDefault();
        }


        public async Task<int> Update(FormattableString sqlQuery)
        {
            var result = _dbContext.Database.ExecuteSqlInterpolated(sqlQuery);
            await _dbContext.SaveChangesAsync();
            return result;
        }

    }
}
