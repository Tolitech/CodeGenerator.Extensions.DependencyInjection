using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Tolitech.CodeGenerator.Extensions.DependencyInjection.Tests.Repositories;
using Tolitech.CodeGenerator.Extensions.DependencyInjection.Tests.Services;
using Xunit;

namespace Tolitech.CodeGenerator.Extensions.DependencyInjection.Tests
{
    public class ServiceCollectionTest
    {
        [Fact(DisplayName = "ServiceCollection - RegisterAllTypesIRepository - Invalid")]
        public void ServiceCollection_RegisterAllTypesIRepository_Invalid()
        {
            var serviceCollection = new ServiceCollection();

            var services = serviceCollection.BuildServiceProvider();
            var repository = services.GetService<IPersonRepository>();

            Assert.Null(repository);
        }

        [Fact(DisplayName = "ServiceCollection - RegisterAllTypesIRepository - Valid")]
        public void ServiceCollection_RegisterAllTypesIRepository_Valid()
        {
            var serviceCollection = new ServiceCollection();
            var assembly = Assembly.GetExecutingAssembly();
            serviceCollection.RegisterAllTypes<IRepository>(assembly);

            var services = serviceCollection.BuildServiceProvider();
            var repository = services.GetService<IPersonRepository>();

            Assert.NotNull(repository);
        }

        [Fact(DisplayName = "ServiceCollection - RegisterAllTypesIService - Invalid")]
        public void ServiceCollection_RegisterAllTypesIService_Invalid()
        {
            var serviceCollection = new ServiceCollection();

            var services = serviceCollection.BuildServiceProvider();
            var service = services.GetService<IPersonService>();

            Assert.Null(service);
        }

        [Fact(DisplayName = "ServiceCollection - RegisterAllTypesIService - Valid")]
        public void ServiceCollection_RegisterAllTypesIService_Valid()
        {
            var serviceCollection = new ServiceCollection();
            var assembly = Assembly.GetExecutingAssembly();
            serviceCollection.RegisterAllTypes<IService>(assembly);

            var services = serviceCollection.BuildServiceProvider();
            var service = services.GetService<IPersonService>();

            Assert.NotNull(service);
        }
    }
}
