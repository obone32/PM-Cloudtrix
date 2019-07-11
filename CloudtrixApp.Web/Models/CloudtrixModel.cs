using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PharmaApp.Web.Models
{
    public class CloudtrixModel
    {
        public int Id { get; set; }
        public int RoleID { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string RoleDesc { get; set; }
        public bool IsDelete { get; set; }
        public int MenuRightsID { get; set; }
        public int MenuID { get; set; }
        public string RoleIDs { get; set; }
        public int ParentMenuID { get; set; }
        public bool IsAdd { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsView { get; set; }
        public int IsAdmin { get; set; }
        public string MenuName { get; set; }
        public string EmployeeEmail { get; set; }
        public string Password { get; set; }
        public int LoginHistoryID { get; set; }
        public int EmpID { get; set; }
        public string EmailID { get; set; }
        public string LoginIP { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int StateID { get; set; }
        public string StateName { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsStateMatch { get; set; }
        public int CustomerID { get; set; }
        public bool IsFound { get; set; }
        public string ProjectName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime EntryDate { get; set; }
        [DataType(DataType.Time)]
        public string WorkDetails { get; set; }
        public string TotTime { get; set; }
        public decimal TotalHour { get; set; }
        public decimal TotalCost { get; set; }
        public decimal HourlyRate { get; set; }
        public string EmployeeNames { get; set; }
        public int ArchitectId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}