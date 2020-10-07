using System.Threading.Tasks;
using Api_Restful.Domain.Entities;
using Api_Restful.Domain.Interfaces;

namespace Domain.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);   
    }
}
