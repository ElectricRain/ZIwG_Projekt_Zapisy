using Microsoft.EntityFrameworkCore;
using Project_ZIwG.Infrastructure.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ZIwG.Infrastructure.Repositories.EFRepository.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options) { }
        public DbSet<UserEntity> UserEntities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(250);
                entity.Property(e => e.Surname).HasMaxLength(250);
                entity.Property(e => e.EmailAddress).HasMaxLength(250);
                entity.Property(e => e.Password).HasMaxLength(250);

                entity.HasData(new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "admin", 
                    Surname = "admin", 
                    Password = "admin", 
                    EmailAddress = "Admin@pwr.edu.pl"
                });

                entity.HasData(new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "user",
                    Surname = "user",
                    Password = "user",
                    EmailAddress = "user@pwr.edu.pl"
                });
            });
        }
    }
}
