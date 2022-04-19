using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ImpulsionaTech.Contas.Infrastructure.Migrations
{
    public partial class InitialMigrationV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoContaId",
                table: "TB_TIPO_CONTAS",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId1",
                table: "TB_CONTAS",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTAS_ClienteId1",
                table: "TB_CONTAS",
                column: "ClienteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CONTAS_TB_CLIENTES_ClienteId1",
                table: "TB_CONTAS",
                column: "ClienteId1",
                principalTable: "TB_CLIENTES",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TIPO_CONTAS_TB_CONTAS_TipoContaId",
                table: "TB_TIPO_CONTAS",
                column: "TipoContaId",
                principalTable: "TB_CONTAS",
                principalColumn: "ContaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.InsertData(
    table: "TB_TIPO_CONTAS",
    columns: new[] { "TipoContaId", "Descricao", "Status" },
    values: new object[,]
    {
                    { 1, "Corrente", 0 },
                    { 2, "Salário", 0 },
                    { 3, "Poupança", 0 },
                    { 4, "Investimento", 0 }
    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CONTAS_TB_CLIENTES_ClienteId1",
                table: "TB_CONTAS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_TIPO_CONTAS_TB_CONTAS_TipoContaId",
                table: "TB_TIPO_CONTAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_CONTAS_ClienteId1",
                table: "TB_CONTAS");

            migrationBuilder.DropColumn(
                name: "ClienteId1",
                table: "TB_CONTAS");

            migrationBuilder.AlterColumn<int>(
                name: "TipoContaId",
                table: "TB_TIPO_CONTAS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
