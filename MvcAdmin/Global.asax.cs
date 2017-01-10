using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BusinessLogic.Implementation;
using Castle.Windsor;
using Castle.Windsor.Installer;
using MvcAdmin.Infrastructure;

namespace MvcAdmin
{
    public class MvcApplication : System.Web.HttpApplication
    {

        private static IWindsorContainer container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootstrapContainer();
            AutoMapperConfig.Initialize();
        }


        private static void BootstrapContainer()
        {
            container = new WindsorContainer().Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        protected void Application_End()
        {
            container.Dispose();
        }
    }
}
