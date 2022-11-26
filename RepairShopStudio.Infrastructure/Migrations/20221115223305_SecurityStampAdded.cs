using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairShopStudio.Infrastructure.Migrations
{
    public partial class SecurityStampAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31ab4d53-1790-40c1-8460-d92221a619ec"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("38c4b02f-67a2-4c17-9562-474edced3852"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7a17d8e6-71c9-4a7b-8caa-10741d9cebe7"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("57514874-1866-4d59-8a61-9a300d922f0e"), 0, "c02ed49b-d4e9-4b89-ac26-7aa676506649", "mechanic_repair_shop@mail.com", false, null, null, false, null, "MECHANIC_REPAIR_SHOP@MAIL.COM", "MECHANIC", "AQAAAAEAACcQAAAAEP9JJJ0/7Y7RFwGfgaQ5aiIXyJ1bUOPxUuRIm9gXWtg4/adhlawqC9a3Spl7yg5MPQ==", null, false, "ec6acb97-96ee-4b91-a4a8-8520059c6484", false, "Mechanic" },
                    { new Guid("65d45dba-236f-4306-bb49-82e584efabcf"), 0, "bb7c071b-01bf-487c-8ee5-f672f64aa8e0", "adviser_repair_shop@mail.com", false, null, null, false, null, "ADVISER_REPAIR_SHOP@MAIL.COM", "SERVICE_ADVISER", "AQAAAAEAACcQAAAAEClQ7CZZVtWldks6Y3r963FmtGEn2ZYcsiMvgpDo7jMXdzbhQ2VQNsdCJF0yW8X9Cw==", null, false, "c8ae01cf-238d-4f4e-9b0e-6edfe28b345b", false, "Service_Adviser" },
                    { new Guid("8bc5851a-9b57-4d66-99ae-4bfd11f26bd2"), 0, "022a5cfc-e23f-4f9b-9857-d4fae43cd070", "manager_repair_shop@mail.com", false, null, null, false, null, "MANAGER_REPAIR_SHOP@MAIL.COM", "GENERAL_MANAGER", "AQAAAAEAACcQAAAAEKdJu1lkBL+aodkzwXDuY0ksZB8w1clZP+LWJPYFBKsHEODVFHbg2puHQBg/Dm3OwQ==", null, false, "9986edc0-9168-4a1b-bc0f-5894524aa2e3", false, "General_Manager" }
                });

            migrationBuilder.UpdateData(
                table: "OperatingCards",
                keyColumn: "Id",
                keyValue: "badc0c29-a923-4f82-9f07-42417bf97c58",
                column: "ApplicationUserId",
                value: new Guid("3387638b-f57d-442b-8543-b8fc9dd5030b"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("57514874-1866-4d59-8a61-9a300d922f0e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("65d45dba-236f-4306-bb49-82e584efabcf"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8bc5851a-9b57-4d66-99ae-4bfd11f26bd2"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("31ab4d53-1790-40c1-8460-d92221a619ec"), 0, "5248e750-abed-4f03-89d6-178c0bc61801", "adviser_repair_shop@mail.com", false, null, null, false, null, "ADVISER_REPAIR_SHOP@MAIL.COM", "SERVICE_ADVISER", "AQAAAAEAACcQAAAAEApXVXHrUAy5kEioHBuR/58BM+OO9f73E12QU6lPlvGS+9WBiO6nQZXxzKoaGNUrLw==", null, false, null, false, "Service_Adviser" },
                    { new Guid("38c4b02f-67a2-4c17-9562-474edced3852"), 0, "a9288f19-f82e-4d9f-96f7-2c1c18094b3e", "manager_repair_shop@mail.com", false, null, null, false, null, "MANAGER_REPAIR_SHOP@MAIL.COM", "GENERAL_MANAGER", "AQAAAAEAACcQAAAAEEV5fEKGfXSC9HyG6A4KZnF4Tw7JS+gTREAVVBZY0bHVjKPWJLqZkX20EgwsFgUwAg==", null, false, null, false, "General_Manager" },
                    { new Guid("7a17d8e6-71c9-4a7b-8caa-10741d9cebe7"), 0, "f60c245c-e6b5-44d4-ac0b-db7f95a98064", "mechanic_repair_shop@mail.com", false, null, null, false, null, "MECHANIC_REPAIR_SHOP@MAIL.COM", "MECHANIC", "AQAAAAEAACcQAAAAEFR64I9kISdshD/oycqOMhQvhOw1YECW56QPHDc94OTHs9S+B2Q/DeeopCxeW9o6RQ==", null, false, null, false, "Mechanic" }
                });

            migrationBuilder.UpdateData(
                table: "OperatingCards",
                keyColumn: "Id",
                keyValue: "badc0c29-a923-4f82-9f07-42417bf97c58",
                column: "ApplicationUserId",
                value: new Guid("b7c58e41-c453-48ff-b24a-159a9d1d2c42"));
        }
    }
}
