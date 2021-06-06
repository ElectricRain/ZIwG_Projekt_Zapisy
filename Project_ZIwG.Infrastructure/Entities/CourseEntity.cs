using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ZIwG.Infrastructure.Entities
{
    public class CourseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string CourseCode { get; set; }

        public string CourseName { get; set; }

        public string Description { get; set; }

        public virtual List<SubjectEntity> Subjects { get; set; }

        public virtual List<UserPermissionEntity> UserPermissions { get; set; }
    }
}
