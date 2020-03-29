using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;


using Theme.Models;


namespace Theme.Controllers
{
    
  

    public class StaffMasterController : Controller
    {// 1. *************RETRIEVE ALL Staff DETAILS ******************
     // GET: Staff


         

            public ActionResult StaffList()
        {
            StaffMasterDbHandle dbhandle = new StaffMasterDbHandle();
            ModelState.Clear();
            return View(dbhandle.GetStaff());
        }

        // 2. *************ADD NEW Staff ******************
        // GET: Staff/Create
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
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create(Staff smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StaffMasterDbHandle sdb = new StaffMasterDbHandle();
                    if (sdb.AddStaff(smodel))
                    {
                        ViewBag.Message = "Staff Details Added Successfully";
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

        // 3. ************* EDIT Staff DETAILS ******************
        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            StaffMasterDbHandle sdb = new StaffMasterDbHandle();
            return View(sdb.GetStaff().Find(smodel => smodel.StaffId == id));
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Staff smodel)
        {
            try
            {
                StaffMasterDbHandle sdb = new StaffMasterDbHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("StaffList");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }

        // 4. ************* DELETE Staff DETAILS ******************
        // GET: Staff/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                StaffMasterDbHandle sdb = new StaffMasterDbHandle();
                if (sdb.DeleteStaff(id))
                {
                    ViewBag.AlertMsg = "S Deleted Successfully";
                }
                return RedirectToAction("StaffList");
            }
            catch
            {
                return View();
            }
        }
    }
}