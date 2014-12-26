using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleFormGenerator.DataLayer.Context;
using SimpleFormGenerator.ServiceLayer;
using StructureMap;
using StructureMap.Web;
using StructureMap.Web.Pipeline;

namespace SimpleFormGenerator.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitStructureMap();
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            HttpContextLifecycle.DisposeAndClearAll();
        }

        private void InitStructureMap()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IUnitOfWork>().HybridHttpOrThreadLocalScoped().Use(() => new SimpleFormGeneratorContext());
                x.For<IFormService>().Use<FormService>();
                x.For<IFieldService>().Use<FieldService>();
                x.For<IValueService>().Use<ValueService>();
            });
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }
    }
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null && requestContext.HttpContext.Request.Url != null)
                throw new InvalidOperationException(string.Format("Page not found: {0}",
                    requestContext.HttpContext.Request.Url.AbsoluteUri.ToString(CultureInfo.InvariantCulture)));
            return ObjectFactory.GetInstance(controllerType) as Controller;
        }
    }
}
