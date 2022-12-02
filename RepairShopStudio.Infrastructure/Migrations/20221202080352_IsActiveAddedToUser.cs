using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairShopStudio.Infrastructure.Migrations
{
    public partial class IsActiveAddedToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d3bb951-2772-4ae8-b6bb-eb4e80426b0e"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "IsActive", "LastName", "PasswordHash" },
                values: new object[] { "9bf66ef6-7892-4b08-b4b3-1394ba8fadd0", "Georgi", true, "Georgiev", "AQAAAAEAACcQAAAAEOoWPFgqW8CrfPxoKzdPSKnSQ0/6mjNkZJR7puRJ9eG8VO46whD0eddGVd4JhiuNNg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("59bff60d-d8d8-4ca8-9da9-48149761e9db"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "IsActive", "LastName", "PasswordHash" },
                values: new object[] { "54ad231c-6632-4352-863e-fc7cd65d3b59", "Petar", true, "Petrov", "AQAAAAEAACcQAAAAEHEiwjtHgWhMe4k5LaWa2UVHJFd6HXltvPkf5n3efW7k1u8M8M0rvaGWHWjB9SPs3g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8bc5851a-9b57-4d66-99ae-4bfd11f26bd2"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "IsActive", "LastName", "PasswordHash" },
                values: new object[] { "c8c65240-f264-4793-a61c-262ae6011e5b", "Ivan", true, "Ivanov", "AQAAAAEAACcQAAAAEOZUi8qwlOia86882RAr3Mq5HdmX/JO3mDCJjfWgR9CzKP+zL9d8TIBqGQliAC+nnA==" });

            migrationBuilder.UpdateData(
                table: "OperatingCards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "DocumentNumber" },
                values: new object[] { new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), "000112/2/2022 12:00:00 AM" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IssueDate", "Number" },
                values: new object[] { new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), "0001/12/2/2022 12:00:00 AM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d3bb951-2772-4ae8-b6bb-eb4e80426b0e"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "41b32cf4-94fa-424a-9765-b84eecd720d6", null, null, "AQAAAAEAACcQAAAAEDjQ3pMLZIuQr/ZS4siWWmeUybo7woq58XezeYLex03d/bveiTob29QexcSJIyxw+Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("59bff60d-d8d8-4ca8-9da9-48149761e9db"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "a0309938-31fa-4aea-a48a-bcb2efd5e63d", null, null, "AQAAAAEAACcQAAAAEAH7KkOEhWNS85hZa5/bvOtFS05fysXr7clpa4bKcvd1LXmc+oo2DwuRl+7YuFG2/w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8bc5851a-9b57-4d66-99ae-4bfd11f26bd2"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "8dccd13f-cd0e-4664-80b5-ac9012b6c971", null, null, "AQAAAAEAACcQAAAAEFexXCjZmPLlUNA1DN1hBl6XQd4L+rwfMwum+THX907NpGV61/6BjoFMP1SOm6sNjA==" });

            migrationBuilder.UpdateData(
                table: "OperatingCards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "DocumentNumber" },
                values: new object[] { new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), "000111/27/2022 12:00:00 AM" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IssueDate", "Number" },
                values: new object[] { new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), "0001/11/27/2022 12:00:00 AM" });
        }
    }
}
