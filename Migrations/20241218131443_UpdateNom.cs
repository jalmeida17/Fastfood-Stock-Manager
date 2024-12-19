using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LEARNING_.NET_API_ANGULAR.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FastfoodStocksDbSet",
                table: "FastfoodStocksDbSet");

            migrationBuilder.RenameTable(
                name: "FastfoodStocksDbSet",
                newName: "FastfoodStocks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FastfoodStocks",
                table: "FastfoodStocks",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FastfoodStocks",
                table: "FastfoodStocks");

            migrationBuilder.RenameTable(
                name: "FastfoodStocks",
                newName: "FastfoodStocksDbSet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FastfoodStocksDbSet",
                table: "FastfoodStocksDbSet",
                column: "Id");
        }
    }
}
