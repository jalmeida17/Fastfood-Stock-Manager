 using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LEARNING_.NET_API_ANGULAR.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FastfoodStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastRestock = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Bread = table.Column<int>(type: "int", nullable: false),
                    Cheese = table.Column<int>(type: "int", nullable: false),
                    Meat = table.Column<int>(type: "int", nullable: false),
                    Lettuce = table.Column<int>(type: "int", nullable: false),
                    Tomato = table.Column<int>(type: "int", nullable: false),
                    Onion = table.Column<int>(type: "int", nullable: false),
                    Pickle = table.Column<int>(type: "int", nullable: false),
                    Ketchup = table.Column<int>(type: "int", nullable: false),
                    Mustard = table.Column<int>(type: "int", nullable: false),
                    Mayonnaise = table.Column<int>(type: "int", nullable: false),
                    Potato = table.Column<int>(type: "int", nullable: false),
                    Water = table.Column<int>(type: "int", nullable: false),
                    Coke = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FastfoodStocks", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FastfoodStocks");
        }
    }
}
