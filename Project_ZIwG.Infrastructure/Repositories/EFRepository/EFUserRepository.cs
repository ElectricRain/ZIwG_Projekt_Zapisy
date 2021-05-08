using Microsoft.EntityFrameworkCore;
using Project_ZIwG.Infrastructure.Entities;
using Project_ZIwG.Infrastructure.Interfaces;
using Project_ZIwG.Infrastructure.Repositories.EFRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_ZIwG.Infrastructure.Repositories.EFRepository
{
    public class EFUserRepository : IUserRepository
    {
        private UserContext _context;
        public EFUserRepository(UserContext context)
        {
            _context = context;
        }

        public void Create(UserEntity entity)
        {
            _context.UserEntities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid entityId)
        {
            _context.UserEntities.Remove(Get(entityId));
            _context.SaveChanges();
        }

        public UserEntity Get(Guid entityId)
        {
            var user = _context.UserEntities.Where(e => e.Id == entityId).FirstOrDefault();
            return user;
        }

        public UserEntity GetByUsername(string username)
        {
            var user = _context.UserEntities.Where(e => e.Name == username).FirstOrDefault();
            return user;
        }

        public IEnumerable<UserEntity> GetList()
        {
            var user = _context.UserEntities.ToList();
            return user;
        }

        public void Update(UserEntity entity)
        {
            var result = _context.UserEntities.SingleOrDefault(e => e.Id == entity.Id);
            if (result != null)
            {
                result.Name = entity.Name;
                result.Surname = entity.Surname;
                result.Password = entity.Password;
                result.EmailAddress = entity.EmailAddress;
                _context.SaveChanges();
            }
        }
    }
}
