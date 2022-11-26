using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairShopStudio.Infrastructure.Migrations
{
    public partial class IsActivePropertyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ShopServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Parts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2f4c33aa-ea83-4e8b-a8b2-45bee6041080"), 0, "286dbe16-1910-46f3-a4ba-98b18717a1ad", "manager_repair_shop@mail.com", false, null, null, false, null, "MANAGER_REPAIR_SHOP@MAIL.COM", "GENERAL_MANAGER", "AQAAAAEAACcQAAAAEDJfI7EH3TryuBxJobVE8A9hcGuu1vWiFa/PtdX/cOTF3/Zde1cRb2yil0S0bL2x8g==", null, false, "eef5adc2-99ec-496e-9ced-8fbd450ab453", false, "General_Manager" },
                    { new Guid("48e8db2e-06e1-4ce7-bf09-fda5bff97607"), 0, "e45acfcb-7a34-48b5-9a4c-230cffc6f23b", "mechanic_repair_shop@mail.com", false, null, null, false, null, "MECHANIC_REPAIR_SHOP@MAIL.COM", "MECHANIC", "AQAAAAEAACcQAAAAEA0XSJtnVzBh+lwzXRzTDN8w82PV2IztTlYOwmS7t3dXKfplLMBdzOXe6KKd3oL1UA==", null, false, "3ce79b30-0b92-4fc6-a909-33a1e4f1141d", false, "Mechanic" },
                    { new Guid("4d3bb951-2772-4ae8-b6bb-eb4e80426b0e"), 0, "8b5dffb1-7a86-4733-bf9a-97f58c83b3f3", "adviser_repair_shop@mail.com", false, null, null, false, null, "ADVISER_REPAIR_SHOP@MAIL.COM", "SERVICE_ADVISER", "AQAAAAEAACcQAAAAEC/76W5ceWCcjvyfSK4aCgTNMPf/+G+TNcL62SByREgQgaJFaWmo4ZTQ9U92k6cc6A==", null, false, "c4fd9946-0e15-48fe-8808-77a2b5c45e8a", false, "Service_Adviser" }
                });

            migrationBuilder.UpdateData(
                table: "OperatingCards",
                keyColumn: "Id",
                keyValue: "badc0c29-a923-4f82-9f07-42417bf97c58",
                columns: new[] { "ApplicationUserId", "Date", "DocumentNumber" },
                values: new object[] { new Guid("4982014f-1a4b-460b-971b-8ae40d564a8f"), new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Local), "000111/20/2022 12:00:00 AM" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "9961AF43-3CC2-48EE-B760-89FC2CFACF20",
                columns: new[] { "IsActive", "IssueDate", "Number" },
                values: new object[] { true, new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Local), "0001/11/20/2022 12:00:00 AM" });

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: "7349E46E-0F79-4D5A-8F09-A30B44BEDFA2",
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "ShopServices",
                keyColumn: "Id",
                keyValue: "7BDDE324-8E4A-4BBC-BF95-92DCF598A7A6",
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2f4c33aa-ea83-4e8b-a8b2-45bee6041080"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("48e8db2e-06e1-4ce7-bf09-fda5bff97607"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d3bb951-2772-4ae8-b6bb-eb4e80426b0e"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ShopServices");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Orders");

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
                columns: new[] { "ApplicationUserId", "Date", "DocumentNumber" },
                values: new object[] { new Guid("fdc60d81-5ca6-4150-af96-2056e7bb396c"), new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Local), "000111/18/2022 12:00:00 AM" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: "9961AF43-3CC2-48EE-B760-89FC2CFACF20",
                columns: new[] { "IssueDate", "Number" },
                values: new object[] { new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Local), "0001/11/18/2022 12:00:00 AM" });
        }
    }
}
