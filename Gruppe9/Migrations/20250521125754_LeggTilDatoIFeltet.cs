using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gruppe9.Migrations
{
    /// <inheritdoc />
    public partial class LeggTilDatoIFeltet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "IndexInfo",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "IndexInfo");
        }
    }
}
