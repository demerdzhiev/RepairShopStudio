using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairShopStudio.Infrastructure.Migrations
{
    public partial class OperatingCardAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperatingCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id of the operating card"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the document"),
                    DocumentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The number of current document"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperatingCards_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatingCards_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Operating card for the current service");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingCards_CustomerId",
                table: "OperatingCards",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingCards_EmployeeId",
                table: "OperatingCards",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperatingCards");
        }
    }
}
