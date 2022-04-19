using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ImpulsionaTech.Contas.Infrastructure.Migrations
{
    public partial class InitialMigrationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_TB_TIPO_CONTAS_TB_CONTAS_TipoContaId",
            //    table: "TB_TIPO_CONTAS");

            migrationBuilder.AlterColumn<int>(
                name: "TipoContaId",
                table: "TB_TIPO_CONTAS",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "TipoContaId",
                table: "TB_CONTAS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTAS_TipoContaId",
                table: "TB_CONTAS",
                column: "TipoContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CONTAS_TB_TIPO_CONTAS_TipoContaId",
                table: "TB_CONTAS",
                column: "TipoContaId",
                principalTable: "TB_TIPO_CONTAS",
                principalColumn: "TipoContaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CONTAS_TB_TIPO_CONTAS_TipoContaId",
                table: "TB_CONTAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_CONTAS_TipoContaId",
                table: "TB_CONTAS");

            migrationBuilder.DropColumn(
                name: "TipoContaId",
                table: "TB_CONTAS");

            migrationBuilder.AlterColumn<int>(
                name: "TipoContaId",
                table: "TB_TIPO_CONTAS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TIPO_CONTAS_TB_CONTAS_TipoContaId",
                table: "TB_TIPO_CONTAS",
                column: "TipoContaId",
                principalTable: "TB_CONTAS",
                principalColumn: "ContaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
