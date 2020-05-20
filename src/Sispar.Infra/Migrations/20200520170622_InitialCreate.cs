using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sispar.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tithers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    MatiralStatus = table.Column<short>(type: "smallint", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    CPF = table.Column<string>(maxLength: 20, nullable: true),
                    Telephone = table.Column<string>(maxLength: 20, nullable: true),
                    Cellphone = table.Column<string>(maxLength: 20, nullable: true),
                    MarriegeDate = table.Column<DateTime>(type: "date", nullable: true),
                    NameSpouse = table.Column<string>(maxLength: 100, nullable: true),
                    DateBirthSpouse = table.Column<DateTime>(type: "date", nullable: true),
                    Active = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tithers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tithes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    ValueContribution = table.Column<decimal>(nullable: false),
                    DateContribution = table.Column<DateTime>(nullable: false),
                    TitherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tithes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Active = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tithers",
                columns: new[] { "Id", "Active", "Address", "BirthDate", "CPF", "Cellphone", "DateBirthSpouse", "MarriegeDate", "MatiralStatus", "Name", "NameSpouse", "RegisterDate", "Telephone" },
                values: new object[] { new Guid("f669a506-8d18-46cd-9738-42fe2eddc91b"), (short)1, "rua sem saida", new DateTime(2020, 5, 20, 17, 6, 21, 553, DateTimeKind.Utc).AddTicks(4620), "999.999.999-99", "11 9.9999-9999", new DateTime(2020, 5, 20, 17, 6, 21, 553, DateTimeKind.Utc).AddTicks(7702), new DateTime(2020, 5, 20, 17, 6, 21, 553, DateTimeKind.Utc).AddTicks(6694), (short)0, "Jose", "Maria", new DateTime(2020, 5, 20, 17, 6, 21, 553, DateTimeKind.Utc).AddTicks(3294), "11 9.9999-9999" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("e7b20d66-2ce7-421d-9c74-ebb9c3f3a07b"), (short)1, "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 5, 20, 17, 6, 21, 538, DateTimeKind.Utc).AddTicks(3143), "milton" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("cc6a1824-cae9-425c-a0c6-f617f210c74d"), (short)1, "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 5, 20, 17, 6, 21, 550, DateTimeKind.Utc).AddTicks(7281), "felipe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tithers");

            migrationBuilder.DropTable(
                name: "Tithes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
