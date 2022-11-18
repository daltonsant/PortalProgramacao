using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalProgramacao.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Activities_ApplicationID",
                table: "Activities");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "6fd990b7-688c-4ad7-ae36-0cb10e5395a4");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "89c9092c-83ba-4209-a472-a4e7f2f72cb8");

            migrationBuilder.DropColumn(
                name: "ApplicationID",
                table: "Activities");

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(2699));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(2711));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(2712));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 4ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(2713));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 5ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(2714));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 6ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(2717));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 7ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(2717));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 8ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(2718));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 9ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(2719));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 10ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(2721));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 11ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(2722));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 12ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(2723));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 13ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(2724));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 14ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 15ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(2725));

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "0c3959bd-151b-4447-bc7c-714dd798707d", "361b4de2-0488-44e8-9c6e-a09889975db1", "Administrador do sistema", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "d861b504-7f2c-4d37-bb12-2c1da3c206bb", "c95254f7-c372-4a24-a9f6-d683506e8e26", "Usuário comum do sistema", "Programador", "PROGRAMADOR" });

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(8497));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(8498));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 4ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(8500));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 5ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(8501));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 6ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 7ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(8505));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 8ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 621, DateTimeKind.Local).AddTicks(8506));

            migrationBuilder.UpdateData(
                table: "Processes",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 622, DateTimeKind.Local).AddTicks(139));

            migrationBuilder.UpdateData(
                table: "Processes",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 622, DateTimeKind.Local).AddTicks(144));

            migrationBuilder.UpdateData(
                table: "Processes",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 622, DateTimeKind.Local).AddTicks(145));

            migrationBuilder.UpdateData(
                table: "Processes",
                keyColumn: "Id",
                keyValue: 4ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 622, DateTimeKind.Local).AddTicks(146));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 622, DateTimeKind.Local).AddTicks(924));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 622, DateTimeKind.Local).AddTicks(929));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 11, 12, 26, 622, DateTimeKind.Local).AddTicks(930));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "0c3959bd-151b-4447-bc7c-714dd798707d");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "d861b504-7f2c-4d37-bb12-2c1da3c206bb");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationID",
                table: "Activities",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 4ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 5ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 6ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 7ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4963));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 8ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 9ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4965));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 10ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4967));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 11ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4968));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 12ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4969));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 13ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 14ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 15ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4972));

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "6fd990b7-688c-4ad7-ae36-0cb10e5395a4", "7afbe67b-e68a-4fc4-9179-77dc9cd0d200", "Usuário comum do sistema", "Programador", "PROGRAMADOR" });

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "89c9092c-83ba-4209-a472-a4e7f2f72cb8", "16157060-a975-420d-951d-c6f148dfcb98", "Administrador do sistema", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(2243));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 4ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(2246));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 5ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 6ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 7ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 8ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.UpdateData(
                table: "Processes",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(4362));

            migrationBuilder.UpdateData(
                table: "Processes",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "Processes",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "Processes",
                keyColumn: "Id",
                keyValue: 4ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(4370));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(5369));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(5370));

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ApplicationID",
                table: "Activities",
                column: "ApplicationID",
                unique: true);
        }
    }
}
