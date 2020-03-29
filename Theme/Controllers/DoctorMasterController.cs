using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Theme.Models;
namespace Theme.Controllers
{
    public class DoctorMasterController : Controller
    {
      // 1. *************RETRIEVE ALLDoctor DETAILS ******************
        // GET:Doctor
        public ActionResult DoctorList()
        {
           DoctorMasterDbHandle dbhandle = new DoctorMasterDbHandle();
            ModelState.Clear();
            return View(dbhandle.GetDoctor());
        }

        // 2. *************ADD NEWDoctor ******************
        // GET:Doctor/Create
        public ActionResult Create()
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-VLRKFE1\\SQLEXPRESS;Integrated Security=True;database=project;");

            // writing sql query  
            SqlCommand cm = new SqlCommand("pdropdownRollName", con);
            // Opening Connection  
            con.Open();
            // Executing the SQL query  
            SqlDataReader sdr = cm.ExecuteReader();
            // Iterating Data
            List<string> record;
            List<List<string>> data = new List<List<string>> { };

            while (sdr.Read())
            {
                record = new List<string> { sdr["RoleName"].ToString() }; data.Add(record);
            }
            ViewBag.Data = data;
            return View();
        }

        // POST:Doctor/Create
        [HttpPost]
        [ActionName("formsubmit")]
        public ActionResult Create(DoctorClass smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   DoctorMasterDbHandle sdb = new DoctorMasterDbHandle();
                    if (sdb.AddDoctor(smodel))
                    {
                        ViewBag.Message = "Doctor Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
                return View();
            }
        }

        // 3. ************* EDITDoctor DETAILS ******************
        // GET:Doctor/Edit/5
        public ActionResult Edit(int id)
        {
           DoctorMasterDbHandle sdb = new DoctorMasterDbHandle();
            return View(sdb.GetDoctor().Find(smodel => smodel.DoctorId == id));
        }

        // POST:Doctor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,DoctorClass smodel)
        {
            try
            {
               DoctorMasterDbHandle sdb = new DoctorMasterDbHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("DoctorList");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }

        // 4. ************* DELETEDoctor DETAILS ******************
        // GET:Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
               DoctorMasterDbHandle sdb = new DoctorMasterDbHandle();
                if (sdb.DeleteDoctor(id))
                {
                    ViewBag.AlertMsg = "S Deleted Successfully";
                }
                return RedirectToAction("DoctorList");
            }
            catch
            {
                return View();
            }
        }
    }
}