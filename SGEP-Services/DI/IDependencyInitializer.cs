using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

namespace SGEP_Services.DI
{
    public interface IDependencyInitializer
    {
        void Init(IServiceCollection services);
    }
}
