using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Mvc;
using MvcDataManager.Model;

namespace MvcUserManagement.data.UserRepository
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetAll();

        ActionResult Register(ApplicationUser applicationUser, string password, string view, string redirectView,
            string redirectCntroller = "");

        ActionResult SignIn(string userName, string password, IEnumerable<Claim> claims, bool isPersistent, string view,
            string redirectView, string redirectController = "");

        ActionResult SignOff(string redirectView, string redirectController = "");

        IEnumerable<SecurityQuestion> GetSecurityQuestions();

        ActionResult AuthenticateUserSecurityAnswer(ForgotPassword model, string view);

        ActionResult ResetPassword(ResetPassword model, string view, string redirectView,
            string redirectController = "");
    }
}
