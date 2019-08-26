using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SGEP.Models;

namespace SGEP.Banco
{
    public class ContextoBD : DbContext
    {

        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Projeto>()
                   .Property(p => p.Estado)
                   .HasConversion(e => e.ToString(), s => (EstadoProjeto)Enum.Parse(typeof(EstadoProjeto), s));
        }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
    }


}
