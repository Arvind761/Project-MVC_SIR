using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;


namespace CURDusingMVC.Controllers
{
    public class EmployeeController : Controller
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-H468LH3\\SQLEXPRESS;initial catalog=CRUD_MVC;integrated security=true");
        public ActionResult EmployeeForm()
        {
            return View();
        }

        public void InsertData(string A, long B, int C)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", A);
            cmd.Parameters.AddWithValue("@mobile", B);
            cmd.Parameters.AddWithValue("@age", C);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateData(string A, long B, int C, int D)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", D);
            cmd.Parameters.AddWithValue("@name", A);
            cmd.Parameters.AddWithValue("@mobile", B);
            cmd.Parameters.AddWithValue("@age", C);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteData(int D)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", D);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public JsonResult EditData(int D)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_edit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", D);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


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











    }
}