﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sispar.Infra.EF;

namespace Sispar.Infra.Migrations
{
    [DbContext(typeof(SisparDataContext))]
    [Migration("20200606020130_AdicionadoCamposDeleteTither")]
    partial class AdicionadoCamposDeleteTither
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sispar.Domain.TitheModule.Tithe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateContribution")
                        .HasColumnType("date");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TitherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ValueContribution")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("TitherId");

                    b.ToTable("Tithes");
                });

            modelBuilder.Entity("Sispar.Domain.TitherModule.Tither", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("Active")
                        .HasColumnType("smallint");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("AddressComplent")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("AddressNumber")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Cellphone")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("DateBirthSpouse")
                        .HasColumnType("date");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("MarriegeDate")
                        .HasColumnType("date");

                    b.Property<short>("MatiralStatus")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("NameSpouse")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Neighborhood")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.HasKey("Id");

                    b.ToTable("Tithers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0baaddd4-39bf-4aff-8cdb-fe57ecc661db"),
                            Active = (short)1,
                            Address = "rua sem saida",
                            BirthDate = new DateTime(2020, 6, 6, 2, 1, 30, 10, DateTimeKind.Utc).AddTicks(295),
                            CPF = "999.999.999-99",
                            Cellphone = "11 9.9999-9999",
                            DateBirthSpouse = new DateTime(2020, 6, 6, 2, 1, 30, 10, DateTimeKind.Utc).AddTicks(7354),
                            Deleted = false,
                            MarriegeDate = new DateTime(2020, 6, 6, 2, 1, 30, 10, DateTimeKind.Utc).AddTicks(4855),
                            MatiralStatus = (short)0,
                            Name = "Jose",
                            NameSpouse = "Maria",
                            RegisterDate = new DateTime(2020, 6, 6, 2, 1, 30, 9, DateTimeKind.Utc).AddTicks(7974),
                            Telephone = "11 9.9999-9999"
                        });
                });

            modelBuilder.Entity("Sispar.Domain.UserModule.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("Active")
                        .HasColumnType("smallint");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7067daa5-0ea9-4105-bc94-405e33987654"),
                            Active = (short)1,
                            FirstName = "Felipe",
                            LastName = "Santos",
                            Password = "916c1678d3d28eb3e7798b9cf7acfbb6",
                            RegisterDate = new DateTime(2020, 6, 6, 2, 1, 29, 971, DateTimeKind.Utc).AddTicks(179),
                            Username = "milton"
                        },
                        new
                        {
                            Id = new Guid("97889751-8611-4cb2-a6d4-5fa9611b870d"),
                            Active = (short)1,
                            FirstName = "Milton",
                            LastName = "Honji",
                            Password = "916c1678d3d28eb3e7798b9cf7acfbb6",
                            RegisterDate = new DateTime(2020, 6, 6, 2, 1, 30, 5, DateTimeKind.Utc).AddTicks(5100),
                            Username = "felipe"
                        });
                });

            modelBuilder.Entity("Sispar.Domain.TitheModule.Tithe", b =>
                {
                    b.HasOne("Sispar.Domain.TitherModule.Tither", "Tither")
                        .WithMany("Tithes")
                        .HasForeignKey("TitherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
