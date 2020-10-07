using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApplicationWebASPNET.Migrations
{
    public partial class CreationBDFilmRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "T_E_COMPTE_CPT",
                schema: "public",
                columns: table => new
                {
                    CPT_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CPT_NOM = table.Column<string>(maxLength: 50, nullable: false),
                    CPT_PRENOM = table.Column<string>(maxLength: 50, nullable: false),
                    CPT_TELPORTABLE = table.Column<string>(type: "char(10)", nullable: true),
                    CPT_MEL = table.Column<string>(maxLength: 100, nullable: false),
                    CPT_PWD = table.Column<string>(maxLength: 64, nullable: true),
                    CPT_RUE = table.Column<string>(maxLength: 200, nullable: false),
                    CPT_CP = table.Column<string>(type: "char(5)", nullable: false),
                    CPT_VILLE = table.Column<string>(maxLength: 50, nullable: false),
                    CPT_PAYS = table.Column<string>(maxLength: 50, nullable: false, defaultValue: "France"),
                    CPT_LATITUDE = table.Column<float>(nullable: true),
                    CPT_LONGITUDE = table.Column<float>(nullable: true),
                    CPT_DATECREATION = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 9, 25, 16, 7, 24, 901, DateTimeKind.Local).AddTicks(3258))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_E_COMPTE_CPT", x => x.CPT_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_E_FILM_FLM",
                schema: "public",
                columns: table => new
                {
                    FLM_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FLM_TITRE = table.Column<string>(maxLength: 100, nullable: false),
                    FLM_SYNOPSIS = table.Column<string>(maxLength: 500, nullable: true),
                    FLM_DATEPARUTION = table.Column<DateTime>(maxLength: 500, nullable: false),
                    FLM_DUREE = table.Column<decimal>(maxLength: 500, nullable: false),
                    FLM_GENRE = table.Column<string>(maxLength: 30, nullable: false),
                    FLM_URLPHOTO = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_E_FILM_FLM", x => x.FLM_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_J_FAVORI_FAV",
                schema: "public",
                columns: table => new
                {
                    CPT_ID = table.Column<int>(nullable: false),
                    FLM_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAV", x => new { x.FLM_ID, x.CPT_ID });
                    table.ForeignKey(
                        name: "FK_FAV_COM",
                        column: x => x.CPT_ID,
                        principalSchema: "public",
                        principalTable: "T_E_COMPTE_CPT",
                        principalColumn: "CPT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FAV_FLM",
                        column: x => x.FLM_ID,
                        principalSchema: "public",
                        principalTable: "T_E_FILM_FLM",
                        principalColumn: "FLM_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_E_COMPTE_CPT_CPT_MEL",
                schema: "public",
                table: "T_E_COMPTE_CPT",
                column: "CPT_MEL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_J_FAVORI_FAV_CPT_ID",
                schema: "public",
                table: "T_J_FAVORI_FAV",
                column: "CPT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_J_FAVORI_FAV",
                schema: "public");

            migrationBuilder.DropTable(
                name: "T_E_COMPTE_CPT",
                schema: "public");

            migrationBuilder.DropTable(
                name: "T_E_FILM_FLM",
                schema: "public");
        }
    }
}
