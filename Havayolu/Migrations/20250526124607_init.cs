using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Havayolu.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "biletler",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kullaniciId = table.Column<int>(type: "int", nullable: false),
                    adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ucusId = table.Column<int>(type: "int", nullable: false),
                    ucusTuru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nereden = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nereye = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gidisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    donusTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fiyat = table.Column<int>(type: "int", nullable: false),
                    yetiskin = table.Column<int>(type: "int", nullable: false),
                    cocuk = table.Column<int>(type: "int", nullable: false),
                    bebek = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_biletler", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kartlar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kartNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ayYil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cvv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    onay = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kartlar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    e_posta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sifre_tekrar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ucusTuru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nereden = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nereye = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gidisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    donusTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fiyat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "biletler");

            migrationBuilder.DropTable(
                name: "kartlar");

            migrationBuilder.DropTable(
                name: "kullanicilar");

            migrationBuilder.DropTable(
                name: "persons");
        }
    }
}
