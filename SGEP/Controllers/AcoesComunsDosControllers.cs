using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGEP.Banco;
using SGEP.Models;
using SGEP.Models.Validacao;

namespace SGEP.Controllers
{
    /// <summary>
    /// A classe <c>AcoesComunsDosControllers</c> visa diminuir a repetição de código nas classes Controllers.
    /// Ela é uma classe feita apenas para abrigar métodos, por isso, ela é sealed e possui um construtor privado.
    /// </summary>
    public sealed class AcoesComunsDosControllers
    {
        private AcoesComunsDosControllers() { }
        /// <summary>
        /// Busca um modelo com a chave primária dada no banco de dados.
        /// </summary>
        /// <typeparam name="T">Classe do model</typeparam>
        /// <param name="id">É a chave primária a ser checado no banco</param>
        /// <param name="tabela">DbSet equivalente na classe ContextoBD <seealso cref="ContextoBD"/></param>
        /// <returns>O modelo com a chave primária dada ou null, caso o a entrada no banco não seja encontrada.</returns>
        public static async Task<T> ChecarPeloId<T>(ulong? id, DbSet<T> tabela) where T : class//Retornos do tipo Task<> são para métodos assíncronos.
        {
            if (id == null)
                return null;
            Task<T> modelo = tabela.FindAsync(id);
            return await modelo;
        }
        /// <summary>
        /// Salvar um model no banco de dados.
        /// </summary>
        /// <typeparam name="T">Classe do model</typeparam>
        /// <param name="modelo">Model com as informações a serem guardadas no banco de dados</param>
        /// <param name="contexto">Objeto da classe de contexto do banco de dados <seealso cref="ContextoBD"/></param>
        public static async Task SalvarModelo<T>(T modelo, ContextoBD contexto) where T : class//Task puro seria como "Task<void>". Para métodos assíncronos sem retorno.
        {
            contexto.Add(modelo);
            await contexto.SaveChangesAsync();
        }
        /// <summary>
        /// Atualiza os dados de um model no banco de dados.
        /// </summary>
        /// <typeparam name="T">Classe do model</typeparam>
        /// <param name="modelo">Model com a chave primária e as informações a serem modificadas</param>
        /// <param name="contexto">Objeto da classe de contexto do banco de dados <seealso cref="ContextoBD"/></param>
        public static async Task AtualizarModelo<T>(T modelo, ContextoBD contexto) where T : class
        {
            contexto.Update(modelo);
            await contexto.SaveChangesAsync();
        }



    }
}
