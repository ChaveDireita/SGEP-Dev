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
    public sealed class AcoesComunsDosControllers
    {
        private AcoesComunsDosControllers() { }

        public static async Task<T> ChecarPeloId<T>(ulong? id, DbSet<T> tabela) where T : class
        {
            if (id == null)
                return null;
            Task<T> modelo = tabela.FindAsync(id);
            return await modelo;
        }

        public static async Task SalvarModelo<T>(T modelo, ContextoBD contexto) where T : class
        {
            contexto.Add(modelo);
            await contexto.SaveChangesAsync();
        }
        public static async Task AtualizarModelo<T>(T modelo, ContextoBD contexto) where T : class
        {
            contexto.Add(modelo);
            await contexto.SaveChangesAsync();
        }



    }
}
