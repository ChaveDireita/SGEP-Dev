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
        ///automaticamente
        ///</summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Projeto>()
                   .Property(p => p.Estado)
                   .HasConversion(e => e.ToString(), s => (EstadoProjeto)Enum.Parse(typeof(EstadoProjeto), s));

            builder.Entity<AlocacaoPossui>()
                   .HasKey(ap => ap.CodMaterial);

            builder.Entity<AlocacaoPossui>()
                   .HasKey(ap => ap.CodProjeto);

            builder.Entity<ParticipaProjeto>()
                   .HasKey(ap => ap.IdFuncionario);

            builder.Entity<ParticipaProjeto>()
                   .HasKey(ap => ap.IdProjeto);
                   
        }
        ///<summary>
        ///Configura o mapeamento das propriedades nas classes do c# para o banco de dados
        ///para seus atributos correlatos nas tabelas do banco de dados. Nem todos os atributos
        ///precisam ser especificados, a saber, tipos primitivos geralmente são mapeados 
        ///automaticamente
        ///</summary>
        public DbSet<SGEP.Models.Funcionario> Funcionario { get; set; }
        ///<summary>
        ///Configura o mapeamento das propriedades nas classes do c# para o banco de dados
        ///para seus atributos correlatos nas tabelas do banco de dados. Nem todos os atributos
        ///precisam ser especificados, a saber, tipos primitivos geralmente são mapeados 
        ///automaticamente
        ///</summary>
        public DbSet<SGEP.Models.Material> Material { get; set; }
        ///<summary>
        ///Configura o mapeamento das propriedades nas classes do c# para o banco de dados
        ///para seus atributos correlatos nas tabelas do banco de dados. Nem todos os atributos
        ///precisam ser especificados, a saber, tipos primitivos geralmente são mapeados 
        ///automaticamente
        ///</summary>
        public DbSet<SGEP.Models.Projeto> Projeto { get; set; }

        
    }


}
