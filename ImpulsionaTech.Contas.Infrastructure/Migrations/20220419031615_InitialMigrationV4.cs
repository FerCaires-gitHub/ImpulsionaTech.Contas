using Microsoft.EntityFrameworkCore.Migrations;

namespace ImpulsionaTech.Contas.Infrastructure.Migrations
{
    public partial class InitialMigrationV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_CONTAS_ClienteId",
                table: "TB_CONTAS");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTAS_ClienteId_TipoContaId",
                table: "TB_CONTAS",
                columns: new[] { "ClienteId", "TipoContaId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_CONTAS_ClienteId_TipoContaId",
                table: "TB_CONTAS");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTAS_ClienteId",
                table: "TB_CONTAS",
                column: "ClienteId");
        }
    }
}
