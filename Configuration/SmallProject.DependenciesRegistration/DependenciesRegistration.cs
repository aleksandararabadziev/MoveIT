using SmallProject.Data.Implementations;
using SmallProject.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SmallProject.DependenciesRegistration
{
    public static class DependenciesRegistration
    {
        public static Dictionary<Type, Type> Services()
        {
            Dictionary<Type, Type> services = new Dictionary<Type, Type>();

            var assembly = Assembly.Load("SmallProject.Services");
            var serviceTypes = assembly.GetTypes()
                .Where(t => t.Name.EndsWith("Service"))
                .ToList();

            foreach (var serviceType in serviceTypes)
            {
                var interfaceTypes = serviceType.GetInterfaces()
                    .Where(t => t.Name.EndsWith("Service"))
                    .Where(interfaceType => interfaceType.IsAssignableFrom(serviceType));
                foreach (var interfaceType in interfaceTypes)
                {
                    services.Add(interfaceType, serviceType);
                    break;
                }
            }

            return services;
        }
        public static Dictionary<Type, Type> Data()
        {
            Dictionary<Type, Type> components = new Dictionary<Type, Type>();

            components.Add(typeof(IRepository<>), typeof(Repository<>));

            return components;
        }
    }
}
