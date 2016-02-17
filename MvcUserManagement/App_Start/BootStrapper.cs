using System.Data.Entity;
using MvcDataManager;
using MvcUserManagement.data;
using MvcUserManagement.data.EmployeeRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

using LightInject;


namespace MvcUserManagement.App_Start
{
    public static class BootStrapper
    {
        public static void Run()
        {
            SetAutoFacContainer();
        }

        private static void SetAutoFacContainer()
        {
            var container = new ServiceContainer();
            container.RegisterControllers(Assembly.GetExecutingAssembly());
            container.Register<IUnitOfWork>((factory) => new UnitOfWork(new MvcUserManagementDbContext()));
            container.Register(typeof(IRepository<>), typeof(RepositoryBase<>));
            container.Register<IEmployeeRepository, EmployeeRepository>(new PerRequestLifeTime());
            container.EnableMvc();
        }
    }
}