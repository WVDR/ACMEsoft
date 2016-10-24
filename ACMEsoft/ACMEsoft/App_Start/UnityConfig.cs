using ACMEsoft.DataAccessRepository;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using ACMEsoft.Model;
using ACMEsoft.DataAccessRepository;

namespace ACMEsoft
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IDataAccessRepository<Employee, long>, clsDataAccessRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}