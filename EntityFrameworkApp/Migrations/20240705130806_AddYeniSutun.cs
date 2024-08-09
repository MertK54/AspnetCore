using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkApp.Migrations
{
    /// <inheritdoc />
    public partial class AddYeniSutun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YeniSutunId",
                table: "Kurslar",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "YeniSutunlar",
                columns: table => new
                {
                    YeniSutunId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: true),
                    Soyad = table.Column<string>(type: "TEXT", nullable: true),
                    Eposta = table.Column<string>(type: "TEXT", nullable: true),
                    Telefon = table.Column<string>(type: "TEXT", nullable: true),
                    BaslamaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeniSutunlar", x => x.YeniSutunId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kurslar_YeniSutunId",
                table: "Kurslar",
                column: "YeniSutunId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kurslar_YeniSutunlar_YeniSutunId",
                table: "Kurslar",
                column: "YeniSutunId",
                principalTable: "YeniSutunlar",
                principalColumn: "YeniSutunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kurslar_YeniSutunlar_YeniSutunId",
                table: "Kurslar");

            migrationBuilder.DropTable(
                name: "YeniSutunlar");

            migrationBuilder.DropIndex(
                name: "IX_Kurslar_YeniSutunId",
                table: "Kurslar");

            migrationBuilder.DropColumn(
                name: "YeniSutunId",
                table: "Kurslar");
        }
    }
}
