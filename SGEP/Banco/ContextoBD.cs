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
        }

        /// <summary>
        /// Representa a tabela <c>Funcionario</c> no banco. ele também pode ser convertido para uma
        /// <c>List</c> de <c>Funcionario</c>,
        /// <example> por exemplo:
        /// <code>Funcionarios.ToList();</code>
        /// ou
        /// <code>await Funcionarios.ToListAsync();</code>
        /// para uma conversão assíncrona.
        /// </example>
        /// <seealso cref="Funcionario"/>
        /// </summary>
        public DbSet<Funcionario> Funcionarios { get; set; }
        /// <summary>
        /// Representa a tabela <c>Material</c> no banco. Assim como a propriedade <c>Funcionarios</c>, pode
        /// ser convertida para uma <c>List</c> de tipo <c>Material</c>.
        /// <seealso cref="Funcionarios"/>
        /// <seealso cref="Material"/>
        /// </summary>
        public DbSet<Material> Materiais { get; set; }
        /// <summary>
        /// Representa a tabela <c>Projeto</c> no banco. Assim como a propriedade <c>Funcionarios</c>, pode
        /// ser convertida para uma <c>List</c> de tipo <c>Projeto</c>.
        /// <seealso cref="Funcionarios"/>
        /// <seealso cref="Projeto"/>
        /// </summary>
        public DbSet<Projeto> Projetos { get; set; }
    }


}
