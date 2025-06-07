using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelApp_Mvc.Migrations
{
    public partial class dis1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    DiscountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisPercent = table.Column<int>(type: "int", nullable: false),
                    DiscountEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.DiscountID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discount");
        }
    }
}
