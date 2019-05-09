using CloudtrixApp.Core.ViewModel;
using CloudtrixApp.Data.AuthHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CloudtrixApp.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        public HomeController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {

            AppAuth auth = new AppAuth();
            try
            {
                if (Membership.ValidateUser(model.Email, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    var currentUser = auth.GetUserProfile(model.Email, model.Password);
                    //Session["LoginUser"] = currentUser;
                    if (currentUser.Role == "Admin")
                        return RedirectToAction("Index", "Admin");                   
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    TempData["FFMsg"] = "Invalid user name and password!";
                    return RedirectToAction("Login");
                }
            }
            catch (Exception e)
            {
                TempData["FFMsg"] = "Something wrong! Contact with Administrator!";
                return RedirectToAction("Login");
            }
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


    }
}