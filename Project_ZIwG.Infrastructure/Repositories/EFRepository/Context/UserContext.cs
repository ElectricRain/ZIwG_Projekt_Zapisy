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
        public DbSet<CourseEntity> CourseEntities { get; set; }
        public DbSet<RolesEntity> RolesEntities { get; set; }
        public DbSet<SubjectEntity> SubjectEntities { get; set; }
        public DbSet<TypeEntity> TypeEntities { get; set; }
        public DbSet<UserPermissionEntity> UserPermissionEntities { get; set; }
        public DbSet<UserRolesEntity> UserRolesEntities { get; set; }
        public DbSet<UserSubjectEntity> UserSubjectEntities { get; set; }


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
                    Id = new Guid("201556A2-F780-4EA3-BD79-CF5CDD676E9E"),
                    Name = "admin", 
                    Surname = "admin", 
                    Password = "admin", 
                    EmailAddress = "Admin@pwr.edu.pl"
                });

                entity.HasData(new UserEntity
                {
                    Id = new Guid("D8D964BA-872B-4A41-8552-25C7EC8203F9"),
                    Name = "user",
                    Surname = "user",
                    Password = "user",
                    EmailAddress = "user@pwr.edu.pl"
                });

                entity.HasData(new UserEntity
                {
                    Id = new Guid("d0b164f9-7319-4434-ba68-b7d21e83b9af"),
                    Name = "creator",
                    Surname = "creator",
                    Password = "creator",
                    EmailAddress = "creator@pwr.edu.pl"
                });
            });

            modelBuilder.Entity<RolesEntity>(entity =>
            {
                entity.HasData(new RolesEntity
                {
                    Id = new Guid("bdf5aa4b-8b2f-4a45-a63d-a24464d728ad"),
                    RoleName = "Admin"
                });

                entity.HasData(new RolesEntity
                {
                    Id = new Guid("6a3b2126-672d-4138-91b5-cb41016233f2"),
                    RoleName = "Lecturer"
                });

                entity.HasData(new RolesEntity
                {
                    Id = new Guid("4dfdfdd6-cb54-4be2-8842-7c80271fc907"),
                    RoleName = "Creator"
                });
            });

            modelBuilder.Entity<UserRolesEntity>(entity =>
            {
                entity.HasData(new UserRolesEntity
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("201556A2-F780-4EA3-BD79-CF5CDD676E9E"),
                    RoleId = new Guid("bdf5aa4b-8b2f-4a45-a63d-a24464d728ad")
                });

                entity.HasData(new UserRolesEntity
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("201556A2-F780-4EA3-BD79-CF5CDD676E9E"),
                    RoleId = new Guid("6a3b2126-672d-4138-91b5-cb41016233f2")
                });

                entity.HasData(new UserRolesEntity
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("201556A2-F780-4EA3-BD79-CF5CDD676E9E"),
                    RoleId = new Guid("4dfdfdd6-cb54-4be2-8842-7c80271fc907")
                });

                entity.HasData(new UserRolesEntity
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("D8D964BA-872B-4A41-8552-25C7EC8203F9"),
                    RoleId = new Guid("6a3b2126-672d-4138-91b5-cb41016233f2")
                });

                entity.HasData(new UserRolesEntity
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("d0b164f9-7319-4434-ba68-b7d21e83b9af"),
                    RoleId = new Guid("4dfdfdd6-cb54-4be2-8842-7c80271fc907")
                });
            });

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.UserSubjects)
                .WithOne();

            modelBuilder.Entity<UserSubjectEntity>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserSubjects)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<SubjectEntity>()
                .HasMany(x => x.UserSubjects)
                .WithOne();

            modelBuilder.Entity<UserSubjectEntity>()
                .HasOne(x => x.Subject)
                .WithMany(x => x.UserSubjects)
                .HasForeignKey(x => x.SubjectId);

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.UserRoles)
                .WithOne();

            modelBuilder.Entity<UserRolesEntity>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<RolesEntity>()
                .HasMany(x => x.UserRoles)
                .WithOne();

            modelBuilder.Entity<UserRolesEntity>()
                .HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.UserPermissions)
                .WithOne();

            modelBuilder.Entity<UserPermissionEntity>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserPermissions)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<CourseEntity>()
                .HasMany(x => x.UserPermissions)
                .WithOne();

            modelBuilder.Entity<UserPermissionEntity>()
                .HasOne(x => x.Course)
                .WithMany(x => x.UserPermissions)
                .HasForeignKey(x => x.CourseId);

            modelBuilder.Entity<TypeEntity>()
                .HasMany(x => x.UserPermissions)
                .WithOne();

            modelBuilder.Entity<UserPermissionEntity>()
                .HasOne(x => x.Type)
                .WithMany(x => x.UserPermissions)
                .HasForeignKey(x => x.TypeId);

            modelBuilder.Entity<CourseEntity>()
                .HasMany(x => x.Subjects)
                .WithOne();

            modelBuilder.Entity<SubjectEntity>()
                .HasOne(x => x.Course)
                .WithMany(x => x.Subjects)
                .HasForeignKey(x => x.CourseId);

            modelBuilder.Entity<TypeEntity>()
                .HasMany(x => x.Subjects)
                .WithOne();

            modelBuilder.Entity<SubjectEntity>()
                .HasOne(x => x.Type)
                .WithMany(x => x.Subjects)
                .HasForeignKey(x => x.TypeId);
        }
    }
}
