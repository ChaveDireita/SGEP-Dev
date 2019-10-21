using System;
using System.Collections.Generic;
using System.Text;

using SGEP_Services.DI;
using SGEP_Banco.Contexts;
using SGEP_Banco.RepositoryImplementations;

namespace SGEP_App
{
    public sealed class DependencyInitializers
    {
        public static IDependencyInitializer GetDBInitializer() => new DefaultContextInitializer();
        public static IDependencyInitializer GetRepositoriesInitializer() => new DefaultRepositoriesInitializer();
    }
}
