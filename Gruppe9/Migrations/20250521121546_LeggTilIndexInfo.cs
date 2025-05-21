using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gruppe9.Migrations
{
    /// <inheritdoc />
    public partial class LeggTilIndexInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dato",
                table: "DateInfo");

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "DateInfo",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "DateInfo",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "DateInfo",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IndexInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    IndexDescription = table.Column<string>(type: "TEXT", nullable: false),
                    ColorInfoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IndexInfo_ColorInfo_ColorInfoId",
                        column: x => x.ColorInfoId,
                        principalTable: "ColorInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndexInfo_ColorInfoId",
                table: "IndexInfo",
                column: "ColorInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndexInfo");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "DateInfo");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "DateInfo");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "DateInfo");

            migrationBuilder.AddColumn<DateTime>(
                name: "Dato",
                table: "DateInfo",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
