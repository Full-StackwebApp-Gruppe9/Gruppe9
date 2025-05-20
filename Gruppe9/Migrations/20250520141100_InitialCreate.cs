using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gruppe9.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColorInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Red = table.Column<int>(type: "INTEGER", nullable: false),
                    Green = table.Column<int>(type: "INTEGER", nullable: false),
                    Blue = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DateInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Dato = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PollenRegistrering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TypeOfPollen = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollenRegistrering", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlanteType = table.Column<string>(type: "TEXT", nullable: false),
                    ColorInfoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantInfo_ColorInfo_ColorInfoId",
                        column: x => x.ColorInfoId,
                        principalTable: "ColorInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PollenResponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateInfoId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlantInfoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollenResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollenResponse_DateInfo_DateInfoId",
                        column: x => x.DateInfoId,
                        principalTable: "DateInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PollenResponse_PlantInfo_PlantInfoId",
                        column: x => x.PlantInfoId,
                        principalTable: "PlantInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantInfo_ColorInfoId",
                table: "PlantInfo",
                column: "ColorInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_PollenResponse_DateInfoId",
                table: "PollenResponse",
                column: "DateInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_PollenResponse_PlantInfoId",
                table: "PollenResponse",
                column: "PlantInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PollenRegistrering");

            migrationBuilder.DropTable(
                name: "PollenResponse");

            migrationBuilder.DropTable(
                name: "DateInfo");

            migrationBuilder.DropTable(
                name: "PlantInfo");

            migrationBuilder.DropTable(
                name: "ColorInfo");
        }
    }
}
