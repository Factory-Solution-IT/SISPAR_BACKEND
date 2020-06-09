using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sispar.Infra.Migrations
{
    public partial class AdicionadoCamposDeleteUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Users",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Tithers",
                columns: new[] { "Id", "Active", "Address", "AddressComplent", "AddressNumber", "BirthDate", "CPF", "Cellphone", "City", "DateBirthSpouse", "Deleted", "DeletedAt", "MarriegeDate", "MatiralStatus", "Name", "NameSpouse", "Neighborhood", "RegisterDate", "State", "Telephone", "ZipCode" },
                values: new object[] { new Guid("34d541b3-baed-4ada-8e5c-0d84809967c9"), (short)1, "rua sem saida", null, null, new DateTime(2020, 6, 6, 2, 14, 3, 74, DateTimeKind.Utc).AddTicks(4286), "999.999.999-99", "11 9.9999-9999", null, new DateTime(2020, 6, 6, 2, 14, 3, 74, DateTimeKind.Utc).AddTicks(8981), false, null, new DateTime(2020, 6, 6, 2, 14, 3, 74, DateTimeKind.Utc).AddTicks(7185), (short)0, "Jose", "Maria", null, new DateTime(2020, 6, 6, 2, 14, 3, 74, DateTimeKind.Utc).AddTicks(2670), null, "11 9.9999-9999", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Deleted", "DeletedAt", "FirstName", "LastName", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("0d1e3f7b-65a5-4694-b7df-1ec047b03331"), (short)1, false, null, "Felipe", "Santos", "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 6, 6, 2, 14, 3, 61, DateTimeKind.Utc).AddTicks(3453), "milton" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Deleted", "DeletedAt", "FirstName", "LastName", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("3cd357ee-b437-4436-9e7c-46d847a9df8c"), (short)1, false, null, "Milton", "Honji", "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 6, 6, 2, 14, 3, 72, DateTimeKind.Utc).AddTicks(949), "felipe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tithers",
                keyColumn: "Id",
                keyValue: new Guid("34d541b3-baed-4ada-8e5c-0d84809967c9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0d1e3f7b-65a5-4694-b7df-1ec047b03331"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3cd357ee-b437-4436-9e7c-46d847a9df8c"));

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Users");

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
    }
}
