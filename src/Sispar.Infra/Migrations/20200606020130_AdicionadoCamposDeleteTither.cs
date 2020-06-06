using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sispar.Infra.Migrations
{
    public partial class AdicionadoCamposDeleteTither : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tithers",
                keyColumn: "Id",
                keyValue: new Guid("998867c5-b0f4-4aa9-a9aa-67919ca962e9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d374301a-cd94-4909-9979-bd339e362797"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fd7f2586-d4f1-43f4-8dc2-9cf515b6ba48"));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Tithers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Tithers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Tithers",
                columns: new[] { "Id", "Active", "Address", "AddressComplent", "AddressNumber", "BirthDate", "CPF", "Cellphone", "City", "DateBirthSpouse", "Deleted", "DeletedAt", "MarriegeDate", "MatiralStatus", "Name", "NameSpouse", "Neighborhood", "RegisterDate", "State", "Telephone", "ZipCode" },
                values: new object[] { new Guid("0baaddd4-39bf-4aff-8cdb-fe57ecc661db"), (short)1, "rua sem saida", null, null, new DateTime(2020, 6, 6, 2, 1, 30, 10, DateTimeKind.Utc).AddTicks(295), "999.999.999-99", "11 9.9999-9999", null, new DateTime(2020, 6, 6, 2, 1, 30, 10, DateTimeKind.Utc).AddTicks(7354), false, null, new DateTime(2020, 6, 6, 2, 1, 30, 10, DateTimeKind.Utc).AddTicks(4855), (short)0, "Jose", "Maria", null, new DateTime(2020, 6, 6, 2, 1, 30, 9, DateTimeKind.Utc).AddTicks(7974), null, "11 9.9999-9999", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("7067daa5-0ea9-4105-bc94-405e33987654"), (short)1, "Felipe", "Santos", "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 6, 6, 2, 1, 29, 971, DateTimeKind.Utc).AddTicks(179), "milton" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("97889751-8611-4cb2-a6d4-5fa9611b870d"), (short)1, "Milton", "Honji", "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 6, 6, 2, 1, 30, 5, DateTimeKind.Utc).AddTicks(5100), "felipe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tithers",
                keyColumn: "Id",
                keyValue: new Guid("0baaddd4-39bf-4aff-8cdb-fe57ecc661db"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7067daa5-0ea9-4105-bc94-405e33987654"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("97889751-8611-4cb2-a6d4-5fa9611b870d"));

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Tithers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Tithers");

            migrationBuilder.InsertData(
                table: "Tithers",
                columns: new[] { "Id", "Active", "Address", "AddressComplent", "AddressNumber", "BirthDate", "CPF", "Cellphone", "City", "DateBirthSpouse", "MarriegeDate", "MatiralStatus", "Name", "NameSpouse", "Neighborhood", "RegisterDate", "State", "Telephone", "ZipCode" },
                values: new object[] { new Guid("998867c5-b0f4-4aa9-a9aa-67919ca962e9"), (short)1, "rua sem saida", null, null, new DateTime(2020, 5, 31, 2, 17, 20, 809, DateTimeKind.Utc).AddTicks(2719), "999.999.999-99", "11 9.9999-9999", null, new DateTime(2020, 5, 31, 2, 17, 20, 810, DateTimeKind.Utc).AddTicks(2385), new DateTime(2020, 5, 31, 2, 17, 20, 809, DateTimeKind.Utc).AddTicks(8643), (short)0, "Jose", "Maria", null, new DateTime(2020, 5, 31, 2, 17, 20, 808, DateTimeKind.Utc).AddTicks(9172), null, "11 9.9999-9999", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("d374301a-cd94-4909-9979-bd339e362797"), (short)1, "Felipe", "Santos", "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 5, 31, 2, 17, 20, 775, DateTimeKind.Utc).AddTicks(6738), "milton" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("fd7f2586-d4f1-43f4-8dc2-9cf515b6ba48"), (short)1, "Milton", "Honji", "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 5, 31, 2, 17, 20, 802, DateTimeKind.Utc).AddTicks(7706), "felipe" });
        }
    }
}
