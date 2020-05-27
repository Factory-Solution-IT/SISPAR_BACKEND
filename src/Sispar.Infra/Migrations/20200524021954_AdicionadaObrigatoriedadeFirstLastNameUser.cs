using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sispar.Infra.Migrations
{
    public partial class AdicionadaObrigatoriedadeFirstLastNameUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

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
    }
}
