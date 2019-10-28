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
            List<Employee> dbobj = new List<Employee>();

            Employee db = new Employee();
            db.EmpID = 1;
            db.EmpName = "Supriya";
            db.EmpSalary = 270000;

            Employee db1 = new Employee();
            db1.EmpID = 2;
            db1.EmpName = "Manoj";
            db1.EmpSalary = 28000;


            Employee db2= new Employee();
            db2.EmpID = 3;
            db2.EmpName = "Manoj";
            db2.EmpSalary = 28000;

            dbobj.Add(db);
            dbobj.Add(db1);
            dbobj.Add(db2);

            ViewBag.EmpDetails = dbobj;

            return View(dbobj);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}