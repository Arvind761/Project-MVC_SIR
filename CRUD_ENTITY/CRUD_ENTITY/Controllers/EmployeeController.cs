using CRUD_ENTITY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_ENTITY.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        db2425_16525Entities db = new db2425_16525Entities();

        public ActionResult EmployeeForm()
        {
            return View();
        }
        public void InsertData(tblEmployee obj)
        {
            db.employee_insert(obj.name, obj.mobile, obj.age);
            db.SaveChanges();
        }

        public void UpdateData(tblEmployee obj)
        {
            db.employee_update(obj.empid, obj.name, obj.mobile, obj.age);
            db.SaveChanges();
        }

        public void DeleteData(tblEmployee obj)
        {
            db.employee_delete(obj.empid);
            db.SaveChanges();
        }

        public JsonResult EditData(tblEmployee obj)
        {
            var data = db.employee_edit(obj.empid).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ShowData()
        {
            var data = db.employee_get().ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}