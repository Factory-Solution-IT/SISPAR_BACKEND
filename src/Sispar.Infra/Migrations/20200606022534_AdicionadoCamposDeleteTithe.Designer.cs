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
    [Migration("20200606022534_AdicionadoCamposDeleteTithe")]
    partial class AdicionadoCamposDeleteTithe
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

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

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
                            Id = new Guid("fadab4d9-f14a-4ec1-b62d-e49c304ff64e"),
                            Active = (short)1,
                            Address = "rua sem saida",
                            BirthDate = new DateTime(2020, 6, 6, 2, 25, 33, 470, DateTimeKind.Utc).AddTicks(3401),
                            CPF = "999.999.999-99",
                            Cellphone = "11 9.9999-9999",
                            DateBirthSpouse = new DateTime(2020, 6, 6, 2, 25, 33, 470, DateTimeKind.Utc).AddTicks(8109),
                            Deleted = false,
                            MarriegeDate = new DateTime(2020, 6, 6, 2, 25, 33, 470, DateTimeKind.Utc).AddTicks(6428),
                            MatiralStatus = (short)0,
                            Name = "Jose",
                            NameSpouse = "Maria",
                            RegisterDate = new DateTime(2020, 6, 6, 2, 25, 33, 470, DateTimeKind.Utc).AddTicks(1601),
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

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

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
                            Id = new Guid("62875d2b-2a9b-4347-a0bc-a2267a19222b"),
                            Active = (short)1,
                            Deleted = false,
                            FirstName = "Felipe",
                            LastName = "Santos",
                            Password = "916c1678d3d28eb3e7798b9cf7acfbb6",
                            RegisterDate = new DateTime(2020, 6, 6, 2, 25, 33, 457, DateTimeKind.Utc).AddTicks(6887),
                            Username = "milton"
                        },
                        new
                        {
                            Id = new Guid("1aa3f943-1088-4ca9-9351-97f1a5076436"),
                            Active = (short)1,
                            Deleted = false,
                            FirstName = "Milton",
                            LastName = "Honji",
                            Password = "916c1678d3d28eb3e7798b9cf7acfbb6",
                            RegisterDate = new DateTime(2020, 6, 6, 2, 25, 33, 468, DateTimeKind.Utc).AddTicks(1258),
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
