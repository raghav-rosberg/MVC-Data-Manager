using Autofac;
using MvcDataManager;
using MvcUserManagement.data;
using MvcUserManagement.data.EmployeeRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace MvcUserManagement.App_Start
{
    public static class BootStrapper
    {
        public static void Run()
        {
            SetLightInjectContainer();
        }

        private static void SetLightInjectContainer()
        {
            var dbContext = new MvcUserManagementDbContext();
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.Register(c => new UnitOfWork(dbContext))
                .As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepository<>));
            
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().InstancePerLifetimeScope();

            //builder.Register(c => new MvcUserManagement.data.UserRepository.UserRepository(Startup.DataProtectionProvider, dbContext))
            //    .As<MvcUserManagement.data.UserRepository.IUserRepository>().InstancePerLifetimeScope();

            //builder.RegisterType<MvcUserManagement.data.UserRepository.UserRepository>().As<MvcUserManagement.data.UserRepository.IUserRepository>().InstancePerLifetimeScope();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));    
        }
    }
}