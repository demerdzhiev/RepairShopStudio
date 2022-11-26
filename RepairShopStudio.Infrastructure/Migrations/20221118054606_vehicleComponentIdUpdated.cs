using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairShopStudio.Infrastructure.Migrations
{
    public partial class vehicleComponentIdUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7318b532-a8a8-4671-88c6-17f5ebd8edaa"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbce29b0-1b22-4643-a803-6ec468a0b6fd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e327a27b-c526-4e42-b7f0-ad1238633a5d"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("59bff60d-d8d8-4ca8-9da9-48149761e9db"), 0, "3b99a404-a7a5-41cd-8346-0f832e26d262", "mechanic_repair_shop@mail.com", false, null, null, false, null, "MECHANIC_REPAIR_SHOP@MAIL.COM", "MECHANIC", "AQAAAAEAACcQAAAAEPtWHkyXASSvD0lQX/hf/uTxOp8t9IOLC+JyJNQEYovhpaedWlsl3ViqNZP9T+BUxA==", null, false, "d131a283-9131-4130-a9a1-9cb5bcc2e835", false, "Mechanic" },
                    { new Guid("5eba88d2-5d07-4972-b92d-ce2623a09f0f"), 0, "b8764bdd-73c0-428d-8f8d-a5e2fd7a0b6b", "adviser_repair_shop@mail.com", false, null, null, false, null, "ADVISER_REPAIR_SHOP@MAIL.COM", "SERVICE_ADVISER", "AQAAAAEAACcQAAAAECnS8Vy7SjHwg4DoegFNJPWtu7hd2N38xMClDXcJezgYcKy1ypVUpuWewQZFvEyUGg==", null, false, "d4b2e9a7-1fc3-47dc-a0b4-32d41cff012f", false, "Service_Adviser" },
                    { new Guid("ee806874-faa8-4529-909f-8200e68d5e7c"), 0, "b32c9c1f-eaa7-4544-bff3-3a99942effa9", "manager_repair_shop@mail.com", false, null, null, false, null, "MANAGER_REPAIR_SHOP@MAIL.COM", "GENERAL_MANAGER", "AQAAAAEAACcQAAAAEDBrWV8jneBDMGH6ZMIafq2vEEx1YJe1/Of4gy+nOjgNuYxt/WbVTrKcs49PXjyE1w==", null, false, "3b714e47-61bc-452c-be59-005935c3415c", false, "General_Manager" }
                });

            migrationBuilder.UpdateData(
                table: "OperatingCards",
                keyColumn: "Id",
                keyValue: "badc0c29-a923-4f82-9f07-42417bf97c58",
                column: "ApplicationUserId",
                value: new Guid("fdc60d81-5ca6-4150-af96-2056e7bb396c"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("59bff60d-d8d8-4ca8-9da9-48149761e9db"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5eba88d2-5d07-4972-b92d-ce2623a09f0f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ee806874-faa8-4529-909f-8200e68d5e7c"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("7318b532-a8a8-4671-88c6-17f5ebd8edaa"), 0, "9173db1e-a391-47bb-a371-93c34bd204ec", "mechanic_repair_shop@mail.com", false, null, null, false, null, "MECHANIC_REPAIR_SHOP@MAIL.COM", "MECHANIC", "AQAAAAEAACcQAAAAEI0kW1g/+IvLbPMhDwpW5i5d2sJ7EUGQR+Lc2p2YXbopPzLLL2bDxNSWkldNXwvkPA==", null, false, "0747fca0-4763-4659-a545-d22f6a8c663e", false, "Mechanic" },
                    { new Guid("bbce29b0-1b22-4643-a803-6ec468a0b6fd"), 0, "7f30cf86-dd3d-4751-955e-a24077f8c4f7", "adviser_repair_shop@mail.com", false, null, null, false, null, "ADVISER_REPAIR_SHOP@MAIL.COM", "SERVICE_ADVISER", "AQAAAAEAACcQAAAAEH+l2xmd/xOwTHC7icTstZQXGl/SMC0BwkKDUNweKclHZivh2ssfjpxzrhH3hbQt0A==", null, false, "ba76c0a8-4a9e-4f3d-8a80-8e7e85f065d2", false, "Service_Adviser" },
                    { new Guid("e327a27b-c526-4e42-b7f0-ad1238633a5d"), 0, "11f1590e-2cc3-4bcb-ae6c-db188e983926", "manager_repair_shop@mail.com", false, null, null, false, null, "MANAGER_REPAIR_SHOP@MAIL.COM", "GENERAL_MANAGER", "AQAAAAEAACcQAAAAECChnk1ve/xtah3GpxepcKWGh2EyYL3xXCRPgU5Thqg+Nc7lZSP96fQ+tJjV5c7SRg==", null, false, "e4e11a55-65da-4963-9f95-b060db7200ff", false, "General_Manager" }
                });

            migrationBuilder.UpdateData(
                table: "OperatingCards",
                keyColumn: "Id",
                keyValue: "badc0c29-a923-4f82-9f07-42417bf97c58",
                column: "ApplicationUserId",
                value: new Guid("0401805e-b7e1-4d46-ad5f-60327310908c"));
        }
    }
}
