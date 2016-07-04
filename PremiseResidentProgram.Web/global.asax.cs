using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace PremiseResidentProgram.Web
{    
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication 
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<CrudContext>(null);
            Database.SetInitializer<SchedulingContext>(null);

            IContainer container = StructureMap.ObjectFactory.Container;
            GlobalHost.DependencyResolver.Register(typeof(IHubActivator), () => new HubActivator(container));
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            StructureMap.ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
        }
    }
}