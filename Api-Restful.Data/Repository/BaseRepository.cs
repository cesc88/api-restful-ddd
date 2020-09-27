using System;
using System.Collections;
using System.Threading.Tasks;
using Api_Restful.Data.Context;
using Api_Restful.Domain.Entities;
using Api_Restful.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api_Restful.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MyContext _context;
        private DbSet<T> _dataset;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(x => x.Id == id);
                if (result == null)
                    return false;

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                }

                entity.CreateAt = DateTime.UtcNow;
                _dataset.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return entity;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable> SelectAllAsync()
        {
            try
            {
                return await _dataset.ToArrayAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return  await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(x => x.Id == entity.Id);
                if (result == null)
                    return null;

                entity.UpdateAt = DateTime.UtcNow;
                entity.CreateAt = result.CreateAt;

                _context.Entry(result).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return entity;
        }
    }
}