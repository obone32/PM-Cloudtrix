using CloudtrixApp.Core.ViewModel;
using CloudtrixApp.Data.AuthHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PharmaApp.Web.Models;
using PharmaApp.Web.DAL;
using System.Data;

namespace CloudtrixApp.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        ClsCloudtrix _clsCloud = new ClsCloudtrix();
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
           
            CloudtrixModel _objModel = new CloudtrixModel();
            try
            {
                _clsCloud.Conn = ClsAppDatabase.GetCon();
                if (_clsCloud.Conn.State == ConnectionState.Closed) { _clsCloud.Conn.Open(); } else { _clsCloud.Conn.Close(); _clsCloud.Conn.Open(); }
                _clsCloud.Tras = _clsCloud.Conn.BeginTransaction();
              
                _objModel.EmployeeEmail = _objModel.EmailID = model.Email;
                _objModel.Password = model.Password;
                _objModel.LoginIP = Request.UserHostAddress;
                int LoginHistoryID = _clsCloud.LoginHistory_Add(_objModel);
                _objModel = _clsCloud.Employee_Verify(_objModel).FirstOrDefault();
                _objModel.LoginHistoryID = LoginHistoryID;
                if (_objModel != null)
                {
                    HttpContext.Session["EmployeeEmail"] = _objModel.EmployeeEmail;
                    HttpContext.Session["RoleID"] = _objModel.RoleID;
                    _objModel.IsSuccess = true;_objModel.Message = "Success";
                    _clsCloud.LoginHistory_Update(_objModel);
                    _clsCloud.Tras.Commit();
                    _clsCloud.Conn.Close();
                    return RedirectToAction("Index", "Admin");
                }

            }
            catch (Exception ex)
            {
                _objModel.IsSuccess = false; _objModel.Message = "Fail";
                _clsCloud.LoginHistory_Update(_objModel);
                _clsCloud.Tras.Commit();
                _clsCloud.Conn.Close();
                if (ex.InnerException == null) { TempData["FFMsg"] = ex.Message; } else { TempData["FFMsg"] = ex.InnerException.Message; }
                HttpContext.Session["EmployeeEmail"] = null;
                return RedirectToAction("Login");
            }
            return View(model);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            HttpContext.Session["EmployeeEmail"] = null;
            return RedirectToAction("Index", "Home");
        }

        public PartialViewResult _Navigation()
        {
            try
            {
                CloudtrixModel _objModel = new CloudtrixModel();
                _objModel.RoleIDs = Convert.ToString(Session["RoleID"]);
                var Data = _clsCloud.MenuRoleRights_ListAll(_objModel);
                return PartialView(Data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}