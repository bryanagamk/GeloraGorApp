using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeloraGorApp.Migrations
{
    public partial class initCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JenisLapangan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NamaJenis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisLapangan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pegawai",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NamaPegawai = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Alamat = table.Column<string>(nullable: true),
                    NoTelp = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pegawai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lapangan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JenisId = table.Column<int>(nullable: false),
                    NamaLapangan = table.Column<string>(nullable: true),
                    Catatan = table.Column<string>(nullable: true),
                    Harga = table.Column<double>(nullable: false),
                    Foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lapangan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lapangan_JenisLapangan_JenisId",
                        column: x => x.JenisId,
                        principalTable: "JenisLapangan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jadwal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LapanganId = table.Column<int>(nullable: false),
                    PegawaiId = table.Column<int>(nullable: false),
                    WaktuAwal = table.Column<DateTime>(nullable: false),
                    WaktuAkhir = table.Column<DateTime>(nullable: false),
                    Catatan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jadwal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jadwal_Lapangan_LapanganId",
                        column: x => x.LapanganId,
                        principalTable: "Lapangan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jadwal_Pegawai_PegawaiId",
                        column: x => x.PegawaiId,
                        principalTable: "Pegawai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jadwal_LapanganId",
                table: "Jadwal",
                column: "LapanganId");

            migrationBuilder.CreateIndex(
                name: "IX_Jadwal_PegawaiId",
                table: "Jadwal",
                column: "PegawaiId");

            migrationBuilder.CreateIndex(
                name: "IX_Lapangan_JenisId",
                table: "Lapangan",
                column: "JenisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jadwal");

            migrationBuilder.DropTable(
                name: "Lapangan");

            migrationBuilder.DropTable(
                name: "Pegawai");

            migrationBuilder.DropTable(
                name: "JenisLapangan");
        }
    }
}
