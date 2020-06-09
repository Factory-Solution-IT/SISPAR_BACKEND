using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sispar.Infra.Migrations
{
    public partial class AdicionadoCamposDeleteTithe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Tithes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Tithes",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Tithers",
                columns: new[] { "Id", "Active", "Address", "AddressComplent", "AddressNumber", "BirthDate", "CPF", "Cellphone", "City", "DateBirthSpouse", "Deleted", "DeletedAt", "MarriegeDate", "MatiralStatus", "Name", "NameSpouse", "Neighborhood", "RegisterDate", "State", "Telephone", "ZipCode" },
                values: new object[] { new Guid("fadab4d9-f14a-4ec1-b62d-e49c304ff64e"), (short)1, "rua sem saida", null, null, new DateTime(2020, 6, 6, 2, 25, 33, 470, DateTimeKind.Utc).AddTicks(3401), "999.999.999-99", "11 9.9999-9999", null, new DateTime(2020, 6, 6, 2, 25, 33, 470, DateTimeKind.Utc).AddTicks(8109), false, null, new DateTime(2020, 6, 6, 2, 25, 33, 470, DateTimeKind.Utc).AddTicks(6428), (short)0, "Jose", "Maria", null, new DateTime(2020, 6, 6, 2, 25, 33, 470, DateTimeKind.Utc).AddTicks(1601), null, "11 9.9999-9999", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Deleted", "DeletedAt", "FirstName", "LastName", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("62875d2b-2a9b-4347-a0bc-a2267a19222b"), (short)1, false, null, "Felipe", "Santos", "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 6, 6, 2, 25, 33, 457, DateTimeKind.Utc).AddTicks(6887), "milton" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Deleted", "DeletedAt", "FirstName", "LastName", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("1aa3f943-1088-4ca9-9351-97f1a5076436"), (short)1, false, null, "Milton", "Honji", "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 6, 6, 2, 25, 33, 468, DateTimeKind.Utc).AddTicks(1258), "felipe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tithers",
                keyColumn: "Id",
                keyValue: new Guid("fadab4d9-f14a-4ec1-b62d-e49c304ff64e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1aa3f943-1088-4ca9-9351-97f1a5076436"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62875d2b-2a9b-4347-a0bc-a2267a19222b"));

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Tithes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Tithes");

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
    }
}
