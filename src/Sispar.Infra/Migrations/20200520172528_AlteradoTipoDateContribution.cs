using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sispar.Infra.Migrations
{
    public partial class AlteradoTipoDateContribution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tithers",
                keyColumn: "Id",
                keyValue: new Guid("f669a506-8d18-46cd-9738-42fe2eddc91b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cc6a1824-cae9-425c-a0c6-f617f210c74d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e7b20d66-2ce7-421d-9c74-ebb9c3f3a07b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateContribution",
                table: "Tithes",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateContribution",
                table: "Tithes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

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
    }
}
