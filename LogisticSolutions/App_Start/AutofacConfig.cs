using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using LogisticSolutions.DAL;

namespace LogisticSolutions
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DataContext>().As<IDataContext>().InstancePerRequest();
            builder.RegisterType<DataFactory>().As<IDataFactory>().InstancePerRequest();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        } 
    }
}