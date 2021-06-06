using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_ZIwG.Infrastructure.Migrations
{
    public partial class seconmiation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CourseCode = table.Column<string>(type: "TEXT", nullable: true),
                    CourseName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolesEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Surname = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Password = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Day = table.Column<int>(type: "INTEGER", nullable: false),
                    StartHour = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndHour = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Parity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectEntities_CourseEntities_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CourseEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectEntities_TypeEntities_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TypeEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissionEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TypeId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissionEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPermissionEntities_CourseEntities_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CourseEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermissionEntities_TypeEntities_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TypeEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermissionEntities_UserEntities_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRolesEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolesEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRolesEntities_RolesEntities_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RolesEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRolesEntities_UserEntities_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSubjectEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SubjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubjectEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubjectEntities_SubjectEntities_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSubjectEntities_UserEntities_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RolesEntities",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("bdf5aa4b-8b2f-4a45-a63d-a24464d728ad"), "Admin" });

            migrationBuilder.InsertData(
                table: "RolesEntities",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("6a3b2126-672d-4138-91b5-cb41016233f2"), "Lecturer" });

            migrationBuilder.InsertData(
                table: "RolesEntities",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("4dfdfdd6-cb54-4be2-8842-7c80271fc907"), "Creator" });

            migrationBuilder.InsertData(
                table: "UserEntities",
                columns: new[] { "Id", "EmailAddress", "Name", "Password", "Surname" },
                values: new object[] { new Guid("201556a2-f780-4ea3-bd79-cf5cdd676e9e"), "Admin@pwr.edu.pl", "admin", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "UserEntities",
                columns: new[] { "Id", "EmailAddress", "Name", "Password", "Surname" },
                values: new object[] { new Guid("d8d964ba-872b-4a41-8552-25c7ec8203f9"), "user@pwr.edu.pl", "user", "user", "user" });

            migrationBuilder.InsertData(
                table: "UserEntities",
                columns: new[] { "Id", "EmailAddress", "Name", "Password", "Surname" },
                values: new object[] { new Guid("d0b164f9-7319-4434-ba68-b7d21e83b9af"), "creator@pwr.edu.pl", "creator", "creator", "creator" });

            migrationBuilder.InsertData(
                table: "UserRolesEntities",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("550cbff0-4353-45ce-863b-4c96d70b3f3b"), new Guid("bdf5aa4b-8b2f-4a45-a63d-a24464d728ad"), new Guid("201556a2-f780-4ea3-bd79-cf5cdd676e9e") });

            migrationBuilder.InsertData(
                table: "UserRolesEntities",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("43586ccd-1ee5-4c61-85ec-ff19b228f506"), new Guid("6a3b2126-672d-4138-91b5-cb41016233f2"), new Guid("201556a2-f780-4ea3-bd79-cf5cdd676e9e") });

            migrationBuilder.InsertData(
                table: "UserRolesEntities",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("2097bcc1-6aa8-487d-ad55-c7ac9182b314"), new Guid("4dfdfdd6-cb54-4be2-8842-7c80271fc907"), new Guid("201556a2-f780-4ea3-bd79-cf5cdd676e9e") });

            migrationBuilder.InsertData(
                table: "UserRolesEntities",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("f2d3458a-f9ce-4c89-8fa9-5665f3f58f0c"), new Guid("6a3b2126-672d-4138-91b5-cb41016233f2"), new Guid("d8d964ba-872b-4a41-8552-25c7ec8203f9") });

            migrationBuilder.InsertData(
                table: "UserRolesEntities",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("a0dca8e5-b6c7-417a-859c-71e544bf5497"), new Guid("4dfdfdd6-cb54-4be2-8842-7c80271fc907"), new Guid("d0b164f9-7319-4434-ba68-b7d21e83b9af") });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectEntities_CourseId",
                table: "SubjectEntities",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectEntities_TypeId",
                table: "SubjectEntities",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissionEntities_CourseId",
                table: "UserPermissionEntities",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissionEntities_TypeId",
                table: "UserPermissionEntities",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissionEntities_UserId",
                table: "UserPermissionEntities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolesEntities_RoleId",
                table: "UserRolesEntities",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolesEntities_UserId",
                table: "UserRolesEntities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubjectEntities_SubjectId",
                table: "UserSubjectEntities",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubjectEntities_UserId",
                table: "UserSubjectEntities",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPermissionEntities");

            migrationBuilder.DropTable(
                name: "UserRolesEntities");

            migrationBuilder.DropTable(
                name: "UserSubjectEntities");

            migrationBuilder.DropTable(
                name: "RolesEntities");

            migrationBuilder.DropTable(
                name: "SubjectEntities");

            migrationBuilder.DropTable(
                name: "UserEntities");

            migrationBuilder.DropTable(
                name: "CourseEntities");

            migrationBuilder.DropTable(
                name: "TypeEntities");
        }
    }
}
