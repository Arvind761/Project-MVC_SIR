using FullMVC_crud.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;





namespace FullMVC_crud.Controllers
{
    public class EmployeeController : Controller
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-H468LH3\\SQLEXPRESS;initial catalog=db2425_29425;integrated security=true");


        public ActionResult EmployeeForm()
        {
            return View();
        }

        //insert data
        public void InsertData(EmployeeModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@mobile", obj.Mobile);
            cmd.Parameters.AddWithValue("@age", obj.Age);
            cmd.Parameters.AddWithValue("@country", obj.Country);
            cmd.Parameters.AddWithValue("@state", obj.State);
            cmd.Parameters.AddWithValue("@city", obj.City);
            cmd.ExecuteNonQuery();
            con.Close();
        }





        //update data

        public void UpdateData(EmployeeModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", obj.Id);
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@mobile", obj.Mobile);
            cmd.Parameters.AddWithValue("@age", obj.Age);
            cmd.Parameters.AddWithValue("@country", obj.Country);
            cmd.Parameters.AddWithValue("@state", obj.State);
            cmd.Parameters.AddWithValue("@city", obj.City);
            cmd.ExecuteNonQuery();
            con.Close();
        }



        //delete data
        public void DeleteData(EmployeeModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", obj.Id);
            cmd.ExecuteNonQuery();
            con.Close();
        }





        //edit data
        public JsonResult EditData(EmployeeModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_edit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", obj.Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }



        //get data
        public JsonResult GetData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCountryData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblcountry", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStateData(int A)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblstate where countryid='" + A + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCityData(int A)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblcity where stateid='" + A + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }



    }
}