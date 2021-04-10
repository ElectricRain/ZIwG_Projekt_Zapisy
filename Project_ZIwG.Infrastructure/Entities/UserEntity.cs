using System;

namespace Project_ZIwG.Infrastructure.Entities
{
    public class UserEntity
    {

        public Guid Id { get; }

        public string EmailAddress { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }

        public UserEntity(string Name, string Surname, string Password, string EmailAddress)
        {
            this.Id = new Guid();
            this.Name = Name;
            this.Surname = Surname;
            this.Password = Password;
            this.EmailAddress = EmailAddress;
        }

        public UserEntity(string Name, string Surname, string Password, string EmailAddress, Guid Id)
        {
            this.Id = Id;
            this.Name = Name;
            this.Surname = Surname;
            this.Password = Password;
            this.EmailAddress = EmailAddress;
        }

    }
}
