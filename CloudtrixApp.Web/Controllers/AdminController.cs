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

namespace CloudtrixApp.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IArchitectRepository _architectRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITimeSheetRepository _timesheetRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IReceiptRepository _receiptRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IStoreSettingRepository _storeRepository;
        private readonly IInvoiceItemRepository _InvoiceItemRepository;
        private readonly IInvoiceRepository _InvoiceRepository;



        public AdminController(IArchitectRepository architectRepository,
                               IEmployeeRepository employeeRepository,
                               ITimeSheetRepository timesheetRepository,
                               ICustomerRepository customerRepository,
                               IReceiptRepository receiptRepository,
                               IProjectRepository projectRepository,
                               IStoreSettingRepository storeRepository,
                               IInvoiceItemRepository InvoiceItemRepository,
                               IInvoiceRepository InvoiceRepository)
        {
            _architectRepository = architectRepository;
            _employeeRepository = employeeRepository;
            _timesheetRepository = timesheetRepository;
            _customerRepository = customerRepository;
            _receiptRepository = receiptRepository;
            _projectRepository = projectRepository;
            _storeRepository = storeRepository;
            _InvoiceRepository = InvoiceRepository;
            _InvoiceItemRepository = InvoiceItemRepository;
        }
        // GET: Admin
        public ActionResult Index()
        {
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
        #endregion

        #region customer
        [HttpGet]
        public ActionResult AddCustomer()
        {
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

        #region Receipt
        [HttpGet]
        public ActionResult AddReceipt()
        {
            ReceiptDropdown();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReceipt(ReceiptModel model)
        {
            if (ModelState.IsValid)
            {
                _receiptRepository.Insert(model);
                return Json(new { error = false, message = "Receipt saved successfully" });
            }
            return Json(new { error = true, message = "Failed to save Receipt" });
        }
        public ActionResult ReceiptList()
        {
            return View(_receiptRepository.All(x => x.CustomerModel));
        }
        [HttpGet]
        public ActionResult EditReceipt(int ReceiptId)
        {
            var Receipt = _receiptRepository.Find(ReceiptId);
            ReceiptDropdown();
            return View(Receipt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReceipt(ReceiptModel model)
        {
            if (!ModelState.IsValid)
            {
                ReceiptDropdown();
                return View(model);
            }
            _receiptRepository.Update(model);
            return RedirectToAction("ReceiptList");
        }

        public ActionResult DeleteReceipt(int ReceiptId)
        {
            var Receipt = _receiptRepository.Find(ReceiptId);
            if (Receipt != null)
            {
                _receiptRepository.Remove(ReceiptId);
                return RedirectToAction("ReceiptList");
            }
            return RedirectToAction("ReceiptList");
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
            if (ModelState.IsValid)
            {
                TimeSheetDropdown();
                _timesheetRepository.Insert(model);
                return RedirectToAction("TimeSheetList");
            }
            return View(model);
        }
        public ActionResult TimeSheetList()
        {
            return View(_timesheetRepository.All(x => x.EmployeeModel));
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

        #endregion

        #region Store Settings 
        [HttpGet]
        public ActionResult StoreSetting()
        {
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

                if (settings.Logo != "" && logoPostedFileBase == null)
                    settings.Logo = settings.Logo;
                else
                    settings.Logo = model.Logo;

                _storeRepository.Update(settings);
                TempData["Msg"] = "Store setting updated successfully";
                return RedirectToAction("StoreSetting");
            }
            _storeRepository.Insert(model);
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
        #endregion

        #endregion

        #region Add Project DropDown
        private void ProjectDropdown()
        {
            ViewBag.architect = _architectRepository.ArchitectForDropdown();
            ViewBag.customer = _customerRepository.CustomerForDropdown();
        }
        #endregion

        #region Add Receipt DropDown
        private void ReceiptDropdown()
        {
            ViewBag.customer = _customerRepository.CustomerForDropdown();
            ViewBag.project = _projectRepository.ProjectForDropdown();
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

    }
}