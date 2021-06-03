using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ZIwG.Infrastructure.Entities
{
    public class TypeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Type Type { get; set; }

        public List<SubjectEntity> Subjects { get; set; }

        public List<UserPermissionEntity> UserPermissions { get; set; }
    }
}
