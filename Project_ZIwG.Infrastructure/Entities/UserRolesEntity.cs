﻿using System;

namespace Project_ZIwG.Infrastructure.Entities
{
    public class UserRolesEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
