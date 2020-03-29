using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Theme.Models;

namespace Theme.Controllers
{
    public class ReceptionFormsController : Controller
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-VLRKFE1\\SQLEXPRESS;Integrated Security=True;database=project;");
        // GET: ReceptionForms
        public ActionResult WalkinApp()

        {
             //SqlConnection con = new SqlConnection("server=DESKTOP-VLRKFE1\\SQLEXPRESS;Integrated Security=True;database=project;");
            // writing sql query  
            SqlCommand cm = new SqlCommand("Select * from StatusMaster", con);
            // Opening Connection  
            con.Open();
            // Executing the SQL query  
            SqlDataReader sdr = cm.ExecuteReader();
            // Iterating Data
            List<string> record;
            List<List<string>> data = new List<List<string>> { };

            while (sdr.Read())
            {
                record = new List<string> { sdr["TokenNo"].ToString(),sdr["Name"].ToString(), sdr["AppointmentType"].ToString(), sdr["Status"].ToString() };
                data.Add(record);
            }
            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        [ActionName("DataPush")]
        public ActionResult Walkin(Appointment obj)
        {
            
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
           
            SqlCommand cmd = new SqlCommand("pInsertReceptionAppointment",con);
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@AppointmentType", obj.AppointmentType);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            cmd.Parameters.AddWithValue("@Problem", obj.Problem);
            cmd.Parameters.AddWithValue("@Payment", obj.Payment);
            cmd.Parameters.AddWithValue("@EntryDateTime", obj.EntryDateTime);
            cmd.ExecuteNonQuery();
            return RedirectToAction("WalkinApp", "ReceptionForms");
        }
        public ActionResult AppointmentList()
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-VLRKFE1\\SQLEXPRESS;Integrated Security=True;database=project;");
            // writing sql query  
            SqlCommand cm = new SqlCommand("Select * from ReceptionAppointment", con);
            // Opening Connection  
            con.Open();
            // Executing the SQL query  
            SqlDataReader sdr = cm.ExecuteReader();
            // Iterating Data
            List<string> record;
            List<List<string>> data = new List<List<string>> { };

            while (sdr.Read())
            {
                record = new List<string> { sdr["Id"].ToString(),sdr["Name"].ToString(), sdr["AppointmentType"].ToString(), sdr["Phone"].ToString(), sdr["Address"].ToString(), sdr["Problem"].ToString(), sdr["Payment"].ToString(), sdr["Time"].ToString() };
                data.Add(record);
            }
            ViewBag.Data = data;
            return View();
        }
        public ActionResult StatusList()
        {
            return View();
        }
        public ActionResult settings()
        {
            return View();
        }
        public ActionResult ReceptionDashboard()
        {
            return View();
        }
        public ActionResult ReceptionProfile()
        {
            return View();
        }

    }
}


 