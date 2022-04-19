using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ImpulsionaTech.Contas.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CLIENTES",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<int>(nullable: false),
                    CPF = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENTES", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "TB_MOVIMENTACAO_BANCARIA",
                columns: table => new
                {
                    MovimentacaoBancariaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<int>(nullable: false),
                    TipoContaId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    TipoMovimentacao = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MOVIMENTACAO_BANCARIA", x => x.MovimentacaoBancariaId);
                });

            migrationBuilder.CreateTable(
                name: "TB_CONTAS",
                columns: table => new
                {
                    ContaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<int>(nullable: false),
                    Saldo = table.Column<decimal>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CONTAS", x => x.ContaId);
                    table.ForeignKey(
                        name: "FK_TB_CONTAS_TB_CLIENTES_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TB_CLIENTES",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_TIPO_CONTAS",
                columns: table => new
                {
                    TipoContaId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TIPO_CONTAS", x => x.TipoContaId);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLIENTES_CPF",
                table: "TB_CLIENTES",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTAS_ClienteId",
                table: "TB_CONTAS",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_MOVIMENTACAO_BANCARIA");

            migrationBuilder.DropTable(
                name: "TB_TIPO_CONTAS");

            migrationBuilder.DropTable(
                name: "TB_CONTAS");

            migrationBuilder.DropTable(
                name: "TB_CLIENTES");
        }
    }
}
