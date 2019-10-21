using Microsoft.Extensions.DependencyInjection;
using SGEP_Services.DI;
using SGEP_Services.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGEP_Banco.RepositoryImplementations
{
    public sealed class DefaultRepositoriesInitializer : IDependencyInitializer
    {
        public void Init(IServiceCollection services)
        {
            services.AddScoped<IFuncionarioRepository, DefaultFuncionarioRepository>();
            services.AddScoped<IMaterialRepository, DefaultMaterialRepository>();
            services.AddScoped<IProjetoRepository, DefaultProjetoRepository>();
            services.AddScoped<IEntradaRepository, DefaultEntradaRepository>();
            services.AddScoped<ISaidaRepository, DefaultSaidaRepository>();
        }
    }
}
