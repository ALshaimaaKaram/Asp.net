using Autofac;
using Autofac.Integration.Mvc;
using ITI.UserToken.Data;
using ITI.UserToken.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.UserToken.Presentation.App_Start
{
    public static class IocConfig
    {
        public static void Configure()
        {
            var Builder = new ContainerBuilder();
            Builder.RegisterControllers(typeof(MvcApplication).Assembly);
            Builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            Builder.RegisterGeneric(typeof(ModelRepository<>)).As(typeof(IModelRepository<>)).InstancePerRequest();
            Builder.RegisterType<DBContextFactory>().As<IDBContextFactory>().InstancePerRequest();

            IContainer Container = Builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }
    }
}