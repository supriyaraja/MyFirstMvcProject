using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ViewResult GetEmployee()
        {
            Employee db = new Employee();
            db.EmpID = 1;
            db.EmpName = "Supriya";
            db.EmpSalary = 270000;
            return View(db);
        }
    }
}