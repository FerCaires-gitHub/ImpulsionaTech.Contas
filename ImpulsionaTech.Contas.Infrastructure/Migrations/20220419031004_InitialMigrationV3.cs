using Microsoft.EntityFrameworkCore.Migrations;

namespace ImpulsionaTech.Contas.Infrastructure.Migrations
{
    public partial class InitialMigrationV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CONTAS_TB_TIPO_CONTAS_TipoContaId",
                table: "TB_CONTAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_CONTAS_TipoContaId",
                table: "TB_CONTAS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
