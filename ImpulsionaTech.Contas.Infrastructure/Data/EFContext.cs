using ImpulsionaTech.Contas.Domain.Models.Clientes;
using ImpulsionaTech.Contas.Domain.Models.Contas;
using ImpulsionaTech.Contas.Domain.Models.MovimentacoesBancarias;
using ImpulsionaTech.Contas.Domain.Models.TiposConta;
using ImpulsionaTech.Contas.Domain.Shared.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Contas.Infrastructure.Data
{
    public class EFContext : DbContext
    {
        public DbSet<Conta> Contas { get; set; }
        public DbSet<TipoConta> TiposConta { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<MovimentacaoBancaria> MovimentacoesBancarias { get; set; }
        public EFContext(DbContextOptions<EFContext> optionsBuilder) : base(optionsBuilder)
        {

        }

        public static void Initialize(EFContext context)
        {
            var tiposConta = new List<TipoConta>
            {
             new TipoConta { TipoContaId = 1, Descricao = "Corrente", Status = Status.Ativo},
             new TipoConta { TipoContaId = 2, Descricao = "Salário", Status = Status.Ativo},
             new TipoConta { TipoContaId = 3, Descricao = "Poupança", Status = Status.Ativo},
             new TipoConta { TipoContaId = 4, Descricao = "Investimento", Status = Status.Ativo}
            };
            context.TiposConta.AddRange(tiposConta);
            context.SaveChanges();
        }
    }
}
