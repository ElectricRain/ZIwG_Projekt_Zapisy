using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ZIwG.Infrastructure.Entities
{
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string EmailAddress { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }

        public List<UserPermissionEntity> UserPermissions { get; set; }

        public virtual List<UserRolesEntity> UserRoles { get; set; }

        public List<UserSubjectEntity> UserSubjects { get; set; }

        public UserEntity()
        {
            this.Id = Guid.NewGuid();
            this.Name = string.Empty;
            this.Surname = string.Empty;
            this.Password = string.Empty;
            this.EmailAddress = string.Empty;
        }

        public UserEntity(string Name, string Surname, string Password, string EmailAddress)
        {
            this.Id = Guid.NewGuid();
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
