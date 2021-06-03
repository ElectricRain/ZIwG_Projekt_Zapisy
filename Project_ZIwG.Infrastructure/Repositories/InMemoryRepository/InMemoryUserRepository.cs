using Project_ZIwG.Infrastructure.Entities;
using Project_ZIwG.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_ZIwG.Infrastructure.Repositories.InMemoryRepository
{
    public class InMemoryUserRepository : IUserRepository
    {
        private List<UserEntity> _userRepository = new List<UserEntity>();
        public InMemoryUserRepository()
        {            
            AddTemplateEntities();
        }

        public void Create(UserEntity entity)
        {
            _userRepository.Add(entity);
        }

        public void Delete(Guid entityId)
        {
            _userRepository.RemoveAll(x => x.Id == entityId);
        }

        public UserEntity Get(Guid entityId)
        {
            var user = _userRepository.FirstOrDefault(x => x.Id == entityId);
            return user;
        }

        public UserEntity GetByUsername(string username)
        {
            var user = _userRepository.FirstOrDefault(x => x.Name == username);
            return user;
        }

        public IEnumerable<UserEntity> GetList()
        {
            foreach(var user in _userRepository)
            {
                yield return user;
            }
        }

        public void Update(UserEntity entity)
        {
            var user = _userRepository.FirstOrDefault(x => x.Id == entity.Id);
            user.Name = entity.Name;
            user.Password = entity.Password;
            user.Surname = entity.Surname;
            user.EmailAddress = entity.EmailAddress;
        }

        private void AddTemplateEntities()
        {
            Create(new UserEntity("Admin", "Admin", "Admin", "Admin@pwr.edu.pl"));
            Create(new UserEntity("User", "User", "User", "User@pwr.edu.pl"));
        }
    }
}
