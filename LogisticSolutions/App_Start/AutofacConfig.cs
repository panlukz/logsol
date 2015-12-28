using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using LogisticSolutions.DAL;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Services;

namespace LogisticSolutions
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DataContext>().As<IDataContext>().InstancePerRequest();
            builder.RegisterType<DataFactory>().As<IDataFactory>().InstancePerRequest();
            builder.RegisterType<DeliveryService>().As<IDeliveryService>().InstancePerRequest();
            builder.RegisterType<CourierService>().As<ICourierService>().InstancePerRequest();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        } 
    }
}