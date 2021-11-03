using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ITI.UserTokenAPI.Data;
using ITI.UserTokenAPI.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using IContainer = Autofac.IContainer;

namespace ITI.UserTokenAPI.Present.App_Start
{
    public class IoCConfig
    {
        public static void Configure()
        {
            var Builder = new ContainerBuilder();

            Builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            Builder.RegisterControllers(Assembly.GetExecutingAssembly());
            Builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            Builder.RegisterGeneric(typeof(ModelRepository<>)).As(typeof(IModelRepository<>)).InstancePerRequest();
            Builder.RegisterType<DBContextFactory>().As<IDBContextFactory>().InstancePerRequest();

            IContainer Container = Builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }
    }
}