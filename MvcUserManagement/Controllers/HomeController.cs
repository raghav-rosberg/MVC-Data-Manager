﻿using System.Web.Mvc;

namespace UserManagementPortal.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //var userRepository = new UserRepository();

            //userRepository.Create(new ApplicationUser
            //{
            //    FirstName = "Test",
            //    LastName = "Test",
            //    DateCreated = DateTime.Now,
            //    Activated = true,
            //    Email = "test@test.com",
            //    EmailConfirmed = true,
            //    PasswordHash = "test",
            //    PhoneNumber = "00000000000",
            //    PhoneNumberConfirmed = true,
            //    TwoFactorEnabled = false,
            //    LockoutEnabled = false,
            //    AccessFailedCount = 0,
            //    UserName = "test"
            //});

            //----------------------------------------------------------------

            //var employeeRepository = new EmployeeRepository();

            //employeeRepository.Create(new Employee
            //{
            //    Name = "Test",
            //    Designation = "Test"
            //});

            return View();
        }
    }
}