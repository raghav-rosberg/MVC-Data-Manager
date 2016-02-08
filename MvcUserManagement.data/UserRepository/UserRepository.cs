using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Mvc;
using Microsoft.Owin.Security.DataProtection;
using MvcDataManager;
using MvcDataManager.Model;

namespace MvcUserManagement.data.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MvcDataManager.IUserRepository _userRepository;

        public UserRepository(IDataProtectionProvider dataProtectionProvider) 
        {
            _unitOfWork = new UnitOfWork(new MvcUserManagementDbContext());
            _userRepository = new MvcDataManager.UserRepository(dataProtectionProvider, _unitOfWork);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _userRepository.GetAll();
        }

        public ActionResult Register(ApplicationUser applicationUser, string password, string view, string redirectView,
            string redirectCntroller = "")
        {
            return _userRepository.Register(applicationUser, password, view, redirectView, redirectCntroller);
        }

        public ActionResult SignIn(string userName, string password, IEnumerable<Claim> claims, bool isPersistent, string view,
            string redirectView, string redirectController = "")
        {
            return _userRepository.SignIn(userName, password, claims, isPersistent, view, redirectView,
                redirectController);
        }

        public ActionResult SignOff(string redirectView, string redirectController = "")
        {
            return _userRepository.SignOff(redirectView, redirectController);
        }

        public IEnumerable<SecurityQuestion> GetSecurityQuestions()
        {
            return _userRepository.GetSecurityQuestions();
        }

        public ActionResult AuthenticateUserSecurityAnswer(ForgotPassword model, string view)
        {
            return _userRepository.AuthenticateUserSecurityAnswer(model, view);
        }

        public ActionResult ResetPassword(ResetPassword model, string view, string redirectView, string redirectController = "")
        {
            return _userRepository.ResetPassword(model, view, redirectView, redirectController);
        }
    }
}
