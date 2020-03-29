using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.SqlClient;
using Theme.Models;

namespace Theme.Controllers
{

    public class StaffController : Controller
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-VLRKFE1\\SQLEXPRESS;Integrated Security=True;database=project;");
        // GET: Staff
        public ActionResult InsertToAddStaff()
        {
            // writing sql query  
            SqlCommand cm = new SqlCommand("Select * from StaffMaster", con);
            // Opening Connection  
            con.Open();
            // Executing the SQL query  
            SqlDataReader sdr = cm.ExecuteReader();
            // Iterating Data
            List<string> record;
            List<List<string>> data = new List<List<string>> { };

            while (sdr.Read())
            {
                record = new List<string> { sdr["StaffId"].ToString(), sdr["StaffName"].ToString(), sdr["HospitalId"].ToString(), sdr["EmployeeCode"].ToString(), sdr["StaffSpecialization"].ToString(), sdr["StaffDegree"].ToString(), sdr["Designation"].ToString(), sdr["StaffPhone"].ToString(), sdr["StaffEmail"].ToString(), sdr["StaffCity"].ToString(), sdr["StaffState"].ToString(), sdr["StaffCountry"].ToString(), sdr["Status"].ToString(), sdr["EntryDate"].ToString(), sdr["EntryBy"].ToString(), sdr["RoleId"].ToString(), sdr["StaffAddress"].ToString() }; data.Add(record);
            }
            ViewBag.Data = data;
            return View();
           
        }
        [HttpPost]
        [ActionName("InsertData")]
        public ActionResult InsertToAddStaff(Staff obj)
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();

            SqlCommand cmd = new SqlCommand("pInsertAddStaff", con);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StaffName", obj.StaffName);
            cmd.Parameters.AddWithValue("@HospitalId", obj.HospitalId);
            cmd.Parameters.AddWithValue("@EmployeeCode", obj.EmployeeCode);
            cmd.Parameters.AddWithValue("@StaffSpecialization", obj.StaffSpecialization);
            cmd.Parameters.AddWithValue("@StaffDegree", obj.StaffDegree);
            cmd.Parameters.AddWithValue("@Designation", obj.Designation);

            cmd.Parameters.AddWithValue("@StaffPhone", obj.StaffPhone);
            cmd.Parameters.AddWithValue("@StaffEmail", obj.StaffEmail);
            cmd.Parameters.AddWithValue("@StaffCity", obj.StaffCity);
            cmd.Parameters.AddWithValue("@StaffState", obj.StaffState);
            cmd.Parameters.AddWithValue("@StaffCountry", obj.StaffCountry);
            cmd.Parameters.AddWithValue("@Status", obj.Status);
            cmd.Parameters.AddWithValue("@EntryDate",DateTime.Now);
            cmd.Parameters.AddWithValue("@EntryBy", obj.EntryBy);

            cmd.Parameters.AddWithValue("@RoleId", obj.RoleId);
            cmd.Parameters.AddWithValue("@StaffAddress", obj.StaffAddress);

            cmd.ExecuteNonQuery();
            return RedirectToAction("InsertToAddStaff", "Staff");
        }
            public ActionResult StaffList()
            {
                SqlConnection con = new SqlConnection("server=DESKTOP-VLRKFE1\\SQLEXPRESS;Integrated Security=True;database=project;");
                // writing sql query  
                SqlCommand cm = new SqlCommand("Select * from StaffMaster", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                // Iterating Data
                List<string> record;
                List<List<string>> data = new List<List<string>> { };

                while (sdr.Read())
                {
                record = new List<string> { sdr["StaffId"].ToString(), sdr["StaffName"].ToString(), sdr["HospitalId"].ToString(), sdr["EmployeeCode"].ToString(), sdr["StaffSpecialization"].ToString(), sdr["StaffDegree"].ToString(), sdr["Designation"].ToString(), sdr["StaffPhone"].ToString(), sdr["StaffEmail"].ToString(), sdr["StaffCity"].ToString(), sdr["StaffState"].ToString(), sdr["StaffCountry"].ToString(), sdr["Status"].ToString(), sdr["EntryDate"].ToString(), sdr["EntryBy"].ToString(), sdr["RoleId"].ToString(), sdr["StaffAddress"].ToString() }; data.Add(record);
            }
            ViewBag.Data = data;
                return View();
            }
        
        }
    }

