using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sispar.Infra.Migrations
{
    public partial class AdicionadoFirstAndLastNameUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tithers",
                keyColumn: "Id",
                keyValue: new Guid("b6d8217a-ead2-4d9c-abb6-185dfc231915"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a20680e9-cea2-479e-ab2c-8604f314780f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("baac0a4d-2a00-48e3-a2e6-a2d0aa3e3ef0"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                maxLength: 50,
                nullable: true);

            migrationBuilder.InsertData(
                table: "Tithers",
                columns: new[] { "Id", "Active", "Address", "BirthDate", "CPF", "Cellphone", "DateBirthSpouse", "MarriegeDate", "MatiralStatus", "Name", "NameSpouse", "RegisterDate", "Telephone" },
                values: new object[] { new Guid("e544610b-0aaf-48a5-b60f-6bb8a563cf25"), (short)1, "rua sem saida", new DateTime(2020, 5, 24, 2, 12, 36, 397, DateTimeKind.Utc).AddTicks(5012), "999.999.999-99", "11 9.9999-9999", new DateTime(2020, 5, 24, 2, 12, 36, 398, DateTimeKind.Utc).AddTicks(337), new DateTime(2020, 5, 24, 2, 12, 36, 397, DateTimeKind.Utc).AddTicks(8563), (short)0, "Jose", "Maria", new DateTime(2020, 5, 24, 2, 12, 36, 397, DateTimeKind.Utc).AddTicks(3383), "11 9.9999-9999" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("82b0312f-726c-40a5-bb0e-712c6941b5dc"), (short)1, null, null, "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 5, 24, 2, 12, 36, 384, DateTimeKind.Utc).AddTicks(2435), "milton" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("e1ddecb4-d36e-495b-a6ad-d2d6e124e3ae"), (short)1, null, null, "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 5, 24, 2, 12, 36, 395, DateTimeKind.Utc).AddTicks(1799), "felipe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tithers",
                keyColumn: "Id",
                keyValue: new Guid("e544610b-0aaf-48a5-b60f-6bb8a563cf25"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("82b0312f-726c-40a5-bb0e-712c6941b5dc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e1ddecb4-d36e-495b-a6ad-d2d6e124e3ae"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Tithers",
                columns: new[] { "Id", "Active", "Address", "BirthDate", "CPF", "Cellphone", "DateBirthSpouse", "MarriegeDate", "MatiralStatus", "Name", "NameSpouse", "RegisterDate", "Telephone" },
                values: new object[] { new Guid("b6d8217a-ead2-4d9c-abb6-185dfc231915"), (short)1, "rua sem saida", new DateTime(2020, 5, 20, 17, 48, 25, 86, DateTimeKind.Utc).AddTicks(9905), "999.999.999-99", "11 9.9999-9999", new DateTime(2020, 5, 20, 17, 48, 25, 87, DateTimeKind.Utc).AddTicks(4558), new DateTime(2020, 5, 20, 17, 48, 25, 87, DateTimeKind.Utc).AddTicks(2711), (short)0, "Jose", "Maria", new DateTime(2020, 5, 20, 17, 48, 25, 86, DateTimeKind.Utc).AddTicks(7618), "11 9.9999-9999" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("a20680e9-cea2-479e-ab2c-8604f314780f"), (short)1, "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 5, 20, 17, 48, 25, 60, DateTimeKind.Utc).AddTicks(5078), "milton" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("baac0a4d-2a00-48e3-a2e6-a2d0aa3e3ef0"), (short)1, "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 5, 20, 17, 48, 25, 77, DateTimeKind.Utc).AddTicks(516), "felipe" });
        }
    }
}
