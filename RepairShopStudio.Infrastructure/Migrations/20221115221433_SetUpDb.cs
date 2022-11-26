using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairShopStudio.Infrastructure.Migrations
{
    public partial class SetUpDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressText = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Adrres text - street, number, etc."),
                    TownName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Town name"),
                    ZipCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false, comment: "ZIP code of the town")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                },
                comment: "Addres properties");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, comment: "User's first name"),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, comment: "User's last name"),
                    UserName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                },
                comment: "Additional user properties");

            migrationBuilder.CreateTable(
                name: "EngineTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Name of engine type")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineTypes", x => x.Id);
                },
                comment: "Type of the vehicle's engine");

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Job title")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.Id);
                },
                comment: "Possible job titles");

            migrationBuilder.CreateTable(
                name: "VehicleComponents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of vehicle component")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleComponents", x => x.Id);
                },
                comment: "The components/parts of the vehicle, which can be affected by the services");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Name of the customer"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false, comment: "Phone number of the cusotmer"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Email of the customer"),
                    IsCorporate = table.Column<bool>(type: "bit", nullable: false, comment: "Defines if the customer is corporate or individual"),
                    Uic = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, comment: "The Unit Identification Code of the customer's company"),
                    AddressId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "The address of the customer's office"),
                    ResponsiblePerson = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true, comment: "Name of the responsible person of the customer's company")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                },
                comment: "Customer information");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the supplier"),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the supplier's company"),
                    Uic = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Unit Identification Code of the supplier's company"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false, comment: "Phone number of the supplier's office"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Email of the supplier"),
                    AddressId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Address of the supplier's office")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Supplier, who delivers parts to the repair shop");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperatingCards",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the document"),
                    DocumentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The number of current document"),
                    TotalAmount = table.Column<decimal>(type: "money", precision: 18, scale: 2, nullable: false, comment: "The total amount of parts and services"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperatingCards_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatingCards_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Operating card for the current service");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Vehicle make name"),
                    Model = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Vehicle model name"),
                    LicensePLate = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, comment: "License plate of the vehicle"),
                    FIrstRegistration = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the first registration of the vehicle"),
                    EngineTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Engine type of the vehicle"),
                    Power = table.Column<int>(type: "int", nullable: false, comment: "Enginge power in Hp"),
                    VinNumber = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false, comment: "VIN number of the vehicle"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_EngineTypes_EngineTypeId",
                        column: x => x.EngineTypeId,
                        principalTable: "EngineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Vehicle, owned by customer");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Document number"),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the order"),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SupplierId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Supplier which will deliver the goods")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Order of parts properties");

            migrationBuilder.CreateTable(
                name: "ShopServices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Name of the service"),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false, comment: "Description of the service"),
                    Price = table.Column<decimal>(type: "money", precision: 18, scale: 2, nullable: false, comment: "Price of the service"),
                    VehicleComponentId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Affected part of the vehicle"),
                    OperatingCardId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopServices_OperatingCards_OperatingCardId",
                        column: x => x.OperatingCardId,
                        principalTable: "OperatingCards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShopServices_VehicleComponents_VehicleComponentId",
                        column: x => x.VehicleComponentId,
                        principalTable: "VehicleComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Services, offered by repair shop");

            migrationBuilder.CreateTable(
                name: "OperatingCardShopService",
                columns: table => new
                {
                    OperatingCardId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShopServiceId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingCardShopService", x => new { x.OperatingCardId, x.ShopServiceId });
                    table.ForeignKey(
                        name: "FK_OperatingCardShopService_OperatingCards_OperatingCardId",
                        column: x => x.OperatingCardId,
                        principalTable: "OperatingCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatingCardShopService_ShopServices_ShopServiceId",
                        column: x => x.ShopServiceId,
                        principalTable: "ShopServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the part"),
                    ImageUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false, comment: "Part's availability"),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Manufacturer's name of the part"),
                    OriginalMpn = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Part's MPN by the car manufacturer"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, comment: "Description of the part"),
                    PriceBuy = table.Column<decimal>(type: "money", precision: 18, scale: 2, nullable: false, comment: "Delivery price (by the supplier)"),
                    PriceSell = table.Column<decimal>(type: "money", precision: 18, scale: 2, nullable: false, comment: "Selling price (by the repair shop)"),
                    VehicleComponentId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Affected part of the vehicle, where the part may be used"),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ShopServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Parts_ShopServices_ShopServiceId",
                        column: x => x.ShopServiceId,
                        principalTable: "ShopServices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Parts_VehicleComponents_VehicleComponentId",
                        column: x => x.VehicleComponentId,
                        principalTable: "VehicleComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Part, stored in the shop's warehouse");

            migrationBuilder.CreateTable(
                name: "OperatingCardParts",
                columns: table => new
                {
                    OperatingCardId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PartId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingCardParts", x => new { x.OperatingCardId, x.PartId });
                    table.ForeignKey(
                        name: "FK_OperatingCardParts_OperatingCards_OperatingCardId",
                        column: x => x.OperatingCardId,
                        principalTable: "OperatingCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatingCardParts_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierSparePart",
                columns: table => new
                {
                    SupplierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PartId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OperatingCardId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierSparePart", x => new { x.SupplierId, x.PartId });
                    table.ForeignKey(
                        name: "FK_SupplierSparePart_OperatingCards_OperatingCardId",
                        column: x => x.OperatingCardId,
                        principalTable: "OperatingCards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupplierSparePart_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierSparePart_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Mapping entity between suppliers and parts");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressText", "TownName", "ZipCode" },
                values: new object[,]
                {
                    { "6a27fcd0-81f5-412d-80c8-39cc0f6c81f0", "Tsar Osvobodiltel str. 98", "Varna", "9000" },
                    { "f03b1057-88f7-47e2-a745-580c6150e371", "Slivnitsa blv. 108", "Varna", "9000" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("31ab4d53-1790-40c1-8460-d92221a619ec"), 0, "5248e750-abed-4f03-89d6-178c0bc61801", "adviser_repair_shop@mail.com", false, null, null, false, null, "ADVISER_REPAIR_SHOP@MAIL.COM", "SERVICE_ADVISER", "AQAAAAEAACcQAAAAEApXVXHrUAy5kEioHBuR/58BM+OO9f73E12QU6lPlvGS+9WBiO6nQZXxzKoaGNUrLw==", null, false, null, false, "Service_Adviser" },
                    { new Guid("38c4b02f-67a2-4c17-9562-474edced3852"), 0, "a9288f19-f82e-4d9f-96f7-2c1c18094b3e", "manager_repair_shop@mail.com", false, null, null, false, null, "MANAGER_REPAIR_SHOP@MAIL.COM", "GENERAL_MANAGER", "AQAAAAEAACcQAAAAEEV5fEKGfXSC9HyG6A4KZnF4Tw7JS+gTREAVVBZY0bHVjKPWJLqZkX20EgwsFgUwAg==", null, false, null, false, "General_Manager" },
                    { new Guid("7a17d8e6-71c9-4a7b-8caa-10741d9cebe7"), 0, "f60c245c-e6b5-44d4-ac0b-db7f95a98064", "mechanic_repair_shop@mail.com", false, null, null, false, null, "MECHANIC_REPAIR_SHOP@MAIL.COM", "MECHANIC", "AQAAAAEAACcQAAAAEFR64I9kISdshD/oycqOMhQvhOw1YECW56QPHDc94OTHs9S+B2Q/DeeopCxeW9o6RQ==", null, false, null, false, "Mechanic" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "Email", "IsCorporate", "Name", "PhoneNumber", "ResponsiblePerson", "Uic" },
                values: new object[] { "38dea0ea-cd19-49b9-a280-b869461def95", null, "boris.borisov@abv.bg", false, "Boris Borisov", "0898888888", null, null });

            migrationBuilder.InsertData(
                table: "EngineTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "026c3f78-94d5-4f4e-8e8f-fea783a8a93f", "Diesel" },
                    { "545F6ADA-C535-476A-8B65-A8E2ADEE5F7C", "Gasoline" },
                    { "e6c84886-dba7-4a1c-8448-60fcf66a71e0", "Hybrid" }
                });

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "093fd016-778f-4043-b72e-827c1834c4e2", "Mechanic" },
                    { "16afcac4-cb26-4c2e-9586-7cc4c2fab81c", "Service adviser" },
                    { "3bb29f58-330b-47d7-8c88-66e47a5fd4aa", "Manager" }
                });

            migrationBuilder.InsertData(
                table: "VehicleComponents",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "13ea9388-052b-4760-bd7d-3ad3eb04897a", "Steering system" },
                    { "46e751d0-07fc-4859-b95a-51048d4aeb1c", "Engine" },
                    { "6588d450-bda4-440d-a207-82ebe875c64f", "Tranmission system" },
                    { "88fb6d39-5500-48dd-893e-138cfde5b816", "Front and rear axle" },
                    { "6e3cb03f-7a41-426a-9c72-0cd609511ccd", "Tyres and brakes" },
                    { "eac3af63-bd7b-47a2-bde4-32987fe21ad2", "Suspenssion system" },
                    { "eeb24e1e-7978-4748-8591-466fdb72954e", "Body" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "Email", "IsCorporate", "Name", "PhoneNumber", "ResponsiblePerson", "Uic" },
                values: new object[] { "94eb73a3-e208-4409-bbed-4fc326255fdc", "6a27fcd0-81f5-412d-80c8-39cc0f6c81f0", "ivan.ivanov@abv.bg", true, "Ivan Ivanov", "099999999", "Ivan Ivanov", "1234543421234" });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "ImageUrl", "Manufacturer", "Name", "OrderId", "OriginalMpn", "PriceBuy", "PriceSell", "ShopServiceId", "Stock", "VehicleComponentId" },
                values: new object[] { "7349E46E-0F79-4D5A-8F09-A30B44BEDFA2", "Front", "https://www.zimmermann-bremsentechnik.eu/images/product_images/info_images/400_3649_52.jpg", "Zimmerman", "Sport Brake Disc for MERCEDES-BENZ M-KLASSE (W164)", null, "400.3649.52", 99.98m, 114.56m, null, 4, "6e3cb03f-7a41-426a-9c72-0cd609511ccd" });

            migrationBuilder.InsertData(
                table: "ShopServices",
                columns: new[] { "Id", "Description", "Name", "OperatingCardId", "Price", "VehicleComponentId" },
                values: new object[] { "7BDDE324-8E4A-4BBC-BF95-92DCF598A7A6", "Check all compnents in breaking sistem and repairing those that need it", "Breaks check and repairs", null, 65m, "6e3cb03f-7a41-426a-9c72-0cd609511ccd" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "AddressId", "CompanyName", "Email", "Name", "PhoneNumber", "Uic" },
                values: new object[] { "EDD4D809-A15C-4C6C-BC01-E6B4E9D23616", "f03b1057-88f7-47e2-a745-580c6150e371", "Garvan EOOD", "garvan@abv.bg", "Garvan", "0898888888", "123456789876" });

            migrationBuilder.InsertData(
                table: "OperatingCards",
                columns: new[] { "Id", "ApplicationUserId", "CustomerId", "Date", "Discount", "DocumentNumber", "TotalAmount" },
                values: new object[] { "badc0c29-a923-4f82-9f07-42417bf97c58", "7a17d8e6-71c9-4a7b-8caa-10741d9cebe7", "94eb73a3-e208-4409-bbed-4fc326255fdc", new DateTime(2022, 11, 16, 0, 0, 0, 0, DateTimeKind.Local), 10.0, "000111/16/2022 12:00:00 AM", 193.095m });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "IssueDate", "Note", "Number", "SupplierId" },
                values: new object[] { "9961AF43-3CC2-48EE-B760-89FC2CFACF20", new DateTime(2022, 11, 16, 0, 0, 0, 0, DateTimeKind.Local), "To arrive today", "0001/11/16/2022 12:00:00 AM", "EDD4D809-A15C-4C6C-BC01-E6B4E9D23616" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CustomerId", "EngineTypeId", "FIrstRegistration", "LicensePLate", "Make", "Model", "Power", "VinNumber" },
                values: new object[] { "6e3cb03f-7a41-426a-9c72-0cd609511ccd", "94eb73a3-e208-4409-bbed-4fc326255fdc", "545F6ADA-C535-476A-8B65-A8E2ADEE5F7C", new DateTime(2013, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "B5466HA", "Mercedes-Benz", "W164 350", 272, "12312324125" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingCardParts_PartId",
                table: "OperatingCardParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingCards_ApplicationUserId",
                table: "OperatingCards",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingCards_CustomerId",
                table: "OperatingCards",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingCardShopService_ShopServiceId",
                table: "OperatingCardShopService",
                column: "ShopServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SupplierId",
                table: "Orders",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_OrderId",
                table: "Parts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ShopServiceId",
                table: "Parts",
                column: "ShopServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_VehicleComponentId",
                table: "Parts",
                column: "VehicleComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopServices_OperatingCardId",
                table: "ShopServices",
                column: "OperatingCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopServices_VehicleComponentId",
                table: "ShopServices",
                column: "VehicleComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_AddressId",
                table: "Suppliers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierSparePart_OperatingCardId",
                table: "SupplierSparePart",
                column: "OperatingCardId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierSparePart_PartId",
                table: "SupplierSparePart",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CustomerId",
                table: "Vehicles",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EngineTypeId",
                table: "Vehicles",
                column: "EngineTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "OperatingCardParts");

            migrationBuilder.DropTable(
                name: "OperatingCardShopService");

            migrationBuilder.DropTable(
                name: "SupplierSparePart");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "EngineTypes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShopServices");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "OperatingCards");

            migrationBuilder.DropTable(
                name: "VehicleComponents");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
