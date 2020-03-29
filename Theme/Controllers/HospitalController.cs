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
    public class HospitalController : Controller
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-VLRKFE1\\SQLEXPRESS;Integrated Security=True;database=project;");

        // GET: Hospital
        public ActionResult InsertToHospital(string Hospitalsearch)
        {  
                // writing sql query  

                // Opening Connection  
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                SqlCommand cm = new SqlCommand("Select * from HospitalMaster where HospitalName like '%" + Hospitalsearch + "%'", con);
                // Executing the SQL query  
                SqlDataAdapter sda = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                List<Hospital> lemp = new List<Hospital>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lemp.Add(new Hospital
                    {
                    HospitalName = Convert.ToString(dr["HospitalName"]),
                        HospitalAddress = Convert.ToString(dr["HospitalAddress"]),
                        HospitalCity = Convert.ToString(dr["HospitalCity"]),
                        HospitalState = Convert.ToString(dr["HospitalState"]),
                        HospitalCountry = Convert.ToString(dr["HospitalCountry"]),
                        HospitalPhone = Convert.ToString(dr["HospitalPhone"]),
                        HospitalEmail = Convert.ToString(dr["HospitalEmail"]),
                        HospitalLogo = Convert.ToString(dr["HospitalLogo"]),
                        IsActive = Convert.ToInt32(dr["IsActive"]),
                        EntryDateTime = Convert.ToString(dr["EntryDateTime"]),
                        EntryBy = Convert.ToString(dr["EntryBy"])


                    });

                }
                con.Close();
                ModelState.Clear();
                return View(lemp);

            }
        [HttpPost]
            [ActionName("Insert")]
            public ActionResult InsertToHospital(Hospital obj)
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("pInsertHospitalMaster", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HospitalName", obj.HospitalName);
                cmd.Parameters.AddWithValue("@HospitalAddress", obj.HospitalAddress);
                cmd.Parameters.AddWithValue("@HospitalCity", obj.HospitalCity);
                cmd.Parameters.AddWithValue("@HospitalState", obj.HospitalState);
                cmd.Parameters.AddWithValue("@HospitalCountry", obj.HospitalCountry);
                cmd.Parameters.AddWithValue("@HospitalPhone", obj.HospitalPhone);
                cmd.Parameters.AddWithValue("@HospitalEmail", obj.HospitalEmail);
                cmd.Parameters.AddWithValue("@HospitalLogo", obj.HospitalLogo);
                cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
                cmd.Parameters.AddWithValue("@EntryDateTime",DateTime.Now);
                cmd.Parameters.AddWithValue("@EntryBy", obj.EntryBy);
                cmd.ExecuteNonQuery();
                return RedirectToAction("index", "Home");
            }
        public ActionResult HospitalDashboard()
        {
            return View();
        }
        public ActionResult AddDoctors()
        {
            return View();
        }


        public ActionResult DoctorProfiles()
        {
            return View();
        }


        public ActionResult HospitalProfile()
        {
            return View();
        }


        public ActionResult HospitalSepcilization()
        {
            return View();
        }
        public ActionResult AddHospital()
        {
            return View();
        }
        public ActionResult AddPrescriptionDetail()
        {
            return View();
        }
        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult Feedback()
        {
            return View();
        }



    }
}

    // GET: Home

   
