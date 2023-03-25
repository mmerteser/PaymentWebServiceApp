﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Onix.Persistence.Context;

#nullable disable

namespace Onix.Persistence.Migrations
{
    [DbContext(typeof(OnixContext))]
    [Migration("20230128211507_Migration1")]
    partial class Migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Onix.Domain.Entities.ApplicationMenu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("ApplicationType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("MenuCode")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.ToTable("ApplicationMenu", "base");
                });

            modelBuilder.Entity("Onix.Domain.Entities.CompanyInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar")
                        .HasDefaultValue("");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.ToTable("CompanyInformations", "dbo");
                });

            modelBuilder.Entity("Onix.Domain.Entities.CompanyIntegratedApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("ApplicationName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar")
                        .HasDefaultValue("");

                    b.Property<string>("AuthenticationType")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar")
                        .HasDefaultValue("");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Password")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar")
                        .HasDefaultValue("");

                    b.Property<string>("SecurityKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar")
                        .HasDefaultValue("");

                    b.Property<string>("Type")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar")
                        .HasDefaultValue("");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Username")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar")
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyIntegratedApplications", "dbo");
                });

            modelBuilder.Entity("Onix.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar")
                        .HasDefaultValue("");

                    b.Property<string>("FirstLastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar")
                        .HasDefaultValue("");

                    b.Property<bool>("IsBlocked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar")
                        .HasDefaultValue("TR");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varbinary");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varbinary");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("CompanyId");

                    b.HasIndex("FirstLastName")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users", "dbo");
                });

            modelBuilder.Entity("Onix.Domain.Entities.UserErpInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("ErpPassword")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar")
                        .HasDefaultValue("");

                    b.Property<string>("ErpUserGroupCode")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar")
                        .HasDefaultValue("");

                    b.Property<string>("ErpUsername")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar")
                        .HasDefaultValue("");

                    b.Property<string>("OfficeCode")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar")
                        .HasDefaultValue("");

                    b.Property<int>("POSTerminalId")
                        .HasColumnType("int");

                    b.Property<string>("SalepersonCode")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar")
                        .HasDefaultValue("");

                    b.Property<string>("StoreCode")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar")
                        .HasDefaultValue("");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WarehouseCode")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar")
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserErpInformations", "dbo");
                });

            modelBuilder.Entity("Onix.Domain.Entities.UserMenu", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("Permission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("UserId", "MenuId");

                    b.HasIndex("MenuId");

                    b.ToTable("UserMenu", "dbo");
                });

            modelBuilder.Entity("Onix.Domain.Entities.CompanyIntegratedApplication", b =>
                {
                    b.HasOne("Onix.Domain.Entities.CompanyInformation", "CompanyInformation")
                        .WithMany("CompanyIntegratedApplications")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyInformation");
                });

            modelBuilder.Entity("Onix.Domain.Entities.User", b =>
                {
                    b.HasOne("Onix.Domain.Entities.CompanyInformation", "CompanyInformation")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyInformation");
                });

            modelBuilder.Entity("Onix.Domain.Entities.UserErpInformation", b =>
                {
                    b.HasOne("Onix.Domain.Entities.User", "User")
                        .WithOne("UserErpInformation")
                        .HasForeignKey("Onix.Domain.Entities.UserErpInformation", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Onix.Domain.Entities.UserMenu", b =>
                {
                    b.HasOne("Onix.Domain.Entities.ApplicationMenu", "ApplicationMenu")
                        .WithMany("UserMenus")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Onix.Domain.Entities.User", "User")
                        .WithMany("UserMenus")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationMenu");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Onix.Domain.Entities.ApplicationMenu", b =>
                {
                    b.Navigation("UserMenus");
                });

            modelBuilder.Entity("Onix.Domain.Entities.CompanyInformation", b =>
                {
                    b.Navigation("CompanyIntegratedApplications");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Onix.Domain.Entities.User", b =>
                {
                    b.Navigation("UserErpInformation")
                        .IsRequired();

                    b.Navigation("UserMenus");
                });
#pragma warning restore 612, 618
        }
    }
}
