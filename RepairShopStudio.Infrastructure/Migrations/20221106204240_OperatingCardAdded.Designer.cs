﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepairShopStudio.Infrastructure.Data;

#nullable disable

namespace RepairShopStudio.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221106204240_OperatingCardAdded")]
    partial class OperatingCardAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Account.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("User's first name");

                    b.Property<string>("LastName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("User's last name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasComment("Additional user properties");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the address");

                    b.Property<string>("AddressText")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Adrres text - street, number, etc.");

                    b.Property<string>("TownName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Town name");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)")
                        .HasComment("ZIP code of the town");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasComment("Addres properties");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Customer Id");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The address of the customer's office");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Email of the customer");

                    b.Property<bool>("IsCorporate")
                        .HasColumnType("bit")
                        .HasComment("Defines if the customer is corporate or individual");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasComment("Name of the customer");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)")
                        .HasComment("Phone number of the cusotmer");

                    b.Property<string>("ResponsiblePerson")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasComment("Name of the responsible person of the customer's company");

                    b.Property<string>("Uic")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("The Unit Identification Code of the customer's company");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Customers");

                    b.HasComment("Customer information");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the employee");

                    b.Property<Guid>("JobTitleId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Job title of the employee");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasComment("Employee name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)")
                        .HasComment("Phone number of the employee");

                    b.HasKey("Id");

                    b.HasIndex("JobTitleId");

                    b.ToTable("Employees");

                    b.HasComment("Employee properties");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.EngineType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the engine type");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("Name of engine type");

                    b.HasKey("Id");

                    b.ToTable("EngineTypes");

                    b.HasComment("Type of the vehicle's engine");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.JobTitle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the job title");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Job title");

                    b.HasKey("Id");

                    b.ToTable("JobTitles");

                    b.HasComment("Possible job titles");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.OperatingCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the operating card");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasComment("Date of the creation of the document");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("The number of current document");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("OperatingCards");

                    b.HasComment("Operating card for the current service");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the order");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date of the creation of the order");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Document number");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Supplier which will deliver the goods");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Orders");

                    b.HasComment("Order of parts properties");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Part", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the part");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Description of the part");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Manufacturer's name of the part");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("The name of the part");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OriginalMpn")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Part's MPN by the car manufacturer");

                    b.Property<decimal>("PriceBuy")
                        .HasPrecision(18, 2)
                        .HasColumnType("money")
                        .HasComment("Delivery price (by the supplier)");

                    b.Property<decimal>("PriceSell")
                        .HasPrecision(18, 2)
                        .HasColumnType("money")
                        .HasComment("Selling price (by the repair shop)");

                    b.Property<Guid?>("ShopServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasComment("Part's availability");

                    b.Property<Guid>("VehicleComponentId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Affected part of the vehicle, where the part may be used");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ShopServiceId");

                    b.HasIndex("VehicleComponentId");

                    b.ToTable("Parts");

                    b.HasComment("Part, stored in the shop's warehouse");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.ShopService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the service");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasComment("Description of the service");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasComment("Name of the service");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("money")
                        .HasComment("Price of the service");

                    b.Property<Guid>("VehicleComponentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VehicleComponentId");

                    b.HasIndex("VehicleId");

                    b.ToTable("ShopServices");

                    b.HasComment("Services, offered by repair shop");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the supplier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Address of the supplier's office");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Name of the supplier's company");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Email of the supplier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Name of the supplier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)")
                        .HasComment("Phone number of the supplier's office");

                    b.Property<string>("Uic")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Unit Identification Code of the supplier's company");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Suppliers");

                    b.HasComment("Supplier, who delivers parts to the repair shop");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.SupplierSparePart", b =>
                {
                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PartId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SupplierId", "PartId");

                    b.HasIndex("PartId");

                    b.ToTable("SupplierSparePart");

                    b.HasComment("Mapping entity between suppliers and parts");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the vehicle");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EngineTypeId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Engine type of the vehicle");

                    b.Property<DateTime>("FIrstRegistration")
                        .HasColumnType("datetime2")
                        .HasComment("Date of the first registration of the vehicle");

                    b.Property<string>("LicensePLate")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasComment("License plate of the vehicle");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Vehicle make name");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasComment("Vehicle model name");

                    b.Property<int>("Power")
                        .HasColumnType("int")
                        .HasComment("Enginge power in Hp");

                    b.Property<string>("VinNumber")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)")
                        .HasComment("VIN number of the vehicle");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EngineTypeId");

                    b.ToTable("Vehicles");

                    b.HasComment("Vehicle, owned by customer");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.VehicleComponent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the vehicle component");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Name of vehicle component");

                    b.HasKey("Id");

                    b.ToTable("VehicleComponents");

                    b.HasComment("The components/parts of the vehicle, which can be affected by the services");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.Account.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.Account.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.Account.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.Account.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Customer", b =>
                {
                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Employee", b =>
                {
                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.JobTitle", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobTitle");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.OperatingCard", b =>
                {
                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Order", b =>
                {
                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Part", b =>
                {
                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.Order", null)
                        .WithMany("Parts")
                        .HasForeignKey("OrderId");

                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.ShopService", null)
                        .WithMany("Parts")
                        .HasForeignKey("ShopServiceId");

                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.VehicleComponent", "VehicleComponent")
                        .WithMany()
                        .HasForeignKey("VehicleComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleComponent");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.ShopService", b =>
                {
                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.VehicleComponent", "VehicleComponent")
                        .WithMany()
                        .HasForeignKey("VehicleComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.Vehicle", null)
                        .WithMany("RepairsHistory")
                        .HasForeignKey("VehicleId");

                    b.Navigation("VehicleComponent");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Supplier", b =>
                {
                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.SupplierSparePart", b =>
                {
                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.Part", "Part")
                        .WithMany("SupplierSpareParts")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.Supplier", "Supplier")
                        .WithMany("SupplierSpareParts")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Part");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Vehicle", b =>
                {
                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.Customer", "Customer")
                        .WithMany("Vehicles")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairShopStudio.Infrastructure.Data.Models.EngineType", "EngineType")
                        .WithMany()
                        .HasForeignKey("EngineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("EngineType");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Customer", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Order", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Part", b =>
                {
                    b.Navigation("SupplierSpareParts");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.ShopService", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Supplier", b =>
                {
                    b.Navigation("SupplierSpareParts");
                });

            modelBuilder.Entity("RepairShopStudio.Infrastructure.Data.Models.Vehicle", b =>
                {
                    b.Navigation("RepairsHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
