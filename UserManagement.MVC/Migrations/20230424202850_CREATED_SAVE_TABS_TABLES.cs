using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement.MVC.Migrations
{
    public partial class CREATED_SAVE_TABS_TABLES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DestinationDataAPIModel",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestMethodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationDataAPIModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DestinationLoginAPIModel",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestMethodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationLoginAPIModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaveProceeSettingDetailModel",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcessType = table.Column<int>(type: "int", nullable: false),
                    ProcessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SyncTimer = table.Column<int>(type: "int", nullable: false),
                    IDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveProceeSettingDetailModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SourceDataAPIModel",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestMethodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceDataAPIModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SourceLoginAPIModel",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestMethodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceLoginAPIModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinationDataAPIModel",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "DestinationLoginAPIModel",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "SaveProceeSettingDetailModel",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "SourceDataAPIModel",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "SourceLoginAPIModel",
                schema: "Identity");
        }
    }
}
