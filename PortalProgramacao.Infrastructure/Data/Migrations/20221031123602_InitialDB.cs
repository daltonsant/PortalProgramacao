using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalProgramacao.Infrastructure.Data.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityTypes",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsFirstAccess = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_ApplicationRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ApplicationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_ApplicationRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ApplicationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Npls",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    SectorId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Npls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Npls_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicationID = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    MenHour = table.Column<decimal>(type: "TEXT", nullable: false),
                    HeadCount = table.Column<decimal>(type: "TEXT", nullable: false),
                    NplId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    ProcessId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    Place = table.Column<string>(type: "TEXT", nullable: false),
                    ProgramedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PlanedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TypeId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    OsNote = table.Column<string>(type: "TEXT", nullable: false),
                    Hours = table.Column<decimal>(type: "TEXT", nullable: false),
                    ComuteTime = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ActivityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Npls_NplId",
                        column: x => x.NplId,
                        principalTable: "Npls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    RegisterId = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    NplId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Npls_NplId",
                        column: x => x.NplId,
                        principalTable: "Npls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProcesses",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    ProcessId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    Percentage = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeProcesses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProcesses_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthDayCounts",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Month = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfDays = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthDayCounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthDayCounts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 1ul, new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4943), "Preventiva SE", null });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 2ul, new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4956), "Preventiva LT", null });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 3ul, new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4958), "Inspeção SE", null });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 4ul, new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4959), "Inspeção LT", null });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 5ul, new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4960), "Corretiva SE", null });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 6ul, new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4962), "Corretiva LT", null });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 7ul, new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4963), "Expansão SE", null });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 8ul, new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4964), "Expansão LT", null });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 9ul, new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4965), "Comissionamento SE", null });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 10ul, new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4967), "Comissionamento LT", null });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 11ul, new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4968), "Corretiva Aut", null });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 12ul, new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4969), "Preventiva Aut", null });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 13ul, new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4970), "DESC", null });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 14ul, new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4971), "Apoio a UTD/UTEPs", null });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 15ul, new DateTime(2022, 10, 31, 9, 36, 2, 482, DateTimeKind.Local).AddTicks(4972), "Transporte", null });

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "6fd990b7-688c-4ad7-ae36-0cb10e5395a4", "7afbe67b-e68a-4fc4-9179-77dc9cd0d200", "Usuário comum do sistema", "Programador", "PROGRAMADOR" });

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "89c9092c-83ba-4209-a472-a4e7f2f72cb8", "16157060-a975-420d-951d-c6f148dfcb98", "Administrador do sistema", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Processes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 1ul, new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(4362), "SE", null });

            migrationBuilder.InsertData(
                table: "Processes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 2ul, new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(4368), "LT", null });

            migrationBuilder.InsertData(
                table: "Processes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 3ul, new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(4369), "AUT", null });

            migrationBuilder.InsertData(
                table: "Processes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 4ul, new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(4370), "TLE", null });

            migrationBuilder.InsertData(
                table: "Sectors",
                columns: new[] { "Id", "Code", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 1ul, "NSIT", new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(5364), "Interior", null });

            migrationBuilder.InsertData(
                table: "Sectors",
                columns: new[] { "Id", "Code", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 2ul, "NSLT", new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(5369), "Litoral", null });

            migrationBuilder.InsertData(
                table: "Sectors",
                columns: new[] { "Id", "Code", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 3ul, "NSMT", new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(5370), "Metropolitano", null });

            migrationBuilder.InsertData(
                table: "Npls",
                columns: new[] { "Id", "Code", "CreatedDate", "Name", "SectorId", "UpdatedDate" },
                values: new object[] { 1ul, "CAA", new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(2236), "Caruaru", 2ul, null });

            migrationBuilder.InsertData(
                table: "Npls",
                columns: new[] { "Id", "Code", "CreatedDate", "Name", "SectorId", "UpdatedDate" },
                values: new object[] { 2ul, "GAN", new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(2243), "Garanhuns", 2ul, null });

            migrationBuilder.InsertData(
                table: "Npls",
                columns: new[] { "Id", "Code", "CreatedDate", "Name", "SectorId", "UpdatedDate" },
                values: new object[] { 3ul, "PMR", new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(2244), "Palmares", 2ul, null });

            migrationBuilder.InsertData(
                table: "Npls",
                columns: new[] { "Id", "Code", "CreatedDate", "Name", "SectorId", "UpdatedDate" },
                values: new object[] { 4ul, "PTU", new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(2246), "Petrolina", 1ul, null });

            migrationBuilder.InsertData(
                table: "Npls",
                columns: new[] { "Id", "Code", "CreatedDate", "Name", "SectorId", "UpdatedDate" },
                values: new object[] { 5ul, "SRT", new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(2247), "Serra Talhada", 1ul, null });

            migrationBuilder.InsertData(
                table: "Npls",
                columns: new[] { "Id", "Code", "CreatedDate", "Name", "SectorId", "UpdatedDate" },
                values: new object[] { 6ul, "MTS", new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(2250), "Metropolitano Sul", 3ul, null });

            migrationBuilder.InsertData(
                table: "Npls",
                columns: new[] { "Id", "Code", "CreatedDate", "Name", "SectorId", "UpdatedDate" },
                values: new object[] { 7ul, "MTN", new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(2251), "Metropolitano Norte", 3ul, null });

            migrationBuilder.InsertData(
                table: "Npls",
                columns: new[] { "Id", "Code", "CreatedDate", "Name", "SectorId", "UpdatedDate" },
                values: new object[] { 8ul, "CPN", new DateTime(2022, 10, 31, 9, 36, 2, 483, DateTimeKind.Local).AddTicks(2252), "Carpina", 3ul, null });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ApplicationID",
                table: "Activities",
                column: "ApplicationID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_NplId",
                table: "Activities",
                column: "NplId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ProcessId",
                table: "Activities",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TypeId",
                table: "Activities",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "ApplicationRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProcesses_EmployeeId",
                table: "EmployeeProcesses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProcesses_ProcessId",
                table: "EmployeeProcesses",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NplId",
                table: "Employees",
                column: "NplId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RegisterId",
                table: "Employees",
                column: "RegisterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonthDayCounts_EmployeeId",
                table: "MonthDayCounts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Npls_Code",
                table: "Npls",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Npls_SectorId",
                table: "Npls",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_Code",
                table: "Sectors",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EmployeeProcesses");

            migrationBuilder.DropTable(
                name: "MonthDayCounts");

            migrationBuilder.DropTable(
                name: "ActivityTypes");

            migrationBuilder.DropTable(
                name: "ApplicationRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Processes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Npls");

            migrationBuilder.DropTable(
                name: "Sectors");
        }
    }
}
