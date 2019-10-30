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
    }
}