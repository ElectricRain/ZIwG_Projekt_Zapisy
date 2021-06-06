
using Project_ZIwG.Infrastructure.Entities;
using Project_ZIwG.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace Project_ZIwG.Domain.UserGetter
{
    public class UserGetter
    {
        private readonly IUserRepository _userRepository;

        public UserGetter(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserEntity Get(string userId)
            => _userRepository.Get(new Guid(userId));

        public IEnumerable<UserEntity> GetUsers()
            => _userRepository.GetList();
    }
}
