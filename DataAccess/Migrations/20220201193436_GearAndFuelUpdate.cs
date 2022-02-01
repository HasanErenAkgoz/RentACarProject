using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class GearAndFuelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "CarInfos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearType",
                table: "CarInfos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "CarRentDetailDTO");

            migrationBuilder.DropColumn(
                name: "plate",
                table: "CarRentDetailDTO");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "CarInfos");

            migrationBuilder.DropColumn(
                name: "GearType",
                table: "CarInfos");

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpensesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpensesId);
                });
        }
    }
}
