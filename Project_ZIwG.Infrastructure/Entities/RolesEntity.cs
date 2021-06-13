using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ZIwG.Infrastructure.Entities
{
    public class RolesEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string RoleName { get; set; }

        public virtual List<UserRolesEntity> UserRoles { get; set; }
    }
}
