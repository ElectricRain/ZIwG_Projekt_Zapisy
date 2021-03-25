using System;

namespace Project_ZIwG.Infrastructure.Entities
{
    public class UserEntity
    {

        public Guid Id { get; set; }

        public string Username { get; private set; }

        private string Password { get; set; }

    }
}
