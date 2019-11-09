using System;
using System.Collections.Generic;
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
    }
}