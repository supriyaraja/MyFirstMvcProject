using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetEmployee(int? EmpId)
        {
            ViewBag.EmpInfo = EmpId;
            return View();
        }
        //public string GetEmployeeusingEmpID(int EmpId, string EmpName, int EmpSalary)
        //{
        //    return "Employee ID : " + EmpId + " Employee Name : " + EmpName + " Employee Salary : " + EmpSalary;
        //}
    }
}