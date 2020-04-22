using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hyman_Communication.Data.Migrations
{
    public partial class AddedNewsDetailsAndMarketTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NewsTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Market = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "NewsHistories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestingEmployeeID = table.Column<string>(nullable: true),
                    PostedByEmployeeID = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    NewsTypeID = table.Column<int>(nullable: true),
                    NewsTypeId = table.Column<int>(nullable: false),
                    Market = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NewsHistories_NewsTypes_NewsTypeID",
                        column: x => x.NewsTypeID,
                        principalTable: "NewsTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewsHistories_AspNetUsers_RequestingEmployeeID",
                        column: x => x.RequestingEmployeeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsHistories_NewsTypeID",
                table: "NewsHistories",
                column: "NewsTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_NewsHistories_RequestingEmployeeID",
                table: "NewsHistories",
                column: "RequestingEmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropTable(
                name: "NewsHistories");

            migrationBuilder.DropTable(
                name: "NewsTypes");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Lastname");
        }
    }
}
