using CloudtrixApp.Core.AppData;
using CloudtrixApp.Core.DataModel;
using CloudtrixApp.Core.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using CloudtrixApp.Core.ViewModel;
using CloudtrixApp.Web.Reports;
using PharmaApp.Web.Models;
using PharmaApp.Web.DAL;

namespace PharmaApp.Web.Controllers
{
    [AllowAnonymous]
    [BaseController]
    public class AdminController : Controller
    {
        private readonly IArchitectRepository _architectRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITimeSheetRepository _timesheetRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IStoreSettingRepository _storeRepository;
        private readonly IInvoiceItemRepository _InvoiceItemRepository;
        private readonly IInvoiceRepository _InvoiceRepository;
        ClsCloudtrix _clsCloud = new ClsCloudtrix();


        public AdminController(IArchitectRepository architectRepository,
                               IEmployeeRepository employeeRepository,
                               ITimeSheetRepository timesheetRepository,
                               ICustomerRepository customerRepository,
                               IProjectRepository projectRepository,
                               IStoreSettingRepository storeRepository,
                               IInvoiceItemRepository InvoiceItemRepository,
                               IInvoiceRepository InvoiceRepository)
        {
            _architectRepository = architectRepository;
            _employeeRepository = employeeRepository;
            _timesheetRepository = timesheetRepository;
            _customerRepository = customerRepository;
            _projectRepository = projectRepository;
            _storeRepository = storeRepository;
            _InvoiceRepository = InvoiceRepository;
            _InvoiceItemRepository = InvoiceItemRepository;
        }
        // GET: Admin

        public ActionResult Index()
        {
            menuRights(1);
            int totalInvoice = 0;
            int totalproject = 0;
            int stocks = 0;
            if (_InvoiceRepository.All().Count() > 0)
            {
                totalInvoice = Convert.ToInt32(_InvoiceRepository.All().Sum(x => x.Total));
            }
            if (_projectRepository.All().Count() > 0)
            {
                totalproject = Convert.ToInt32(_projectRepository.All().Sum(x => x.Id));
            }
            var dashboard = new DashboardViewModel
            {

            };
            return View(dashboard);
        }

        #region Architect
        [HttpGet]
        public ActionResult AddArchitect()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddArchitect(ArchitectModel model)
        {
            if (ModelState.IsValid)
            {
                _architectRepository.Insert(model);
                return RedirectToAction("ArchitectList");
            }
            return View(model);
        }
        public ActionResult ArchitectList()
        {
            menuRights(4);
            return View(_architectRepository.All());
        }
        [HttpGet]
        public ActionResult EditArchitect(int ArchitectId)
        {
            var Architect = _architectRepository.Find(ArchitectId);
            return View(Architect);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditArchitect(ArchitectModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _architectRepository.Update(model);
            return RedirectToAction("ArchitectList");
        }

        public ActionResult DeleteArchitect(int ArchitectId)
        {
            var Architect = _architectRepository.Find(ArchitectId);
            if (Architect != null)
            {
                _architectRepository.Remove(ArchitectId);
                return RedirectToAction("ArchitectList");
            }
            return RedirectToAction("ArchitectList");
        }
        #endregion

        #region Employee
        [HttpGet]
        public ActionResult AddEmployee()
        {
            FillRoleCombo();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployee(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Insert(model);
                return RedirectToAction("EmployeeList");
            }
            return View(model);
        }
        public ActionResult EmployeeList()
        {
            return View(_employeeRepository.All());
        }
        [HttpGet]
        public ActionResult EditEmployee(int EmployeeId)
        {
            FillRoleCombo();
            var Employee = _employeeRepository.Find(EmployeeId);
            return View(Employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee(EmployeeModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _employeeRepository.Update(model);
            return RedirectToAction("EmployeeList");
        }

        public ActionResult DeleteEmployee(int EmployeeId)
        {
            var Employee = _employeeRepository.Find(EmployeeId);
            if (Employee != null)
            {
                _employeeRepository.Remove(EmployeeId);
                return RedirectToAction("EmployeeList");
            }
            return RedirectToAction("EmployeeList");
        }

        public void FillRoleCombo()
        {
            try
            {
                CloudtrixModel _objModel = new CloudtrixModel();
                var DDLRoleIDData = _clsCloud.RoleMaster_ListAll(_objModel);
                if (DDLRoleIDData != null && DDLRoleIDData.Count > 0)
                    ViewBag.DDLRoleID = DDLRoleIDData;
                else
                    ViewBag.DDLRoleID = new List<SelectListItem> { };
            }
            catch (Exception ex)
            {
                ViewBag.DDLRoleID = new List<SelectListItem> { };
                throw ex;
            }
        }
        #endregion

        #region customer
        [HttpGet]
        public ActionResult AddCustomer()
        {
            FillStateCombo();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomer(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.Insert(model);
                return RedirectToAction("CustomerList");
            }
            return View(model);
        }
        public ActionResult CustomerList()
        {
            menuRights(2);
            return View(_customerRepository.All());
        }
        [HttpGet]
        public ActionResult EditCustomer(int customerId)
        {
            var customer = _customerRepository.Find(customerId);
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(CustomerModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _customerRepository.Update(model);
            return RedirectToAction("CustomerList");
        }

        public ActionResult DeleteCustomer(int customerId)
        {
            var customer = _customerRepository.Find(customerId);
            if (customer != null)
            {
                _customerRepository.Remove(customerId);
                return RedirectToAction("CustomerList");
            }
            return RedirectToAction("CustomerList");
        }
        #endregion

        #region project
        [HttpGet]
        public ActionResult AddProject()
        {
            ProjectDropdown();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProject(ProjectModel model)
        {
            if (ModelState.IsValid)
            {
                ProjectDropdown();
                _projectRepository.Insert(model);
                return RedirectToAction("ProjectList");
            }
            return View(model);
        }
        public ActionResult ProjectList()
        {
            menuRights(3);
            return View(_projectRepository.All(x => x.ArchitectModel));
        }
        [HttpGet]
        public ActionResult EditProject(int projectId)
        {
            var project = _projectRepository.Find(projectId);
            ProjectDropdown();
            return View(project);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProject(ProjectModel model)
        {
            if (!ModelState.IsValid)
            {
                ProjectDropdown();
                return View(model);
            }
            _projectRepository.Update(model);
            return RedirectToAction("ProjectList");
        }

        public ActionResult DeleteProject(int projectId)
        {
            var project = _projectRepository.Find(projectId);
            if (project != null)
            {
                _projectRepository.Remove(projectId);
                return RedirectToAction("ProjectList");
            }
            return RedirectToAction("ProjectList");
        }

        #endregion

        #region TimeSheet
        [HttpGet]
        public ActionResult AddTimeSheet()
        {
            TimeSheetDropdown();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTimeSheet(TimeSheetModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TimeSheetDropdown();
                    var Stime = model.StartTime.ToString("H:mm:ss tt");
                    var Etime = model.EndTime.ToString("H:mm:ss tt");
                    var Entime = model.EntryDate.ToString("M/d/yyyy");

                    model.StartTime = Convert.ToDateTime(Entime + " " + Stime);
                    model.EndTime = DateTime.Parse(Entime + " " + Etime);

                    CloudtrixModel _obj = new CloudtrixModel();
                    _obj.ProjectId = model.ProjectId;_obj.EmployeeId = model.EmployeeId;
                    _obj.StartTime = model.StartTime;_obj.EndTime = model.EndTime;
                    var Data = _clsCloud.TimeSheet_VerifyDetails(_obj).FirstOrDefault();
                    if (_obj.IsFound)
                    {
                        TempData["FFMsg"] = "Time Slot Already Exit";
                        return View(model);
                    }
                    else
                    {
                        _timesheetRepository.Insert(model);
                    }
                    return RedirectToAction("TimeSheetList");
                }
            }
            catch (Exception ex)
            {
                TimeSheetDropdown();
                if (ex.InnerException == null) { TempData["FFMsg"] = ex.Message; } else { TempData["FFMsg"] = ex.InnerException.Message; }
            }
            return View(model);
        }
        public ActionResult TimeSheetList()
        {
            menuRights(7);
            CloudtrixModel _objModel = new CloudtrixModel();
            var Data = _clsCloud.TimeSheet_Listall(_objModel).ToList();
            return View(Data);
        }
        [HttpGet]
        public ActionResult EditTimeSheet(int TimeSheetId)
        {
            var TimeSheet = _timesheetRepository.Find(TimeSheetId);
            TimeSheetDropdown();
            return View(TimeSheet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTimeSheet(TimeSheetModel model)
        {
            if (!ModelState.IsValid)
            {
                TimeSheetDropdown();
                return View(model);
            }
            _timesheetRepository.Update(model);
            return RedirectToAction("TimeSheetList");
        }

        public ActionResult DeleteTimeSheet(int TimeSheetId)
        {
            var TimeSheet = _timesheetRepository.Find(TimeSheetId);
            if (TimeSheet != null)
            {
                _timesheetRepository.Remove(TimeSheetId);
                return RedirectToAction("TimeSheetList");
            }
            return RedirectToAction("TimeSheetList");
        }

        public ActionResult TimeSheetReport(int Id=0)
        {
            CloudtrixModel _objModel = new CloudtrixModel();
            _objModel.ProjectId = Id;
            FillProjectCombo();
            var Data = _clsCloud.TimeSheet_Report(_objModel).ToList();
            return View(Data);
        }
        
        #endregion

        #region Store Settings 
        [HttpGet]
        public ActionResult StoreSetting()
        {
            menuRights(8);
            FillStateCombo();
            var settings = _storeRepository.All().FirstOrDefault();
            if (settings != null)
                return View(settings);
            return View(new StoreSettingModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StoreSetting(StoreSettingModel model, HttpPostedFileBase logoPostedFileBase)
        {
            if (!ModelState.IsValid) return View(model);
            if (logoPostedFileBase != null)
            {
                string fileName = Path.GetFileName(logoPostedFileBase.FileName);
                string GUID = Guid.NewGuid().ToString().Substring(0, 3).Replace("-", "").ToUpper();
                string guidFileName = GUID + fileName;
                var path = Path.Combine(Server.MapPath(AppData.DefaultPath), guidFileName);
                logoPostedFileBase.SaveAs(path);
                model.Logo = AppData.DefaultPath + guidFileName;
            }

            if (model.Id > 0)
            {
                var settings = _storeRepository.All().FirstOrDefault();
                settings.StoreName = model.StoreName;
                settings.Phone = model.Phone;
                settings.Currency = model.Currency;
                settings.Web = model.Web;
                settings.Email = model.Email;
                settings.Address = model.Address;
                settings.State = model.State;
                if (settings.Logo != "" && logoPostedFileBase == null)
                    settings.Logo = settings.Logo;
                else
                    settings.Logo = model.Logo;

                _storeRepository.Update(settings);
                TempData["Msg"] = "Store setting updated successfully";
                return RedirectToAction("StoreSetting");
            }
            _storeRepository.Insert(model);
            FillStateCombo();
            TempData["Msg"] = "Store setting updated successfully";
            return RedirectToAction("StoreSetting");
        }
        #endregion

        #region Invoice
        [HttpGet]
        public ActionResult Invoice()
        {
            InvoiceDropDown();
            return View();
        }
        [HttpPost]
        public ActionResult Invoice(InvoiceModel model)
        {
            if (ModelState.IsValid)
            {
                _InvoiceRepository.Insert(model);
                return Json(new { error = false, message = "Invoice saved successfully" });
            }
            return Json(new { error = true, message = "Failed to save Invoice" });
        }

        public ActionResult InvoiceList()
        {
            menuRights(6);
            return View(_InvoiceRepository.All(x => x.ProjectModel));
        }

        [HttpGet]
        public ActionResult EditInvoice(int InvoiceId)
        {
            var Invoice = _InvoiceRepository.Find(InvoiceId);
            if (Invoice != null)
            {
                return View(model: InvoiceId);
            }
            return RedirectToAction("InvoiceList");
        }

        [HttpPost]
        public ActionResult UpdateInvoice(InvoiceModel model)
        {
            if (ModelState.IsValid)
            {
                // remove 
                var items = _InvoiceItemRepository.All().Where(x => x.InvoiceId == model.Id).ToList();
                if (items.Any())
                {
                    //remove from Invoice item
                    foreach (var item in items)
                    {
                        _InvoiceItemRepository.Remove(item.Id);
                    }
                }

                var Invoice = _InvoiceRepository.Find(model.Id);
                Invoice.Notes = model.Notes;
                Invoice.PaymentMethod = model.PaymentMethod;
                Invoice.InvoiceCode = model.InvoiceCode;
                Invoice.ProjectId = model.ProjectId;
                Invoice.Total = model.Total;
                Invoice.InvoiceDate = model.InvoiceDate;
                Invoice.Status = model.Status;
                Invoice.Discount = model.Discount;
                Invoice.GrandTotal = model.GrandTotal;

                //add again
                foreach (var item in model.Items)
                {
                    Invoice.Items.Add(new InvoiceItemsModel
                    {
                        Description = item.Description,
                        Price = item.Price,
                        Amount = item.Amount,
                        Quantity = item.Quantity,
                    });
                }
                _InvoiceRepository.Update(Invoice);

                // add quantity to stock and or add new 
                return Json(new { error = false, message = "Invoice updated successfully" });
            }
            return Json(new { error = true, message = "failed to Update Invoice" });
        }

        public ActionResult DeleteInvoice(int InvoiceId)
        {
            var items = _InvoiceItemRepository.All().Where(x => x.InvoiceId == InvoiceId).ToList();
            if (items.Any())
            {
                // subtract item quantity from stock
            }
            _InvoiceRepository.Remove(InvoiceId);


            return RedirectToAction("InvoiceList");
        }


        public ActionResult InvoiceInvoice(int InvoiceId, int style)
        {
            if (_storeRepository.All().Count() == 0)
            {
                TempData["Msg"] = "Setup store setting first then print sale invoice";
                return RedirectToAction("Index");
            }
            var store = _storeRepository.All().FirstOrDefault();

            var Invoice = _InvoiceRepository.All(x => x.ProjectModel).SingleOrDefault(x => x.Id == InvoiceId);
            Invoice.Items = _InvoiceItemRepository.All(x => x.Description).Where(x => x.InvoiceId == InvoiceId).ToList();
            if (Invoice != null)
            {
                var Invoicees = new InvoiceReportViewModel
                {
                    company = store,
                    Invoice = Invoice
                };
                if (style == 1)
                {
                    InvoiceReport paymentReport = new InvoiceReport();
                    byte[] bytes = paymentReport.CreateReport(Invoicees);
                    return File(bytes, "application/pdf");
                }
                if (style == 2)
                {
                    InvoiceReportSmall paymentReport = new InvoiceReportSmall();
                    byte[] bytes = paymentReport.CreateReport(Invoicees);
                    return File(bytes, "application/pdf");
                }
            }

            return RedirectToAction("InvoiceList");
        }

        #endregion

        #region json methods

        #region Customer Project Link
        public JsonResult GetCustomer()
        {
            return Json(_customerRepository.All(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProjectByCustomer(int customerId = 0)
        {
            if (customerId == 0)
                return Json(_projectRepository.All(), JsonRequestBehavior.AllowGet);
            return Json(_projectRepository.All().Where(x => x.CustomerId == customerId), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProjectById(int id)
        {
            return Json(_projectRepository.All().Where(x => x.Id == id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCustomerState(int customerId = 0)
        {
            CloudtrixModel _objModel = new CloudtrixModel();
            _objModel.CustomerID = customerId;
            var result = _clsCloud.Customer_StateVerify(_objModel).FirstOrDefault();
            if (result == null)
                return null;
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        #endregion

        #endregion

        #region Add Project DropDown
        private void ProjectDropdown()
        {
            ViewBag.architect = _architectRepository.ArchitectForDropdown();
            ViewBag.customer = _customerRepository.CustomerForDropdown();
        }
        #endregion

        #region Add Invoice DropDown
        private void InvoiceDropDown()
        {
            ViewBag.project = _projectRepository.ProjectForDropdown();
            ViewBag.customer = _customerRepository.CustomerForDropdown();
        }
        #endregion

        #region Add TimeSheet DropDown

        private void TimeSheetDropdown()
        {
            ViewBag.project = _projectRepository.ProjectForDropdown();
            ViewBag.employee = _employeeRepository.EmployeeForDropdown();
        }

        #endregion

        #region Role

        public ActionResult RoleIndex()
        {
            menuRights(9);
            CloudtrixModel _objModel = new CloudtrixModel();
            var Data = _clsCloud.RoleMaster_ListAll(_objModel).ToList();
            return View(Data);
        }


        public ActionResult AddRole(int RoleID = 0)
        {
            CloudtrixModel _objModel = new CloudtrixModel();
            if (RoleID > 0)
            {
                _objModel.RoleID = RoleID;
                _objModel = _clsCloud.RoleMaster_ListAll(_objModel).FirstOrDefault();
            }
            _objModel.RoleID = RoleID;
            ViewBag.RightsList = _clsCloud.MenuRights_ListAll(_objModel).ToList();
            return View(_objModel);
        }

        [HttpPost]
        public ActionResult AddRole(CloudtrixModel _objModel, FormCollection frm)
        {
            try
            {
                _clsCloud.Conn = ClsAppDatabase.GetCon();
                if (_clsCloud.Conn.State == ConnectionState.Closed) { _clsCloud.Conn.Open(); } else { _clsCloud.Conn.Close(); _clsCloud.Conn.Open(); }
                _clsCloud.Tras = _clsCloud.Conn.BeginTransaction();

                var Data = _clsCloud.MenuRights_ListAll(_objModel).ToList();

                if (_objModel.RoleID > 0)
                {
                    _clsCloud.RoleMaster_Update(_objModel);
                }
                else
                {
                    _objModel.RoleID = _clsCloud.RoleMaster_Add(_objModel);
                }


                for (int i = 0; i < Data.Count; i++)
                {
                    int intMenuID = Data[i].MenuID;

                    for (int j = 0; j < frm.Count; j++)
                    {
                        string GetAllkeysStringValue = frm.AllKeys[j];
                        if (GetAllkeysStringValue.Equals("menu_" + intMenuID + ""))
                        {
                            _objModel.MenuID = Convert.ToInt32(frm["menu_" + intMenuID + ""]);
                            _objModel.IsAdd = frm["checkboxAdd_" + intMenuID + ""] != null ? true : false;
                            _objModel.IsView = frm["checkboxView_" + intMenuID + ""] != null ? true : false;
                            _objModel.MenuRightsID = Convert.ToInt32(frm["MenuRights_" + intMenuID + ""]);
                            if (_objModel.MenuRightsID > 0)
                            {
                                _clsCloud.MenuRights_Update(_objModel);
                            }
                            else
                            {
                                _clsCloud.MenuRights_Add(_objModel);
                            }
                        }
                    }
                }

                _clsCloud.Tras.Commit();
                _clsCloud.Conn.Close();
                return RedirectToAction("RoleIndex");
            }
            catch (Exception ex)
            {
                _clsCloud.Tras.Rollback();
                _clsCloud.Conn.Close();
                if (ex.InnerException == null) { TempData["FFMsg"] = ex.Message; } else { TempData["FFMsg"] = ex.InnerException.Message; }
            }

            return View(_objModel);
        }

        #endregion

        #region Other

        public void FillStateCombo()
        {
            try
            {
                CloudtrixModel _objModel = new CloudtrixModel();
                var DDLStateData = _clsCloud.StateMaster_ListAll(_objModel);
                if (DDLStateData != null && DDLStateData.Count > 0)
                    ViewBag.DDLStateID = DDLStateData;
                else
                    ViewBag.DDLStateID = new List<SelectListItem> { };
            }
            catch (Exception ex)
            {
                ViewBag.DDLStateID = new List<SelectListItem> { };
                throw ex;
            }
        }

        public void menuRights(int menuID = 0)
        {
            CloudtrixModel _objModel = new CloudtrixModel();
            _objModel.MenuID = menuID;
            _objModel.RoleIDs = Convert.ToString(Session["RoleID"]);
            var Rights = _clsCloud.MenuRoleRights_ListAll(_objModel).FirstOrDefault();
            if (Rights == null)
            {
                //filterContext.Result = new RedirectResult(string.Format("/Admin/AccessDenied"));
                //Response.RedirectToRoute("/Admin/AccessDenied");
                Response.Redirect(Url.Action("AccessDenied", "Admin"));
            }
            else
            {
                ViewBag.IsAdd = Rights.IsAdd;
                ViewBag.IsView = Rights.IsView;
            }
        }

        public ActionResult AccessDenied()
        {

            return View();
        }

        [HttpPost]
        public JsonResult GetStateData(string stateName)
        {
            CloudtrixModel _objModel = new CloudtrixModel();
            _objModel.StateName = stateName;
            var result = _clsCloud.StateMaster_ListAll(_objModel).FirstOrDefault();
            if (result == null)
                return null;
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }
        public void FillProjectCombo()
        {
            try
            {
                CloudtrixModel _objModel = new CloudtrixModel();
                var DDLProjectData = _clsCloud.Project_Listall(_objModel);
                if (DDLProjectData != null && DDLProjectData.Count > 0)
                    ViewBag.DDLProjectID = DDLProjectData;
                else
                    ViewBag.DDLProjectID = new List<SelectListItem> { };
            }
            catch (Exception ex)
            {
                ViewBag.DDLProjectID = new List<SelectListItem> { };
                throw ex;
            }
        }
        #endregion
    }
}