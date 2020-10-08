using System;
using System.Threading.Tasks;
using Api_Restful.Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Repository;

namespace Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _repository;

        public LoginService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> FindByLogin(UserEntity user)
        {
            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                return await _repository.FindByLogin(user.Email);
            }
            else
            {
                return null;
            }
        }
    }
}
