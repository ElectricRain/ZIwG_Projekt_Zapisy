using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_ZIwG.Infrastructure.Migrations
{
    public partial class xext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRolesEntities",
                keyColumn: "Id",
                keyValue: new Guid("2097bcc1-6aa8-487d-ad55-c7ac9182b314"));

            migrationBuilder.DeleteData(
                table: "UserRolesEntities",
                keyColumn: "Id",
                keyValue: new Guid("43586ccd-1ee5-4c61-85ec-ff19b228f506"));

            migrationBuilder.DeleteData(
                table: "UserRolesEntities",
                keyColumn: "Id",
                keyValue: new Guid("550cbff0-4353-45ce-863b-4c96d70b3f3b"));

            migrationBuilder.DeleteData(
                table: "UserRolesEntities",
                keyColumn: "Id",
                keyValue: new Guid("a0dca8e5-b6c7-417a-859c-71e544bf5497"));

            migrationBuilder.DeleteData(
                table: "UserRolesEntities",
                keyColumn: "Id",
                keyValue: new Guid("f2d3458a-f9ce-4c89-8fa9-5665f3f58f0c"));

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "TypeEntities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "CourseEntities",
                columns: new[] { "Id", "CourseCode", "CourseName", "Description" },
                values: new object[] { new Guid("9f5dad33-d44c-4806-b224-c05c8988d9cd"), "TEST1", "Zastosowanie Informatyki w Gospodarce", "Zastosowanie" });

            migrationBuilder.InsertData(
                table: "CourseEntities",
                columns: new[] { "Id", "CourseCode", "CourseName", "Description" },
                values: new object[] { new Guid("93f79744-3c01-46cd-8a0a-033db5f264e7"), "TEST2", "Zastosowanie Informatyki w Medycynie", "Zastosowanie" });

            migrationBuilder.InsertData(
                table: "CourseEntities",
                columns: new[] { "Id", "CourseCode", "CourseName", "Description" },
                values: new object[] { new Guid("cee182bb-82d1-44ed-ba66-8ae89c15fd7d"), "TEST3", "Modelowanie i Analiza Systemow Informatycznych", "Modelowanie" });

            migrationBuilder.InsertData(
                table: "TypeEntities",
                columns: new[] { "Id", "FullName", "Type" },
                values: new object[] { new Guid("3ad58457-3b04-409a-a1b4-efb8d5438625"), "Wyklad", 0 });

            migrationBuilder.InsertData(
                table: "TypeEntities",
                columns: new[] { "Id", "FullName", "Type" },
                values: new object[] { new Guid("c230c06e-acfa-467e-8572-66d6fd7244c8"), "Laboratorium", 1 });

            migrationBuilder.InsertData(
                table: "TypeEntities",
                columns: new[] { "Id", "FullName", "Type" },
                values: new object[] { new Guid("3b67b49b-7666-4add-a39e-9eedcf30de45"), "Cwiczenia", 2 });

            migrationBuilder.InsertData(
                table: "TypeEntities",
                columns: new[] { "Id", "FullName", "Type" },
                values: new object[] { new Guid("fb43b254-491c-4d5a-93fe-ec12cb14eb68"), "Seminarium", 3 });

            migrationBuilder.InsertData(
                table: "TypeEntities",
                columns: new[] { "Id", "FullName", "Type" },
                values: new object[] { new Guid("477fd19e-89f5-4578-81ec-58971743963f"), "Projekt", 4 });

            migrationBuilder.InsertData(
                table: "UserEntities",
                columns: new[] { "Id", "EmailAddress", "Name", "Password", "Surname" },
                values: new object[] { new Guid("ee4295be-fe35-4626-8f30-ae2f1ddb6c9d"), "user2@pwr.edu.pl", "user2", "user2", "user2" });

            migrationBuilder.InsertData(
                table: "UserRolesEntities",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("cb22fbd3-8ad8-4d9f-8b22-bb8ff3ca5c0e"), new Guid("bdf5aa4b-8b2f-4a45-a63d-a24464d728ad"), new Guid("201556a2-f780-4ea3-bd79-cf5cdd676e9e") });

            migrationBuilder.InsertData(
                table: "UserRolesEntities",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("51d27cac-879a-41e0-bcb4-286a28744cb1"), new Guid("6a3b2126-672d-4138-91b5-cb41016233f2"), new Guid("201556a2-f780-4ea3-bd79-cf5cdd676e9e") });

            migrationBuilder.InsertData(
                table: "UserRolesEntities",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("fc1103f6-1362-4ac2-b899-8f2c7e2354ed"), new Guid("4dfdfdd6-cb54-4be2-8842-7c80271fc907"), new Guid("201556a2-f780-4ea3-bd79-cf5cdd676e9e") });

            migrationBuilder.InsertData(
                table: "UserRolesEntities",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("862ba756-eea0-44dd-ba80-670d470f8329"), new Guid("6a3b2126-672d-4138-91b5-cb41016233f2"), new Guid("d8d964ba-872b-4a41-8552-25c7ec8203f9") });

            migrationBuilder.InsertData(
                table: "UserRolesEntities",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("790fe5ec-ca98-4c45-b0db-5272c1859bcd"), new Guid("4dfdfdd6-cb54-4be2-8842-7c80271fc907"), new Guid("d0b164f9-7319-4434-ba68-b7d21e83b9af") });

            migrationBuilder.InsertData(
                table: "SubjectEntities",
                columns: new[] { "Id", "CourseId", "Day", "EndHour", "Parity", "StartHour", "TypeId" },
                values: new object[] { new Guid("4bd509d3-62e8-460f-a767-bb9cce9bdcc7"), new Guid("9f5dad33-d44c-4806-b224-c05c8988d9cd"), 1, new TimeSpan(0, 9, 0, 0, 0), 0, new TimeSpan(0, 7, 30, 0, 0), new Guid("3ad58457-3b04-409a-a1b4-efb8d5438625") });

            migrationBuilder.InsertData(
                table: "SubjectEntities",
                columns: new[] { "Id", "CourseId", "Day", "EndHour", "Parity", "StartHour", "TypeId" },
                values: new object[] { new Guid("00dbb422-a300-4bba-b638-449911881cb8"), new Guid("9f5dad33-d44c-4806-b224-c05c8988d9cd"), 1, new TimeSpan(0, 10, 45, 0, 0), 2, new TimeSpan(0, 9, 15, 0, 0), new Guid("c230c06e-acfa-467e-8572-66d6fd7244c8") });

            migrationBuilder.InsertData(
                table: "SubjectEntities",
                columns: new[] { "Id", "CourseId", "Day", "EndHour", "Parity", "StartHour", "TypeId" },
                values: new object[] { new Guid("4a28f2c0-b1f5-458b-9b0b-c9a953e67e4d"), new Guid("9f5dad33-d44c-4806-b224-c05c8988d9cd"), 1, new TimeSpan(0, 10, 45, 0, 0), 1, new TimeSpan(0, 9, 15, 0, 0), new Guid("c230c06e-acfa-467e-8572-66d6fd7244c8") });

            migrationBuilder.InsertData(
                table: "UserPermissionEntities",
                columns: new[] { "Id", "CourseId", "TypeId", "UserId" },
                values: new object[] { new Guid("3b2bd2ab-943a-4f86-8953-640738f92e4e"), new Guid("9f5dad33-d44c-4806-b224-c05c8988d9cd"), new Guid("3ad58457-3b04-409a-a1b4-efb8d5438625"), new Guid("d8d964ba-872b-4a41-8552-25c7ec8203f9") });

            migrationBuilder.InsertData(
                table: "UserPermissionEntities",
                columns: new[] { "Id", "CourseId", "TypeId", "UserId" },
                values: new object[] { new Guid("91d55eb4-4a9d-4dff-a807-8b498ee75283"), new Guid("9f5dad33-d44c-4806-b224-c05c8988d9cd"), new Guid("c230c06e-acfa-467e-8572-66d6fd7244c8"), new Guid("d8d964ba-872b-4a41-8552-25c7ec8203f9") });

            migrationBuilder.InsertData(
                table: "UserPermissionEntities",
                columns: new[] { "Id", "CourseId", "TypeId", "UserId" },
                values: new object[] { new Guid("7611508a-470d-429e-a411-d8d2eba9f681"), new Guid("9f5dad33-d44c-4806-b224-c05c8988d9cd"), new Guid("c230c06e-acfa-467e-8572-66d6fd7244c8"), new Guid("ee4295be-fe35-4626-8f30-ae2f1ddb6c9d") });

            migrationBuilder.InsertData(
                table: "UserRolesEntities",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("29dac5d4-6b10-487f-9ed2-243fa469e412"), new Guid("6a3b2126-672d-4138-91b5-cb41016233f2"), new Guid("ee4295be-fe35-4626-8f30-ae2f1ddb6c9d") });

            migrationBuilder.InsertData(
                table: "UserSubjectEntities",
                columns: new[] { "Id", "SubjectId", "UserId" },
                values: new object[] { new Guid("fc81ad4a-7eca-486b-856b-77248dfb2c3b"), new Guid("4a28f2c0-b1f5-458b-9b0b-c9a953e67e4d"), new Guid("d8d964ba-872b-4a41-8552-25c7ec8203f9") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseEntities",
                keyColumn: "Id",
                keyValue: new Guid("93f79744-3c01-46cd-8a0a-033db5f264e7"));

            migrationBuilder.DeleteData(
                table: "CourseEntities",
                keyColumn: "Id",
                keyValue: new Guid("cee182bb-82d1-44ed-ba66-8ae89c15fd7d"));

            migrationBuilder.DeleteData(
                table: "SubjectEntities",
                keyColumn: "Id",
                keyValue: new Guid("00dbb422-a300-4bba-b638-449911881cb8"));

            migrationBuilder.DeleteData(
                table: "SubjectEntities",
                keyColumn: "Id",
                keyValue: new Guid("4bd509d3-62e8-460f-a767-bb9cce9bdcc7"));

            migrationBuilder.DeleteData(
                table: "TypeEntities",
                keyColumn: "Id",
                keyValue: new Guid("3b67b49b-7666-4add-a39e-9eedcf30de45"));

            migrationBuilder.DeleteData(
                table: "TypeEntities",
                keyColumn: "Id",
                keyValue: new Guid("477fd19e-89f5-4578-81ec-58971743963f"));

            migrationBuilder.DeleteData(
                table: "TypeEntities",
                keyColumn: "Id",
                keyValue: new Guid("fb43b254-491c-4d5a-93fe-ec12cb14eb68"));

            migrationBuilder.DeleteData(
                table: "UserPermissionEntities",
                keyColumn: "Id",
                keyValue: new Guid("3b2bd2ab-943a-4f86-8953-640738f92e4e"));

            migrationBuilder.DeleteData(
                table: "UserPermissionEntities",
                keyColumn: "Id",
                keyValue: new Guid("7611508a-470d-429e-a411-d8d2eba9f681"));

            migrationBuilder.DeleteData(
                table: "UserPermissionEntities",
                keyColumn: "Id",
                keyValue: new Guid("91d55eb4-4a9d-4dff-a807-8b498ee75283"));

            migrationBuilder.DeleteData(
                table: "UserRolesEntities",
                keyColumn: "Id",
                keyValue: new Guid("29dac5d4-6b10-487f-9ed2-243fa469e412"));

            migrationBuilder.DeleteData(
                table: "UserRolesEntities",
                keyColumn: "Id",
                keyValue: new Guid("51d27cac-879a-41e0-bcb4-286a28744cb1"));

            migrationBuilder.DeleteData(
                table: "UserRolesEntities",
                keyColumn: "Id",
                keyValue: new Guid("790fe5ec-ca98-4c45-b0db-5272c1859bcd"));

            migrationBuilder.DeleteData(
                table: "UserRolesEntities",
                keyColumn: "Id",
                keyValue: new Guid("862ba756-eea0-44dd-ba80-670d470f8329"));

            migrationBuilder.DeleteData(
                table: "UserRolesEntities",
                keyColumn: "Id",
                keyValue: new Guid("cb22fbd3-8ad8-4d9f-8b22-bb8ff3ca5c0e"));

            migrationBuilder.DeleteData(
                table: "UserRolesEntities",
                keyColumn: "Id",
                keyValue: new Guid("fc1103f6-1362-4ac2-b899-8f2c7e2354ed"));

            migrationBuilder.DeleteData(
                table: "UserSubjectEntities",
                keyColumn: "Id",
                keyValue: new Guid("fc81ad4a-7eca-486b-856b-77248dfb2c3b"));

            migrationBuilder.DeleteData(
                table: "SubjectEntities",
                keyColumn: "Id",
                keyValue: new Guid("4a28f2c0-b1f5-458b-9b0b-c9a953e67e4d"));

            migrationBuilder.DeleteData(
                table: "TypeEntities",
                keyColumn: "Id",
                keyValue: new Guid("3ad58457-3b04-409a-a1b4-efb8d5438625"));

            migrationBuilder.DeleteData(
                table: "UserEntities",
                keyColumn: "Id",
                keyValue: new Guid("ee4295be-fe35-4626-8f30-ae2f1ddb6c9d"));

            migrationBuilder.DeleteData(
                table: "CourseEntities",
                keyColumn: "Id",
                keyValue: new Guid("9f5dad33-d44c-4806-b224-c05c8988d9cd"));

            migrationBuilder.DeleteData(
                table: "TypeEntities",
                keyColumn: "Id",
                keyValue: new Guid("c230c06e-acfa-467e-8572-66d6fd7244c8"));

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "TypeEntities");

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
        }
    }
}
