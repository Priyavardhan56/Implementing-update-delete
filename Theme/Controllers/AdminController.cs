using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Theme.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminDashboard()
        {
            return View();
        }
        public ActionResult AddHospital()
        {
            return View();
        }
        public ActionResult AddRoles()
        {
            return View();
        }
        public ActionResult Chat()
        {
            return View();
        }
        public ActionResult Feedback()
        {
            return View();

        }
        public ActionResult HospitalProfile()
        {
            return View();
        }
        public ActionResult Hospitals()
        {
            return View();
        }
        public ActionResult HospitalSpecilization()
        {
            return View();
        }
        public ActionResult Settings()
        {
            return View();
        }
        public ActionResult Users()
        {
            return View();
        }
      

    }
}