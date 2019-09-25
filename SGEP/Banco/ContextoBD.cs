using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SGEP.Models;

namespace SGEP.Banco
{
    ///<summary>
    ///<c>ContextoDB</c> é a classe de conexão com o banco de dados. Ela possui DbSets de todas as 
    ///entidades do programa. Ela também define o mapeamento de suas classes no c# para as tabelas 
    ///do banco e vice-versa
    ///</summary>
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options) { }
        ///<summary>
        ///Configura o mapeamento das propriedades nas classes do c# para o banco de dados
        ///para seus atributos correlatos nas tabelas do banco de dados. Nem todos os atributos
        ///precisam ser especificados, a saber, tipos primitivos geralmente são mapeados 
        ///automaticamente.
        ///</summary
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Projeto>()
                   .Property(p => p.Estado)
                   .HasConversion(e => e.ToString(), s => (EstadoProjeto)Enum.Parse(typeof(EstadoProjeto), s));//Converte o EstadoProjeto pra string a ser colocada no banco e vice-versa

            builder.Entity<Transacao>()
                   .HasKey(ap => new { ap.CodMaterial, ap.CodProjeto });//Define a chave primária da tabela AlocacaoPossui como uma composta pela chave das tablas Material e Projeto

            builder.Entity<ParticipaProjeto>()
                   .HasKey(ap => new { ap.CodFuncionario, ap.CodProjeto });//Mesma lógica que a de cima, só que pra ParicipaProjeto
                   
        }
        /// <summary>
        /// As propriedades abaixo são objetos que representam as tabelas do banco.
        /// </summary>
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
	    public DbSet<Unidades> Unidades { get; set; }
        //public DbSet<AlocacaoPossui> AlocacaoPossuis { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<ParticipaProjeto> ParticipaProjeto { get; set; }

    }


}
