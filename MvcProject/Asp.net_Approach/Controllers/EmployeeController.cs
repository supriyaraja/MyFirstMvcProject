using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asp.net_Approach.Models;

namespace Asp.net_Approach.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeContext db = new EmployeeContext();
        // GET: Employee
        public ActionResult Index()
        {
            return View(db.GetEmployeeDetails());
        }
        public ActionResult EmpDetails()
        {
            return View(db.GetEmployeeDetails());
        }
        [HttpGet]        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel emp)
        {
            int i = db.saveEmployeeDetails(emp);
            if (i > 0)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            EmployeeModel obj = db.GetEmployeeDetailsById(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel e)
        {
            int i = db.UpdateEmployeeDetailsById(e);
            if (i > 0)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConform(int? id)
        {
            int i = db.DeleteEmployeeDetailsById(id);
            if (i > 0)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }
    }
}