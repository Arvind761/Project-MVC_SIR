using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace InterViewWebService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-H468LH3\\SQLEXPRESS;initial catalog=db2425_29425;integrated security=true");
        [WebMethod]
        public void InsertData(string Name, long Mobile, int Age, int Country, int State, int City)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", Name);
            cmd.Parameters.AddWithValue("@mobile", Mobile);
            cmd.Parameters.AddWithValue("@age", Age);
            cmd.Parameters.AddWithValue("@country", Country);
            cmd.Parameters.AddWithValue("@state", State);
            cmd.Parameters.AddWithValue("@city", City);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void UpdateData(int Id, string Name, long Mobile, int Age, int Country, int State, int City)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", Id);
            cmd.Parameters.AddWithValue("@name", Name);
            cmd.Parameters.AddWithValue("@mobile", Mobile);
            cmd.Parameters.AddWithValue("@age", Age);
            cmd.Parameters.AddWithValue("@country", Country);
            cmd.Parameters.AddWithValue("@state", State);
            cmd.Parameters.AddWithValue("@city", City);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void DeleteData(int Id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", Id);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public string EditData(int Id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_edit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return data;
        }

        [WebMethod]
        public string ShowData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return data;
        }

        [WebMethod]
        public string ShowCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblcountry", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return data;
        }

        [WebMethod]
        public string ShowState(int A)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblstate where countryid='" + A + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return data;
        }

        [WebMethod]
        public string ShowCity(int A)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblcity where stateid='" + A + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return data;
        }
    }
}