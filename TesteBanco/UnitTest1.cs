using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using SGEP_Banco.Contexts;
using SGEP_Banco.Models;
using System;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        private ServiceProvider _provider;
        [SetUp]
        public void Setup()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<DefaultContext>(o => o.UseMySql("Server=localhost;Database=SGEP;User=root;Password=cimatec;",
                                              mysqlo => mysqlo.ServerVersion(new Version(8, 0, 16), ServerType.MySql)));
            _provider = services.BuildServiceProvider();
        }

        [Test]
        public void Test1()
        {
            DefaultContext context = _provider.GetService<DefaultContext> ();
            

            Assert.Pass();
        }
    }
}