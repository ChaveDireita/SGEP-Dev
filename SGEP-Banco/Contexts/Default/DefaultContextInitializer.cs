using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

using SGEP_Services.DI;

namespace SGEP_Banco.Contexts
{
    public sealed class DefaultContextInitializer : IDependencyInitializer
    {
        const string CONNECTION_STRING = "Server=localhost;Database=SGEP;User=root;Password=cimatec;";

        public void Init(IServiceCollection services)
        {
            services.AddDbContext<DefaultContext>(o => o.UseMySql(CONNECTION_STRING,
                                              mysqlo => mysqlo.ServerVersion(new Version(8, 0, 16), ServerType.MySql)));
        }
    }
}
