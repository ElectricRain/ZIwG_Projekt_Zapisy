using System;

namespace Project_ZIwG.Infrastructure.Entities
{
    public class UserPermissionEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid CourseId { get; set; }

        public Guid GuidId { get; set; }
    }
}
