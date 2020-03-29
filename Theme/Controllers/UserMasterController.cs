using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

using Theme.Models;

namespace Theme.Controllers
{
    public class UserMasterController : Controller
    { // GET: User
        public ActionResult UserList()
        {
            UserMasterDbHandle dbhandle = new UserMasterDbHandle();
            ModelState.Clear();
            return View(dbhandle.GetUser());
        }

        // 2. *************ADD NEW User ******************
        // GET: User/Create
      
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
  

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserMasterDbHandle sdb = new UserMasterDbHandle();
                    if (sdb.AddUser(smodel))
                    {
                        ViewBag.Message = "User Details Added Successfully";
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

        // 3. ************* EDIT User DETAILS ******************
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            UserMasterDbHandle sdb = new UserMasterDbHandle();
            return View(sdb.GetUser().Find(smodel => smodel.UserId == id));
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User smodel)
        {
            try
            {
                UserMasterDbHandle sdb = new UserMasterDbHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("UserList");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }

        // 4. ************* DELETE User DETAILS ******************
        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                UserMasterDbHandle sdb = new UserMasterDbHandle();
                if (sdb.DeleteUser(id))
                {
                    ViewBag.AlertMsg = "S Deleted Successfully";
                }
                return RedirectToAction("UserList");
            }
            catch
            {
                return View();
            }
        }
    }
}