using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api_Restful.Domain.Entities;
using Api_Restful.Domain.Interfaces;
using Domain.Interfaces.Services.User;

namespace Api_Restful.Service.Services
{
    public class UserService : IUserService
    {

        private readonly IRepository<UserEntity> _repository;

        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _repository.SelectAllAsync();
        }

        public async Task<UserEntity> Post(UserEntity user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<UserEntity> Put(UserEntity user)
        {
            return await _repository.UpdateAsync(user);
        }
    }
}
