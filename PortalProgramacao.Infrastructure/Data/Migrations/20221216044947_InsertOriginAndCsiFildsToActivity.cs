using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalProgramacao.Infrastructure.Data.Migrations
{
    public partial class InsertOriginAndCsiFildsToActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Csi",
                table: "Activities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Activities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 4ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 5ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 6ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 7ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 8ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 9ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 10ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 11ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 12ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 13ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 14ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 15ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "0c3959bd-151b-4447-bc7c-714dd798707d",
                column: "ConcurrencyStamp",
                value: "0c3959bd-151b-4447-bc7c-714dd798707d");

            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "d861b504-7f2c-4d37-bb12-2c1da3c206bb",
                column: "ConcurrencyStamp",
                value: "d861b504-7f2c-4d37-bb12-2c1da3c206bb");

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 4ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 5ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 6ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 7ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Npls",
                keyColumn: "Id",
                keyValue: 8ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Processes",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Processes",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Processes",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Processes",
                keyColumn: "Id",
                keyValue: 4ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));
            
            migrationBuilder.Sql("INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES " +
                                 "('f993dd75-d7c8-4eca-8139-69fec042b949','0c3959bd-151b-4447-bc7c-714dd798707d')," +
                                 "('9d553d58-73a8-4f27-94ca-2c340a69d906','0c3959bd-151b-4447-bc7c-714dd798707d')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Csi",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Origin",
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

            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "0c3959bd-151b-4447-bc7c-714dd798707d",
                column: "ConcurrencyStamp",
                value: "361b4de2-0488-44e8-9c6e-a09889975db1");

            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "d861b504-7f2c-4d37-bb12-2c1da3c206bb",
                column: "ConcurrencyStamp",
                value: "c95254f7-c372-4a24-a9f6-d683506e8e26");

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
    }
}
