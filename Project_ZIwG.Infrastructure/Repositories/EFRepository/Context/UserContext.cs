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
            PopulateTables(modelBuilder);
            CreateRelationships(modelBuilder);
        }

        private void PopulateTables(ModelBuilder modelBuilder)
        {
            PopulateUsers(modelBuilder);
            PopulateRoles(modelBuilder);
            PopulateUserRoles(modelBuilder);
            PopulateTypes(modelBuilder);
            PopulateCourses(modelBuilder);
            PopulateSubjects(modelBuilder);
            PoulateUserSucject(modelBuilder);
            PopulatePermissions(modelBuilder);
        }

        private void PopulatePermissions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPermissionEntity>(entity =>
            {
                entity.HasData(new UserPermissionEntity
                {
                    Id = new Guid("3b2bd2ab-943a-4f86-8953-640738f92e4e"),
                    UserId = new Guid("D8D964BA-872B-4A41-8552-25C7EC8203F9"),
                    CourseId = new Guid("9f5dad33-d44c-4806-b224-c05c8988d9cd"),
                    TypeId = new Guid("3ad58457-3b04-409a-a1b4-efb8d5438625")
                });

                entity.HasData(new UserPermissionEntity
                {
                    Id = new Guid("91d55eb4-4a9d-4dff-a807-8b498ee75283"),
                    UserId = new Guid("D8D964BA-872B-4A41-8552-25C7EC8203F9"),
                    CourseId = new Guid("9f5dad33-d44c-4806-b224-c05c8988d9cd"),
                    TypeId = new Guid("c230c06e-acfa-467e-8572-66d6fd7244c8")
                });

                entity.HasData(new UserPermissionEntity
                {
                    Id = new Guid("7611508a-470d-429e-a411-d8d2eba9f681"),
                    UserId = new Guid("ee4295be-fe35-4626-8f30-ae2f1ddb6c9d"),
                    CourseId = new Guid("9f5dad33-d44c-4806-b224-c05c8988d9cd"),
                    TypeId = new Guid("c230c06e-acfa-467e-8572-66d6fd7244c8")
                });
            });
        }

        private void PoulateUserSucject(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSubjectEntity>(entity =>
            {
                entity.HasData(new UserSubjectEntity
                {
                    Id = new Guid("fc81ad4a-7eca-486b-856b-77248dfb2c3b"),
                    SubjectId = new Guid("4a28f2c0-b1f5-458b-9b0b-c9a953e67e4d"),
                    UserId = new Guid("D8D964BA-872B-4A41-8552-25C7EC8203F9")
                });
            });
        }

        private void PopulateSubjects(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubjectEntity>( entity => 
            {
                entity.HasData(new SubjectEntity
                {
                    Id = new Guid("4bd509d3-62e8-460f-a767-bb9cce9bdcc7"),
                    CourseId = new Guid("9f5dad33-d44c-4806-b224-c05c8988d9cd"),
                    TypeId = new Guid("3ad58457-3b04-409a-a1b4-efb8d5438625"),
                    Day = DayOfWeek.Monday,
                    StartHour = new TimeSpan(7, 30, 00),
                    EndHour = new TimeSpan(9, 00, 00),
                    Parity = Parity.CoTydzien
                });

                entity.HasData(new SubjectEntity
                {
                    Id = new Guid("00dbb422-a300-4bba-b638-449911881cb8"),
                    CourseId = new Guid("9f5dad33-d44c-4806-b224-c05c8988d9cd"),
                    TypeId = new Guid("c230c06e-acfa-467e-8572-66d6fd7244c8"),
                    Day = DayOfWeek.Monday,
                    StartHour = new TimeSpan(9, 15, 00),
                    EndHour = new TimeSpan(10, 45, 00),
                    Parity = Parity.TydzienParzysty
                });

                entity.HasData(new SubjectEntity
                {
                    Id = new Guid("4a28f2c0-b1f5-458b-9b0b-c9a953e67e4d"),
                    CourseId = new Guid("9f5dad33-d44c-4806-b224-c05c8988d9cd"),
                    TypeId = new Guid("c230c06e-acfa-467e-8572-66d6fd7244c8"),
                    Day = DayOfWeek.Monday,
                    StartHour = new TimeSpan(9, 15, 00),
                    EndHour = new TimeSpan(10, 45, 00),
                    Parity = Parity.TydzienNieparzysty,
                });
            });
        }

        private void PopulateCourses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseEntity>(entity =>
            {
                entity.HasData(new CourseEntity
                {
                    Id = new Guid("9f5dad33-d44c-4806-b224-c05c8988d9cd"),
                    CourseName = "Zastosowanie Informatyki w Gospodarce",
                    CourseCode = "TEST1",
                    Description = "Zastosowanie"
                });

                entity.HasData(new CourseEntity
                {
                    Id = new Guid("93f79744-3c01-46cd-8a0a-033db5f264e7"),
                    CourseName = "Zastosowanie Informatyki w Medycynie",
                    CourseCode = "TEST2",
                    Description = "Zastosowanie"
                });

                entity.HasData(new CourseEntity
                {
                    Id = new Guid("cee182bb-82d1-44ed-ba66-8ae89c15fd7d"),
                    CourseName = "Modelowanie i Analiza Systemow Informatycznych",
                    CourseCode = "TEST3",
                    Description = "Modelowanie"
                });
            });
        }

        private void CreateRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                            .HasMany(x => x.UserSubjects)
                            .WithOne();

            modelBuilder.Entity<UserSubjectEntity>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserSubjects)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<SubjectEntity>()
                .HasOne(x => x.UserSubject)
                .WithOne();

            modelBuilder.Entity<UserSubjectEntity>()
                .HasOne(x => x.Subject)
                .WithOne(x => x.UserSubject);

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

        private void PopulateUsers(ModelBuilder modelBuilder)
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
                    Id = new Guid("ee4295be-fe35-4626-8f30-ae2f1ddb6c9d"),
                    Name = "user2",
                    Surname = "user2",
                    Password = "user2",
                    EmailAddress = "user2@pwr.edu.pl"
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
        }

        private void PopulateRoles(ModelBuilder modelBuilder)
        {
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
        }

        private void PopulateUserRoles(ModelBuilder modelBuilder)
        {
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
                    UserId = new Guid("ee4295be-fe35-4626-8f30-ae2f1ddb6c9d"),
                    RoleId = new Guid("6a3b2126-672d-4138-91b5-cb41016233f2")
                });

                entity.HasData(new UserRolesEntity
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("d0b164f9-7319-4434-ba68-b7d21e83b9af"),
                    RoleId = new Guid("4dfdfdd6-cb54-4be2-8842-7c80271fc907")
                });
            });
        }

        private void PopulateTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeEntity>(entity =>
            {
                entity.HasData(new TypeEntity
                {
                    Id = new Guid("3ad58457-3b04-409a-a1b4-efb8d5438625"),
                    Type = Entities.Type.Wyklad,
                    FullName = Enum.GetName(typeof(Entities.Type), Entities.Type.Wyklad)
                });

                entity.HasData(new TypeEntity
                {
                    Id = new Guid("c230c06e-acfa-467e-8572-66d6fd7244c8"),
                    Type = Entities.Type.Laboratorium,
                    FullName = Enum.GetName(typeof(Entities.Type), Entities.Type.Laboratorium)
                });

                entity.HasData(new TypeEntity
                {
                    Id = new Guid("3b67b49b-7666-4add-a39e-9eedcf30de45"),
                    Type = Entities.Type.Cwiczenia,
                    FullName = Enum.GetName(typeof(Entities.Type), Entities.Type.Cwiczenia)
                });

                entity.HasData(new TypeEntity
                {
                    Id = new Guid("fb43b254-491c-4d5a-93fe-ec12cb14eb68"),
                    Type = Entities.Type.Seminarium,
                    FullName = Enum.GetName(typeof(Entities.Type), Entities.Type.Seminarium)
                });

                entity.HasData(new TypeEntity
                {
                    Id = new Guid("477fd19e-89f5-4578-81ec-58971743963f"),
                    Type = Entities.Type.Projekt,
                    FullName = Enum.GetName(typeof(Entities.Type), Entities.Type.Projekt)
                });
            });
        }
    }
}
