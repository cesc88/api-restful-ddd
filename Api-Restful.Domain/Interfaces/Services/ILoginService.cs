using System.Threading.Tasks;
using Domain.Dtos;

namespace Domain.Interfaces.Services
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto user);
    }
}
