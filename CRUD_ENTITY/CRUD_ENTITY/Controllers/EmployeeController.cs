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
        [HttpPost]
        public void InsertData(tblEmployee obj)
        {
            db.tblEmployees.Add(obj);
            db.SaveChanges();
            
        }

        [HttpPost]
        public void UpdateData(tblEmployee obj)
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            //return Json("OK");
        }

        [HttpPost]
        public void DeleteData(tblEmployee obj)
        {
            var data = db.tblEmployees.Find(obj.empid);
            db.tblEmployees.Remove(data);
            db.SaveChanges();

        }

        [HttpPost]
        public JsonResult EditData(tblEmployee obj)
        {
            var data = (from E in db.tblEmployees where E.empid==obj.empid select E).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ShowData()
        {
            var data = (from E in db.tblEmployees
                        join C in db.tblcountries on E.country equals C.countryid
                        join S in db.tblStates on E.state equals S.stateid
                        join CT in db.tblCities on E.city equals CT.cityid
                        select new {E.empid,E.name,E.mobile,E.age,C.countryname,S.statename,CT.cityname}).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ShowCountry()
        {
            var data = (from C in db.tblcountries select C).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ShowState(int A)
        {
            var data = (from S in db.tblStates where S.countryid == A select S).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ShowCity(int A)
        {
            var data = (from CT in db.tblCities where CT.stateid == A select CT).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult EmployeeForm()
        //{
        //    return View();
        //}
        //public void InsertData(tblEmployee obj)
        //{
        //    db.tblEmployees.Add(obj);
        //    db.SaveChanges();
        //}

        //public void UpdateData(tblEmployee obj)
        //{
        //    db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        //    db.SaveChanges();
        //}

        //public void DeleteData(tblEmployee obj)
        //{
        //    var data = db.tblEmployees.Find(obj.empid);
        //    db.tblEmployees.Remove(data);
        //    db.SaveChanges();
        //}

        //public JsonResult EditData(tblEmployee obj)
        //{
        //    var data = db.tblEmployees.Where(a => a.empid == obj.empid).ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult ShowData()
        //{
        //    var data = db.tblEmployees.ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult ShowCountry()
        //{
        //    var data = db.tblcountries.ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult ShowState(int A)
        //{
        //    var data = db.tblStates.Where(x => x.countryid==A).ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult ShowCity(int A)
        //{
        //    var data = db.tblCities.Where(x => x.stateid == A).ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult EmployeeForm()
        //{
        //    return View();
        //}
        //public void InsertData(tblEmployee obj)
        //{
        //    db.employee_insert(obj.name, obj.mobile, obj.age);
        //    db.SaveChanges();
        //}

        //public void UpdateData(tblEmployee obj)
        //{
        //    db.employee_update(obj.empid, obj.name, obj.mobile, obj.age);
        //    db.SaveChanges();
        //}

        //public void DeleteData(tblEmployee obj)
        //{
        //    db.employee_delete(obj.empid);
        //    db.SaveChanges();
        //}

        //public JsonResult EditData(tblEmployee obj)
        //{
        //    var data = db.employee_edit(obj.empid).ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult ShowData()
        //{
        //    var data = db.employee_get().ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

    }
}