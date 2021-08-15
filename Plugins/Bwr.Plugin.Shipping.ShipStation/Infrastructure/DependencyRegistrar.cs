using Autofac;
using Bwr.Core.Configuration;
using Bwr.Core.Infrastructure;
using Bwr.Core.Infrastructure.DependencyManagement;
using Bwr.Plugin.Shipping.ShipStation.Services;

namespace Bwr.Plugin.Shipping.ShipStation.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<ShipStationService>().As<IShipStationService>().InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order => 2;
    }
}
