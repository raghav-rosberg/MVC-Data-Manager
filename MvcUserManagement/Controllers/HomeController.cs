using System.Web.Mvc;
using MvcUserManagement.data;
using MvcUserManagement.data.EmployeeRespository;

namespace MvcUserManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;

        public HomeController()
        {
            _employeeRepository = new EmployeeRepository();
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            _employeeRepository.InsertEmployee(new Employee
            {
                Name = "Raghav"
            });

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
