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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovimentacaoBancaria>()
                .HasIndex(p => p.ClienteId);

            modelBuilder.Entity<MovimentacaoBancaria>()
                .HasIndex(p => p.ContaId);

            modelBuilder.Entity<TipoConta>().
                HasOne(b => b.Conta).
                WithOne(a => a.TipoConta).
                HasForeignKey<Conta>(a => a.TipoContaId);

            modelBuilder.Entity<Conta>().
                HasOne(b => b.Cliente).
                WithMany(a  => a.Contas).
                HasForeignKey(a => a.ClienteId);

            modelBuilder.Entity<Conta>().
                HasIndex(a => new { a.ClienteId, a.TipoContaId })
                .IsUnique();

            modelBuilder.Entity<Cliente>().
                HasMany(a => a.Contas).
                WithOne();
            modelBuilder.Entity<Cliente>().
                HasIndex(a => a.CPF).
                IsUnique();
            modelBuilder.Entity<TipoConta>().
                HasData(new List<TipoConta> {
                 new TipoConta { TipoContaId = 1, Descricao = "Corrente", Status = Status.Ativo},
                 new TipoConta { TipoContaId = 2, Descricao = "Salário", Status = Status.Ativo},
                 new TipoConta { TipoContaId = 3, Descricao = "Poupança", Status = Status.Ativo},
                 new TipoConta { TipoContaId = 4, Descricao = "Investimento", Status = Status.Ativo}}
                );


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
            //context.TiposConta.AddRange(tiposConta);
            //context.SaveChanges();
        }
    }
}
