using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api_Restful.Domain.Entities;

namespace Api_Restful.Domain.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAllAsync();
        Task<bool> ExistAsync(Guid id);
    }
}