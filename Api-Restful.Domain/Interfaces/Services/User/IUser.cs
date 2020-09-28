﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api_Restful.Domain.Entities;

namespace Domain.Interfaces.Services.User
{
    public interface IUser
    {
        Task<UserEntity> Get(Guid id);
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserEntity> Post(UserEntity user);
        Task<UserEntity> Put(UserEntity user);
        Task<bool> Delete(Guid id);
    }
}
