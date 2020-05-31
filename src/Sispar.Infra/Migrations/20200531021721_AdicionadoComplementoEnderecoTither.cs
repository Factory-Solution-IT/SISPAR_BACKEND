using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sispar.Infra.Migrations
{
    public partial class AdicionadoComplementoEnderecoTither : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tithers",
                keyColumn: "Id",
                keyValue: new Guid("8daa6c8f-a459-4da0-8a9b-c6dd275253e6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4c609bd6-ef1c-431e-8893-32a2b183233a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cc0b433d-8d61-413c-a59c-1d9e75005679"));

            migrationBuilder.AddColumn<string>(
                name: "AddressComplent",
                table: "Tithers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressNumber",
                table: "Tithers",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Tithers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "Tithers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Tithers",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Tithers",
                maxLength: 9,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AddressComplent",
                table: "Tithers");

            migrationBuilder.DropColumn(
                name: "AddressNumber",
                table: "Tithers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Tithers");

            migrationBuilder.DropColumn(
                name: "Neighborhood",
                table: "Tithers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Tithers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Tithers");

            migrationBuilder.InsertData(
                table: "Tithers",
                columns: new[] { "Id", "Active", "Address", "BirthDate", "CPF", "Cellphone", "DateBirthSpouse", "MarriegeDate", "MatiralStatus", "Name", "NameSpouse", "RegisterDate", "Telephone" },
                values: new object[] { new Guid("8daa6c8f-a459-4da0-8a9b-c6dd275253e6"), (short)1, "rua sem saida", new DateTime(2020, 5, 24, 2, 19, 52, 311, DateTimeKind.Utc).AddTicks(3752), "999.999.999-99", "11 9.9999-9999", new DateTime(2020, 5, 24, 2, 19, 52, 312, DateTimeKind.Utc).AddTicks(3561), new DateTime(2020, 5, 24, 2, 19, 52, 311, DateTimeKind.Utc).AddTicks(9263), (short)0, "Jose", "Maria", new DateTime(2020, 5, 24, 2, 19, 52, 311, DateTimeKind.Utc).AddTicks(1211), "11 9.9999-9999" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("cc0b433d-8d61-413c-a59c-1d9e75005679"), (short)1, "Felipe", "Santos", "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 5, 24, 2, 19, 52, 284, DateTimeKind.Utc).AddTicks(3933), "milton" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("4c609bd6-ef1c-431e-8893-32a2b183233a"), (short)1, "Milton", "Honji", "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 5, 24, 2, 19, 52, 303, DateTimeKind.Utc).AddTicks(418), "felipe" });
        }
    }
}
