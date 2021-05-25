
using Project_ZIwG.Infrastructure.Entities;
using Project_ZIwG.Infrastructure.Interfaces;
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

        public UserEntity GetByUsername(string username)
            => _userRepository.GetByUsername(username);

        public IEnumerable<UserEntity> GetUsers()
            => _userRepository.GetList();
    }
}
