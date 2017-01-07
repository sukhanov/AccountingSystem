using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Ninject;

namespace AccountingSyatem.Shared.Automapper
{
    public class AutoMapperSerivce
    {
        private readonly IKernel _kernel;
        private List<Assembly> _assemblies = new List<Assembly>();
        public AutoMapperSerivce(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void RegisterMapperConfigs<T>()
        {
            _assemblies.Add(typeof(T).Assembly);
        }

        public void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                foreach (var assembly in _assemblies)
                {
                    var potencialConfig = assembly.GetTypes()
                        .Where(n => !n.IsAbstract && n.IsClass && typeof(IMapConfig).IsAssignableFrom(n));
                    foreach (var type in potencialConfig)
                    {
                        var config = (IMapConfig)_kernel.Get(type);
                        config.ConfigMapToDestination(cfg);
                        config.ConfigMapToSource(cfg);
                    }
                }
            });
        }
    }
}