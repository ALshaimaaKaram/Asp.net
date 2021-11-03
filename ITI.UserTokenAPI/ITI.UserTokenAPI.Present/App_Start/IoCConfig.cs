using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ITI.UserTokenAPI.Data;
using ITI.UserTokenAPI.Present.Controllers;
using ITI.UserTokenAPI.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using IContainer = Autofac.IContainer;

namespace ITI.UserTokenAPI.Present.App_Start
{
    public class IoCConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Add your registrations

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // ...or you can register individual controllers manually.
            //Builder.RegisterType<UserController>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterGeneric(typeof(ModelRepository<>)).As(typeof(IModelRepository<>)).InstancePerRequest();
            builder.RegisterType<DBContextFactory>().As<IDBContextFactory>().InstancePerRequest();

            var container = builder.Build();

            // Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            // Set the dependency resolver for MVC.
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);

        }
    }
}