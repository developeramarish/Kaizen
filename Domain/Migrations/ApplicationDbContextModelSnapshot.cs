﻿// <auto-generated />
using System;
using Kaizen.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kaizen.Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Kaizen.Domain.Entities.Activity", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.HasIndex("ClientId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.ActivityEmployee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<int>("ActivityCode")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "ActivityCode");

                    b.HasIndex("ActivityCode");

                    b.ToTable("ActivitiesEmployees");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.ActivityService", b =>
                {
                    b.Property<int>("ActivityCode")
                        .HasColumnType("int");

                    b.Property<string>("ServiceCode")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.HasKey("ActivityCode", "ServiceCode");

                    b.HasIndex("ServiceCode");

                    b.ToTable("ActivitiesServices");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(191) CHARACTER SET utf8mb4")
                        .HasMaxLength(191);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("varchar(191) CHARACTER SET utf8mb4")
                        .HasMaxLength(191);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.Client", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("BusninessName")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("ClientType")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("FirstLandLine")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("FirstPhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("NIT")
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.Property<string>("SecondLandLine")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("SecondLastName")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("SecondName")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("SecondPhoneNumber")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("TradeName")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(191) CHARACTER SET utf8mb4")
                        .HasMaxLength(191);

                    b.HasKey("Id");

                    b.HasIndex("NIT")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.ClientAddress", b =>
                {
                    b.Property<string>("ClientId")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("City")
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.Property<string>("Neighborhood")
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.Property<string>("Street")
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.HasKey("ClientId");

                    b.ToTable("ClientAddresses");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.ContactPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ContactPeople");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.DataSheet", b =>
                {
                    b.Property<string>("ProductCode")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.HasKey("ProductCode");

                    b.ToTable("DataSheet");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.EmergencyCard", b =>
                {
                    b.Property<string>("ProductCode")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.HasKey("ProductCode");

                    b.ToTable("EmergencyCard");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<int>("ChargeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("SecondLastName")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("SecondName")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(191) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ChargeId");

                    b.HasIndex("UserId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.EmployeeCharge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Charge")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("EmployeeCharges");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Charge = "Gerente"
                        },
                        new
                        {
                            Id = 2,
                            Charge = "Coordinador de Calidad y Ambiente"
                        },
                        new
                        {
                            Id = 3,
                            Charge = "Contador"
                        },
                        new
                        {
                            Id = 4,
                            Charge = "Lider SST"
                        },
                        new
                        {
                            Id = 5,
                            Charge = "Auxiliar Administrativa"
                        },
                        new
                        {
                            Id = 6,
                            Charge = "Técnico Operativo Lider"
                        },
                        new
                        {
                            Id = 7,
                            Charge = "Técnico Operativo"
                        },
                        new
                        {
                            Id = 8,
                            Charge = "Aprendiz"
                        });
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.EmployeeService", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("ServiceCode")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.HasKey("EmployeeId", "ServiceCode");

                    b.HasIndex("ServiceCode");

                    b.ToTable("EmployeesServices");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.Equipment", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<DateTime>("MaintenanceDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("Code");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.EquipmentService", b =>
                {
                    b.Property<string>("EquipmentCode")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("ServiceCode")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.HasKey("EquipmentCode", "ServiceCode");

                    b.HasIndex("ServiceCode");

                    b.ToTable("EquipmentsServices");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.Product", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ApplicationMonths")
                        .HasColumnType("int");

                    b.Property<string>("HealthRegister")
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.HasKey("Code");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.ProductService", b =>
                {
                    b.Property<string>("ServiceCode")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("ProductCode")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.HasKey("ServiceCode", "ProductCode");

                    b.HasIndex("ProductCode");

                    b.ToTable("ProductsServices");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.SafetySheet", b =>
                {
                    b.Property<string>("ProductCode")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.HasKey("ProductCode");

                    b.ToTable("SafetySheet");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.Service", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.Property<int>("ServiceTypeId")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.ServiceRequest", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("State")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Code");

                    b.HasIndex("ClientId");

                    b.ToTable("ServiceRequests");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.ServiceRequestService", b =>
                {
                    b.Property<string>("ServiceCode")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<int>("ServiceRequestCode")
                        .HasColumnType("int");

                    b.HasKey("ServiceCode", "ServiceRequestCode");

                    b.HasIndex("ServiceRequestCode");

                    b.ToTable("ServiceRequestsServices");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.ServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(70) CHARACTER SET utf8mb4")
                        .HasMaxLength(70);

                    b.HasKey("Id");

                    b.ToTable("ServiceTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Control de plagas"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Saneamiento"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Limpieza de espacios"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Lavado y desinfección de tanques de agua"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Captura y rehabilidación de animales domesticos"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Jardineria"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(191) CHARACTER SET utf8mb4")
                        .HasMaxLength(191);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar(191) CHARACTER SET utf8mb4")
                        .HasMaxLength(191);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "3bb4b79d-85a4-4a94-b55e-5619c9acf4a2",
                            ConcurrencyStamp = "1ed77447-fe5c-42c2-9711-3f91cc103255",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "e88f6181-e86a-49e1-a2da-c79c71914624",
                            ConcurrencyStamp = "177cda8b-1541-411e-8891-62f58b0e45fa",
                            Name = "OfficeEmployee",
                            NormalizedName = "OFFICEEMPLOYEE"
                        },
                        new
                        {
                            Id = "e6728857-7423-443f-8228-2c8dd22f3aab",
                            ConcurrencyStamp = "501614ae-a5ad-4ee3-ba6f-17c28ab1cd5d",
                            Name = "TechnicalEmployee",
                            NormalizedName = "TECHNICALEMPLOYEE"
                        },
                        new
                        {
                            Id = "a988a9ea-c7a5-4329-aceb-3da5016c6a43",
                            ConcurrencyStamp = "fba45aab-42d7-4e12-9dc0-44a2f68badf1",
                            Name = "Client",
                            NormalizedName = "CLIENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(191) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(191) CHARACTER SET utf8mb4");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(191) CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(191) CHARACTER SET utf8mb4");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.Activity", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.ActivityEmployee", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.Activity", "Activity")
                        .WithMany("ActivitiesEmployees")
                        .HasForeignKey("ActivityCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kaizen.Domain.Entities.Employee", "Employee")
                        .WithMany("EmployeesActivities")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.ActivityService", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.Activity", "Activity")
                        .WithMany("ActivitiesServices")
                        .HasForeignKey("ActivityCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kaizen.Domain.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.Client", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.ClientAddress", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.Client", "Client")
                        .WithOne("ClientAddress")
                        .HasForeignKey("Kaizen.Domain.Entities.ClientAddress", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.ContactPerson", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.Client", "Client")
                        .WithMany("ContactPeople")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.DataSheet", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.Product", "Product")
                        .WithOne("DataSheet")
                        .HasForeignKey("Kaizen.Domain.Entities.DataSheet", "ProductCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.EmergencyCard", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.Product", "Product")
                        .WithOne("EmergencyCard")
                        .HasForeignKey("Kaizen.Domain.Entities.EmergencyCard", "ProductCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.Employee", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.EmployeeCharge", "EmployeeCharge")
                        .WithMany()
                        .HasForeignKey("ChargeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kaizen.Domain.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.EmployeeService", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.Employee", "Employee")
                        .WithMany("EmployeesServices")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kaizen.Domain.Entities.Service", "Service")
                        .WithMany("EmployeesServices")
                        .HasForeignKey("ServiceCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.EquipmentService", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.Equipment", "Equipment")
                        .WithMany("EquipmentsServices")
                        .HasForeignKey("EquipmentCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kaizen.Domain.Entities.Service", "Service")
                        .WithMany("EquipmentsServices")
                        .HasForeignKey("ServiceCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.ProductService", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.Product", "Product")
                        .WithMany("ProductsServices")
                        .HasForeignKey("ProductCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kaizen.Domain.Entities.Service", "Service")
                        .WithMany("ProductsServices")
                        .HasForeignKey("ServiceCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.SafetySheet", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.Product", "Product")
                        .WithOne("SafetySheet")
                        .HasForeignKey("Kaizen.Domain.Entities.SafetySheet", "ProductCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.Service", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.ServiceType", "ServiceType")
                        .WithMany()
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.ServiceRequest", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kaizen.Domain.Entities.ServiceRequestService", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.Service", "Service")
                        .WithMany("ServiceRequestsServices")
                        .HasForeignKey("ServiceCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kaizen.Domain.Entities.ServiceRequest", "ServiceRequest")
                        .WithMany("ServiceRequestsServices")
                        .HasForeignKey("ServiceRequestCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("Kaizen.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.ApplicationUser", null)
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

                    b.HasOne("Kaizen.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Kaizen.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
