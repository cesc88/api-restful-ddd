using System.Threading.Tasks;
using Api_Restful.Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface ILoginService
    {
        Task<object> FindByLogin(UserEntity user);
    }
}
