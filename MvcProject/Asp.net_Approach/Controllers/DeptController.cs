using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asp.net_Approach.Models;


namespace Asp.net_Approach.Controllers
{
    public class DeptController : Controller
    {
        DeptContext db = new DeptContext();
        // GET: Dept
        public ActionResult Index()
        {
            return View(db.GetDept());
        }
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DeptModel dept)
        {
            int i = db.SaveDeptDetails(dept);
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
        public ActionResult Edit(int? Id)
        {
            DeptModel obj = db.GetDeptDetailsById(Id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(DeptModel dept)
        {
            int i = db.UpdateDeptDetails(dept);
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
            int i = db.DeleteDeptDetailsById(id);
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