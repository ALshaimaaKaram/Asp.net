using Autofac;
//using Autofac.Integration.Mvc;
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

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            // You can register controllers all at once using assembly scanning...
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .InstancePerRequest();
            builder.RegisterGeneric(typeof(ModelRepository<>))
                .As(typeof(IModelRepository<>)).InstancePerRequest(); ;
            builder.RegisterType<DBContextFactory>().As<IDBContextFactory>()
                 .InstancePerRequest();


            // ...or you can register individual controllers manually.
            //builder.RegisterType<userController>().InstancePerRequest();
            // builder.RegisterApiControllers(user, Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //var builder = new ContainerBuilder();
            //var config = new HttpConfiguration();
            //// Add your registrations
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterWebApiFilterProvider(config);
            //// ...or you can register individual controllers manually.
            ////Builder.RegisterType<UserController>().InstancePerRequest();
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            //builder.RegisterGeneric(typeof(ModelRepository<>)).As(typeof(IModelRepository<>)).InstancePerRequest();
            //builder.RegisterType<DBContextFactory>().As<IDBContextFactory>().InstancePerRequest();

            //IContainer container = builder.Build();
            //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //// Set the dependency resolver for Web API.
            ////var webApiResolver = new AutofacWebApiDependencyResolver(container);
            ////GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            //// Set the dependency resolver for MVC.
            ////var mvcResolver = new AutofacDependencyResolver(container);
            ////DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            ////var Builder = new ContainerBuilder();
            ////Builder.RegisterControllers(Assembly.GetExecutingAssembly());
            ////Builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            ////Builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            ////Builder.RegisterGeneric(typeof(ModelRepository<>)).As(typeof(IModelRepository<>)).InstancePerRequest();
            ////Builder.RegisterType<DBContextFactory>().As<IDBContextFactory>().InstancePerRequest();

            ////IContainer Container = Builder.Build();

            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}