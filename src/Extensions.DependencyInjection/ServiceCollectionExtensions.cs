using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Tolitech.CodeGenerator.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterAllTypes<T>(this IServiceCollection services, Assembly assembly, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            RegisterAllTypes<T>(services, new Assembly[] { assembly }, lifetime);
        }

        public static void RegisterAllTypes<T>(this IServiceCollection services, Assembly[] assemblies, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(T)))).ToList();

            foreach (var type in typesFromAssemblies)
            {
                if (!type.IsInterface)
                {
                    var @interface = type.ImplementedInterfaces.First(x => x.GetTypeInfo().ImplementedInterfaces.Any(y => y == (typeof(T))));
                    services.Add(new ServiceDescriptor(@interface, type, lifetime));
                }
            }
        }
    }
}