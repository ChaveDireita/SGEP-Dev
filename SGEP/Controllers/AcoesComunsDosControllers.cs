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
    public sealed class AcoesComunsDosControllers<T> where T : class, IAutoValida
    {
        public readonly DbSet<T> Tabela;
        public AcoesComunsDosControllers(DbSet<T> tabela) => Tabela = tabela;

        /*public async void SalvarModelo(DbSet<T> tabela, T modelo)
        {
            tabela.Add(modelo);

        }*/

        public static string ListaDeProptiedades(Type tipo)
        {
            PropertyInfo[] info = tipo.GetProperties();
            string nomesPropriedades = "";

            foreach (PropertyInfo p in info)
            {
                if ("".Equals(nomesPropriedades))
                    nomesPropriedades += p.Name;
                else
                    nomesPropriedades += (", " + p.Name);
            }

            return nomesPropriedades;
        }



    }

    public sealed class NomesPropriedades
    {
        public static readonly string NomesFuncionario;
        public static string NomesMaterial { get; set; }
        

        static NomesPropriedades()
        {
            NomesFuncionario = ListaDeProptiedades(typeof(Funcionario));
        }


        private NomesPropriedades() { }

        private static string ListaDeProptiedades(Type tipo)
        {
            PropertyInfo[] info = tipo.GetProperties();
            string nomesPropriedades = "";

            foreach (PropertyInfo p in info)
            {
                if ("".Equals(nomesPropriedades))
                    nomesPropriedades += p.Name;
                else
                    nomesPropriedades += (", " + p.Name);
            }

            return nomesPropriedades;
        }
    }
}
