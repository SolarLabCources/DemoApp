using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;

namespace MvcAdmin.Infrastructure
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {

        private readonly IKernel kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            this.kernel = kernel;

        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, "Unable to locate controller");
            }
            return (IController)kernel.Resolve(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            kernel.ReleaseComponent(controller);
        }
    }
}