using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;

using SGEP_Banco.Models;

namespace SGEP_Banco.Contexts
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FuncionarioProjetoDBModel>()
                   .HasKey(fp => new { fp.FuncionarioId, fp.ProjetoId });
        }

        public DbSet<FuncionarioDBModel> Funcionario { get; set; }
        public DbSet<MaterialDBModel> Material { get; set; }
        public DbSet<ProjetoDBModel> Projeto { get; set; }
        public DbSet<ProjetoFinalizadoDBModel> ProjetoFinalizado { get; set; }
        public DbSet<FuncionarioProjetoDBModel> FuncionarioProjeto { get; set; }
        public DbSet<EntradaDBModel> Entrada { get; set; }
        public DbSet<SaidaDBModel> Saida { get; set; }

    }
}
