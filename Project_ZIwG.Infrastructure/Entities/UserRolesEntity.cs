using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ZIwG.Infrastructure.Entities
{
    public class UserRolesEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual RolesEntity Role { get; set; }
    }
}
