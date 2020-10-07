using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationWebASPNET.Migrations
{
    public partial class NewAnnotations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CPT_DATECREATION",
                schema: "public",
                table: "T_E_COMPTE_CPT",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 29, 21, 39, 40, 726, DateTimeKind.Local).AddTicks(6466),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2020, 9, 25, 16, 7, 24, 901, DateTimeKind.Local).AddTicks(3258));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CPT_DATECREATION",
                schema: "public",
                table: "T_E_COMPTE_CPT",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 25, 16, 7, 24, 901, DateTimeKind.Local).AddTicks(3258),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 29, 21, 39, 40, 726, DateTimeKind.Local).AddTicks(6466));
        }
    }
}
