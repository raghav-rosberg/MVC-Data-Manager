using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcDataManager.Model;
using MvcUserManagement.data;
using MvcUserManagement.data.EmployeeRespository;
using MvcUserManagement.data.UserRepository;

namespace MvcUserManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserRepository _userRepository;
        public AccountController()
        {
            _userRepository = new UserRepository(Startup.DataProtectionProvider);
        }

        #region Index
        [Authorize]
        public ActionResult Index()
        {
            var users = _userRepository.GetAll();
            return View(users);
        }
        #endregion

        #region Register
        [HttpGet]
        public ActionResult Register(UserInfo user)
        {
            var securityQuestions = _userRepository.GetSecurityQuestions();
            var listItems = new List<SelectListItem> { new SelectListItem { Text = "Select", Value = "" } };
            if (securityQuestions != null)
                securityQuestions.ToList().ForEach(x => listItems.Add(new SelectListItem { Text = x.Question, Value = Convert.ToString(x.Id) }));
            user.SecurityQuestions = listItems;
            ModelState.Clear();
            return View(user);
        }

        [HttpPost]
        [ActionName("Register")]
        public ActionResult RegisterPost(UserInfo user)
        {
            if (!ModelState.IsValid) return View();
            var applicationUser = new ApplicationUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                LastLoginTime = DateTime.Now,
                Activated = true,
                SecurityQuestionId = user.SecurityQuestionId,
                SecurityAnswer = user.SecurityAnswer
            };
            return _userRepository.Register(applicationUser, user.Password, "Register", "Index");
        }
        #endregion

        #region Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
            return !ModelState.IsValid ? View() : _userRepository.SignIn(userLogin.UserName, userLogin.Password, null, false, "Login", "Index");
        }
        #endregion Login

        #region LogOut
        public ActionResult LogOut()
        {
            return _userRepository.SignOff("Index");
        }
        #endregion

        #region ForgotPassword
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            var model = new ForgotPassword { SecurityQuestions = _userRepository.GetSecurityQuestions() };
            return View(model);
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPassword model)
        {
            if (ModelState.IsValid)
                return _userRepository.AuthenticateUserSecurityAnswer(model, "ForgotPassword");
            model.SecurityQuestions = _userRepository.GetSecurityQuestions();
            return View(model);
        }

        public ActionResult CancelForgotPassword()
        {
            return RedirectToAction("Login");
        }
        #endregion

        #region ResetPassword
        [HttpGet]
        public ActionResult ResetPassword(ResetPassword model)
        {
            ModelState.Clear();
            return View(model);
        }

        [HttpPost]
        [ActionName("ResetPassword")]
        public ActionResult ResetPasswordPost(ResetPassword model)
        {
            if (ModelState.IsValid)
                return _userRepository.ResetPassword(model, "ResetPassword", "Login");
            return View(model);
        }
        #endregion
    }
}
