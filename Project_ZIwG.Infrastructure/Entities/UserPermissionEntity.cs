using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ZIwG.Infrastructure.Entities
{
    public class UserPermissionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public Guid TypeId { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual CourseEntity Course { get; set; }
        public virtual TypeEntity Type { get; set; }
    }
}
