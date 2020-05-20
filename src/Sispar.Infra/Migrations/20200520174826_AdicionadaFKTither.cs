using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sispar.Infra.Migrations
{
    public partial class AdicionadaFKTither : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tithers",
                keyColumn: "Id",
                keyValue: new Guid("05219038-3ecb-4ea0-bd4d-5c752034a079"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("47a23a3e-ba5e-4427-a86e-c6a4eebe9871"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f75b3fc6-7024-459d-9ff5-d80efe304a30"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Tithes_TitherId",
                table: "Tithes",
                column: "TitherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tithes_Tithers_TitherId",
                table: "Tithes",
                column: "TitherId",
                principalTable: "Tithers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tithes_Tithers_TitherId",
                table: "Tithes");

            migrationBuilder.DropIndex(
                name: "IX_Tithes_TitherId",
                table: "Tithes");

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

            migrationBuilder.InsertData(
                table: "Tithers",
                columns: new[] { "Id", "Active", "Address", "BirthDate", "CPF", "Cellphone", "DateBirthSpouse", "MarriegeDate", "MatiralStatus", "Name", "NameSpouse", "RegisterDate", "Telephone" },
                values: new object[] { new Guid("05219038-3ecb-4ea0-bd4d-5c752034a079"), (short)1, "rua sem saida", new DateTime(2020, 5, 20, 17, 25, 27, 815, DateTimeKind.Utc).AddTicks(9948), "999.999.999-99", "11 9.9999-9999", new DateTime(2020, 5, 20, 17, 25, 27, 816, DateTimeKind.Utc).AddTicks(4447), new DateTime(2020, 5, 20, 17, 25, 27, 816, DateTimeKind.Utc).AddTicks(2995), (short)0, "Jose", "Maria", new DateTime(2020, 5, 20, 17, 25, 27, 815, DateTimeKind.Utc).AddTicks(8672), "11 9.9999-9999" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("47a23a3e-ba5e-4427-a86e-c6a4eebe9871"), (short)1, "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 5, 20, 17, 25, 27, 796, DateTimeKind.Utc).AddTicks(7421), "milton" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Password", "RegisterDate", "Username" },
                values: new object[] { new Guid("f75b3fc6-7024-459d-9ff5-d80efe304a30"), (short)1, "916c1678d3d28eb3e7798b9cf7acfbb6", new DateTime(2020, 5, 20, 17, 25, 27, 813, DateTimeKind.Utc).AddTicks(7068), "felipe" });
        }
    }
}
