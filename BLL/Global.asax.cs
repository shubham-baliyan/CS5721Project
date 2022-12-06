using Autofac;
using Autofac.Integration.WebApi;
using BLL.ArenaFactory;
using BLL.BookingCommand;
using BLL.BookingObserver;
using BLL.Interfaces;
using BLL.MembershipFactory;
using BLL.RegistrationVerificationFacade;
using BLL.ServiceClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BLL
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            RegisterDependencies(builder, config);
            SetDependenciesToAutoFac(builder, config);

        }

        private void SetDependenciesToAutoFac(ContainerBuilder builder, HttpConfiguration config)
        {
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }

        private void RegisterDependencies(ContainerBuilder builder, HttpConfiguration config)
        {
            RegisterRepositiories(builder);
            RegisterControllers(builder, config);
        }
        private static void RegisterRepositiories(ContainerBuilder builder)
        {
            builder.RegisterType<Gym>().As<IArena>();
            builder.RegisterType<Pool>().As<IArena>();
            builder.RegisterType<Student>().As<IMembership>();
            builder.RegisterType<MembershipTypeFactory>().As<IMembershipTypeFactory>();
            builder.RegisterType<ArenaTypeFactory>().As<IArenaTypeFactory>();
            builder.RegisterType<UserContext>().As<IUserContext>();
            builder.RegisterType<Customer>().As<ICustomer>();
            builder.RegisterType<Staff>().As<IStaff>();
            builder.RegisterType<Admin>().As<IAdmin>();
            builder.RegisterType<BookSlot>().As<IBooking>();
            builder.RegisterType<BookSlot>().As<ISubject>();
            builder.RegisterType<Gym>().As<IObserver>();
            builder.RegisterType<Pool>().As<IObserver>();
            builder.RegisterType<UserLogin>().As<ILogin>();
            builder.RegisterType<Verification>().As<IVerification>();
            builder.RegisterType<CompositeCommand>().As<ICommand>();
            builder.RegisterType<CheckMembership>().As<ICommand>();
            builder.RegisterType<CheckSlotAvailaibility>().As<ICommand>();
            builder.RegisterType<AssignSlot>().As<ICommand>();


        }

        private static void RegisterControllers(ContainerBuilder builder, HttpConfiguration config)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();
        }

    }
}
