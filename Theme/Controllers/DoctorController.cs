using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Theme.Models;
using System.Data;


namespace Theme.Controllers
{
    public class DoctorController : Controller
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-VLRKFE1\\SQLEXPRESS;Integrated Security=True;database=project;");

        // GET: Doctor
        public ActionResult DoctorDashboard()
        {
            return View();
        }
        public ActionResult AppointmentsList()
        {
            return View();
        }
        public ActionResult DoctorCheckup()
        {
            return View();
        }
        public ActionResult DoctorOPDHistory()
        {
            return View();
        }
        public ActionResult Doctorprofile()
        {
            return View();
        }
        public ActionResult settings()
        {
            return View();
        }
        public ActionResult InsertToDoctor(string Doctorsearch)
        {
            // writing sql query  
            // writing sql query  

            // Opening Connection  
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            SqlCommand cm = new SqlCommand("Select * from DoctorMaster where DoctorName like '%" + Doctorsearch + "%'", con);
            // Executing the SQL query  
            SqlDataAdapter sda = new SqlDataAdapter(cm);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<DoctorClass> lemp = new List<DoctorClass>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lemp.Add(new DoctorClass
                {
                    EmployeeCode = Convert.ToInt32(dr["EmployeeCode"]),
                    DoctorName = Convert.ToString(dr["DoctorName"]),
                    HospitalId = Convert.ToInt32(dr["HospitalId"]),
                    DoctorSpecialization = Convert.ToString(dr["DoctorSpecialization"]),
                    DoctorDegree = Convert.ToString(dr["DoctorDegree"]),
                    DoctorPhone = Convert.ToString(dr["DoctorPhone"]),
                    DoctorEmail = Convert.ToString(dr["DoctorEmail"]),
                    DoctorState = Convert.ToString(dr["DoctorState"]),
                    DoctorCountry = Convert.ToString(dr["DoctorCountry"]),
                    IsActive = Convert.ToInt32(dr["IsActive"]),
                    EntryDate = Convert.ToString(dr["EntryDate"]),
                    EntryBy = Convert.ToString(dr["EntryBy"]),
                    RoleId = Convert.ToInt32(dr["RoleId"]),
                    DoctorAddress = Convert.ToString(dr["DoctorAddress"])

                });

            }
            con.Close();
            ModelState.Clear();
            return View(lemp);

        }



        [HttpPost]
        [ActionName("InsertData")]
        public ActionResult InsertToAddDoctor(DoctorClass obj)
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();

            SqlCommand cmd = new SqlCommand("pInsertDoctorMaster", con);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("@EmployeeCode", obj.EmployeeCode);
            cmd.Parameters.AddWithValue("@DoctorName", obj.DoctorName);
            cmd.Parameters.AddWithValue("@HospitalId", obj.HospitalId);
            cmd.Parameters.AddWithValue("@DoctorSpecialization", obj.DoctorSpecialization);
            cmd.Parameters.AddWithValue("@DoctorDegree", obj.DoctorDegree);
            cmd.Parameters.AddWithValue("@DoctorPhone", obj.DoctorPhone);
            cmd.Parameters.AddWithValue("@DoctorEmail", obj.DoctorEmail);
            cmd.Parameters.AddWithValue("@DoctorCity", obj.DoctorCity);
            cmd.Parameters.AddWithValue("@DoctorState", obj.DoctorState);
            cmd.Parameters.AddWithValue("@DoctorCountry", obj.DoctorCountry);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@EntryBy", obj.EntryBy);
            cmd.Parameters.AddWithValue("@RoleId", obj.RoleId);
            cmd.Parameters.AddWithValue("@DoctorAddress", obj.DoctorAddress);

            cmd.ExecuteNonQuery();
            return RedirectToAction("index", "Home");
        }
    }
}
