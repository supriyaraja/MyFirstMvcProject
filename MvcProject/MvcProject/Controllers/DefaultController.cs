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
        MvcApplicaionEntities1 db = new MvcApplicaionEntities1();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        //send empid through viewbag
        public ActionResult GetEmployee(int? EmpId)
        {
            ViewBag.EmpInfo = EmpId;
            return View();
        }
        // return the string
        public string GetName()
        {
            return "Hello World";
        }
        //call another view using actionResult
        public ActionResult CallingView()
        {
            return View("GetEmployee");
        }
        //call multiple parameters using URl
        //https://localhost:44388/default/GetEmployeeusingEmpID/1111?Ename=supriya&EmpSalary=240000&Designation=Engineer
        public string GetEmployeeusingEmpID(int? EmpId,string Ename, int EmpSalary, string Designation)
        {
            return "Employee ID : " + EmpId + " Employee Name : " + Ename + " Employee Salary : " + EmpSalary + "Employee Designation" + Designation;
        }
        public string GetEmployeeDetails(int? EmpId)
        {
            //https://localhost:44388/default/GetEmployeeDetails/1111?Ename=supriya&EmpSalary=240000&Designation=Engineer
            return "Employee ID : " + EmpId + " Employee Name : " + Request.QueryString["Ename"] + " Employee Salary : " + Request.QueryString["EmpSalary"] + " Employee Designation : " + Request.QueryString["Designation"];
        }

        public ActionResult GetData()
        {
            return View();
        }
        public ActionResult HtmlHelperControls()
        {
            ViewBag.Department = new SelectList(db.Departments, "DeptId", "DeptName");
            return View();
        }

    }
}