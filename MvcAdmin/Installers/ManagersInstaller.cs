using BusinessLogic.Abstraction;
using BusinessLogic.Implementation;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataAccessLayer;

namespace MvcAdmin.Installers
{

    public class ManagersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IPostManager>().ImplementedBy<PostManager>().LifestyleTransient());

            container.Register(Component.For<DemoContext>());

        }
    }
}