using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstApproach.Models;

namespace CodeFirstApproach.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeContext db = new EmployeeContext();
        // GET: Employee
        public ActionResult Index()
        {
            return View(db.EmployeeModels.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel emp)
        {
            db.EmployeeModels.Add(emp);
            int i = db.SaveChanges();
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            EmployeeModel obj = db.EmployeeModels.Find(Id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            EmployeeModel employeeModel = db.EmployeeModels.Find(id);
            return View(employeeModel);
        }

        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Deleteconform(int? Id)
        {
            EmployeeModel employeeModel = db.EmployeeModels.Find(Id);
            db.EmployeeModels.Remove(employeeModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetData()
        {
            TempData["EmployeeName"]="Sai";
            return RedirectToAction("SetData");
        }
        public ActionResult SetData()
        {
            var i =TempData["EmployeeName"].ToString();
            TempData.Keep();
            var s = TempData.Peek("EmployeeName").ToString();
            return View();
        }
    }
}