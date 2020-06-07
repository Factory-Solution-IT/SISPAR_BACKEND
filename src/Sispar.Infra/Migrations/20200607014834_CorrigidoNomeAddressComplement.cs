using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sispar.Infra.Migrations
{
    public partial class CorrigidoNomeAddressComplement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "AddressComplent",
                table: "Tithers");

            migrationBuilder.AddColumn<string>(
                name: "AddressComplement",
                table: "Tithers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.InsertData(
                table: "Tithers",
                columns: new[] { "Id", "Active", "Address", "AddressComplement", "AddressNumber", "BirthDate", "CPF", "Cellphone", "City", "DateBirthSpouse", "Deleted", "DeletedAt", "MarriegeDate", "MatiralStatus", "Name", "NameSpouse", "Neighborhood", "RegisterDate", "State", "Telephone", "ZipCode" },
                values: new object[] { new Guid("08660d0c-30c4-4958-bd5e-19b19b96b533"), (short)1, "rua sem saida", null, null, new DateTime(2020, 6, 7, 1, 48, 33, 831, DateTimeKind.Utc).AddTicks(8764), "999.999.999-99", "11 9.9999-9999", null, new DateTime(2020, 6, 7, 1, 48, 33, 832, DateTimeKind.Utc).AddTicks(4516), false, null, new DateTime(2020, 6, 7, 1, 48, 33, 832, DateTimeKind.Utc).AddTicks(2287), (short)0, "Jose", "Maria", null, new DateTime(2020, 6, 7, 1, 48, 33, 831, DateTimeKind.Utc).AddTicks(6776), null, "11 9.9999-9999", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Deleted", "DeletedAt", "FirstName", "LastName", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("abf70193-dcb2-44f3-9579-66f4f0cc6b61"), (short)1, false, null, "Felipe", "Santos", "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 6, 7, 1, 48, 33, 808, DateTimeKind.Utc).AddTicks(3751), "milton" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Deleted", "DeletedAt", "FirstName", "LastName", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("975b86c2-c1a3-4254-9ba9-5dcf923fbc03"), (short)1, false, null, "Milton", "Honji", "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 6, 7, 1, 48, 33, 829, DateTimeKind.Utc).AddTicks(1748), "felipe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tithers",
                keyColumn: "Id",
                keyValue: new Guid("08660d0c-30c4-4958-bd5e-19b19b96b533"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("975b86c2-c1a3-4254-9ba9-5dcf923fbc03"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("abf70193-dcb2-44f3-9579-66f4f0cc6b61"));

            migrationBuilder.DropColumn(
                name: "AddressComplement",
                table: "Tithers");

            migrationBuilder.AddColumn<string>(
                name: "AddressComplent",
                table: "Tithers",
                type: "nvarchar(100)",
                maxLength: 100,
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
    }
}
