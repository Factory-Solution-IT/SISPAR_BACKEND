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
    [Migration("20200607014834_CorrigidoNomeAddressComplement")]
    partial class CorrigidoNomeAddressComplement
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

                    b.Property<string>("AddressComplement")
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
                            Id = new Guid("08660d0c-30c4-4958-bd5e-19b19b96b533"),
                            Active = (short)1,
                            Address = "rua sem saida",
                            BirthDate = new DateTime(2020, 6, 7, 1, 48, 33, 831, DateTimeKind.Utc).AddTicks(8764),
                            CPF = "999.999.999-99",
                            Cellphone = "11 9.9999-9999",
                            DateBirthSpouse = new DateTime(2020, 6, 7, 1, 48, 33, 832, DateTimeKind.Utc).AddTicks(4516),
                            Deleted = false,
                            MarriegeDate = new DateTime(2020, 6, 7, 1, 48, 33, 832, DateTimeKind.Utc).AddTicks(2287),
                            MatiralStatus = (short)0,
                            Name = "Jose",
                            NameSpouse = "Maria",
                            RegisterDate = new DateTime(2020, 6, 7, 1, 48, 33, 831, DateTimeKind.Utc).AddTicks(6776),
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
                            Id = new Guid("abf70193-dcb2-44f3-9579-66f4f0cc6b61"),
                            Active = (short)1,
                            Deleted = false,
                            FirstName = "Felipe",
                            LastName = "Santos",
                            Password = "916c1678d3d28eb3e7798b9cf7acfbb6",
                            RegisterDate = new DateTime(2020, 6, 7, 1, 48, 33, 808, DateTimeKind.Utc).AddTicks(3751),
                            Username = "milton"
                        },
                        new
                        {
                            Id = new Guid("975b86c2-c1a3-4254-9ba9-5dcf923fbc03"),
                            Active = (short)1,
                            Deleted = false,
                            FirstName = "Milton",
                            LastName = "Honji",
                            Password = "916c1678d3d28eb3e7798b9cf7acfbb6",
                            RegisterDate = new DateTime(2020, 6, 7, 1, 48, 33, 829, DateTimeKind.Utc).AddTicks(1748),
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
