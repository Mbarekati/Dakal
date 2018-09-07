using System;
using Dakal.AppService;
using Dakal.Repositories;
using Unity;
using Microsoft.Practices.Unity;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector;
using Unity.AspNet.Mvc;
using Unity.Lifetime;

namespace Dakal.Api
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IUserRepository, UserRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IFirmRepository, FirmRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IAdvertisementRepository, AdvertisementRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IUserService, UserService>(new PerRequestLifetimeManager());
            container.RegisterType<IAdvertisementService, AdvertisementService>(new PerRequestLifetimeManager());
            container.RegisterType<ILoggerService, LoggerService>(new PerRequestLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());
            container.RegisterType<ISeenAdsRepository, SeenAdsRepository>(new PerRequestLifetimeManager());
            container.RegisterType<ISeenAdsService, SeenAdsService>(new PerRequestLifetimeManager());
        }
    }
}