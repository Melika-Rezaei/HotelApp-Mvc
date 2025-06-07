using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelApp_Mvc.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserve_Rooms_RoomsID",
                table: "Reserve");

            migrationBuilder.DropIndex(
                name: "IX_Reserve_RoomsID",
                table: "Reserve");

            migrationBuilder.DropColumn(
                name: "reserveDate",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomsID",
                table: "Reserve");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StarComment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentsId);
                });

            migrationBuilder.CreateTable(
                name: "RoomDetail",
                columns: table => new
                {
                    RoomDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReserveID = table.Column<int>(type: "int", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    RoomsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomDetail", x => x.RoomDetailID);
                    table.ForeignKey(
                        name: "FK_RoomDetail_Reserve_ReserveID",
                        column: x => x.ReserveID,
                        principalTable: "Reserve",
                        principalColumn: "ReserveID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomDetail_Rooms_RoomsID",
                        column: x => x.RoomsID,
                        principalTable: "Rooms",
                        principalColumn: "RoomsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomDetail_ReserveID",
                table: "RoomDetail",
                column: "ReserveID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomDetail_RoomsID",
                table: "RoomDetail",
                column: "RoomsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "RoomDetail");

            migrationBuilder.AddColumn<DateTime>(
                name: "reserveDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RoomsID",
                table: "Reserve",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_RoomsID",
                table: "Reserve",
                column: "RoomsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserve_Rooms_RoomsID",
                table: "Reserve",
                column: "RoomsID",
                principalTable: "Rooms",
                principalColumn: "RoomsID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
