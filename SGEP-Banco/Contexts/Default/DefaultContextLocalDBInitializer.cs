using Microsoft.Extensions.DependencyInjection;

using SGEP_Services.DI;

using Microsoft.EntityFrameworkCore;

namespace SGEP_Banco.Contexts
{
    class DefaultContextLocalDBInitializer : IDependencyInitializer
    {
        const string CONNECTION_STRING = "Server=(localdb)\\mssqllocaldb;Database=SGEP;Trusted_Connection=True;MultipleActiveResultSets=true";
        public void Init(IServiceCollection services)
        {
            services.AddDbContext<DefaultContext>(o => o.UseSqlServer(CONNECTION_STRING));
        }
    }
}
