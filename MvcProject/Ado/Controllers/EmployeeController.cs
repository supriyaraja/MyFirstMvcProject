using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ado.Models;

namespace Ado.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeContext db = new EmployeeContext();

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConformation(int? id)
        {
            int i = db.DeleteEmploeeById(id);
            if(i>0)
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