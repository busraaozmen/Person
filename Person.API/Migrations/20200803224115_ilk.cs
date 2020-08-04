using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Person.API.Migrations
{
    public partial class ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kisiler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(maxLength: 30, nullable: false),
                    Soyad = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonelBilgileri",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KisiId = table.Column<int>(nullable: false),
                    GirisTarihi = table.Column<DateTime>(nullable: false),
                    CikisTarihi = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelBilgileri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonelBilgileri_Kisiler_KisiId",
                        column: x => x.KisiId,
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kisiler",
                columns: new[] { "Id", "Ad", "Soyad" },
                values: new object[,]
                {
                    { 1, "AY", "YILDIZ" },
                    { 2, "GÜNEŞ", "MARS" },
                    { 3, "VENÜS", "URANÜS" }
                });

            migrationBuilder.InsertData(
                table: "PersonelBilgileri",
                columns: new[] { "Id", "CikisTarihi", "GirisTarihi", "KisiId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 4, 1, 41, 14, 868, DateTimeKind.Local).AddTicks(3072), 1 },
                    { 2, null, new DateTime(2020, 8, 4, 1, 41, 14, 870, DateTimeKind.Local).AddTicks(7413), 2 },
                    { 3, null, new DateTime(2020, 8, 4, 1, 41, 14, 870, DateTimeKind.Local).AddTicks(7510), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonelBilgileri_KisiId",
                table: "PersonelBilgileri",
                column: "KisiId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonelBilgileri");

            migrationBuilder.DropTable(
                name: "Kisiler");
        }
    }
}
