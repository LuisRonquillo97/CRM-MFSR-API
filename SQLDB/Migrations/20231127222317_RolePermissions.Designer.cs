﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SQLDB.Context;

#nullable disable

namespace SQLDB.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20231127222317_RolePermissions")]
    partial class RolePermissions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("DeactivatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeactivatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("04e0e210-bd83-40d3-8610-4d671991bbd8"),
                            CreatedAt = new DateTime(2023, 11, 27, 22, 23, 16, 524, DateTimeKind.Utc).AddTicks(7293),
                            CreatedBy = "MainSeed",
                            Description = "See all users for the role Admin.",
                            IsActive = true,
                            Key = "User.See",
                            Name = "See users"
                        },
                        new
                        {
                            Id = new Guid("0d585130-d133-43ba-a726-5604ddaa81de"),
                            CreatedAt = new DateTime(2023, 11, 27, 22, 23, 16, 524, DateTimeKind.Utc).AddTicks(7297),
                            CreatedBy = "MainSeed",
                            Description = "CRUD users. Only for the role Admin.",
                            IsActive = true,
                            Key = "User.Crud",
                            Name = "CRUD users"
                        });
                });

            modelBuilder.Entity("Entities.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("DeactivatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeactivatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("baa6230e-bb80-4952-b156-45e127f1d511"),
                            CreatedAt = new DateTime(2023, 11, 27, 16, 23, 16, 524, DateTimeKind.Local).AddTicks(7267),
                            CreatedBy = "mainSeed",
                            Description = "Has full permissions.",
                            IsActive = true,
                            Name = "Administrator"
                        });
                });

            modelBuilder.Entity("Entities.Models.RolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("DeactivatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeactivatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1094bade-087b-4eca-b0c3-c0bc47e52b7a"),
                            CreatedAt = new DateTime(2023, 11, 27, 16, 23, 16, 524, DateTimeKind.Local).AddTicks(7316),
                            CreatedBy = "",
                            IsActive = true,
                            PermissionId = new Guid("04e0e210-bd83-40d3-8610-4d671991bbd8"),
                            RoleId = new Guid("baa6230e-bb80-4952-b156-45e127f1d511")
                        },
                        new
                        {
                            Id = new Guid("742530ea-2432-4bc0-b938-e3f14645a676"),
                            CreatedAt = new DateTime(2023, 11, 27, 16, 23, 16, 524, DateTimeKind.Local).AddTicks(7319),
                            CreatedBy = "",
                            IsActive = true,
                            PermissionId = new Guid("0d585130-d133-43ba-a726-5604ddaa81de"),
                            RoleId = new Guid("baa6230e-bb80-4952-b156-45e127f1d511")
                        });
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("DeactivatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeactivatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3fac7eef-44f2-4f7b-bd6b-8f6457248865"),
                            CreatedAt = new DateTime(2023, 11, 27, 16, 23, 16, 524, DateTimeKind.Local).AddTicks(7116),
                            CreatedBy = "mainSeed",
                            Email = "admin@mail.com",
                            FirstName = "First",
                            IsActive = true,
                            LastName = "Admin",
                            Password = "Password"
                        });
                });

            modelBuilder.Entity("Entities.Models.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("DeactivatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeactivatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f7948c9b-bac2-4795-8fab-e66ff1c57d48"),
                            CreatedAt = new DateTime(2023, 11, 27, 22, 23, 16, 524, DateTimeKind.Utc).AddTicks(7344),
                            CreatedBy = "mainSeed",
                            IsActive = true,
                            RoleId = new Guid("baa6230e-bb80-4952-b156-45e127f1d511"),
                            UserId = new Guid("3fac7eef-44f2-4f7b-bd6b-8f6457248865")
                        });
                });

            modelBuilder.Entity("Entities.Models.RolePermission", b =>
                {
                    b.HasOne("Entities.Models.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Entities.Models.UserRole", b =>
                {
                    b.HasOne("Entities.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("Entities.Models.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
