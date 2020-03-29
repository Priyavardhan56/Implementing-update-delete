using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Theme.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult PatientDashboard()
        {
            return View();
        }
        public ActionResult PatientAppointmentList()
        {
            return View();
        }
        public ActionResult PatientOpdHistory()
        {
            return View();
        }
        public ActionResult PatientSettings()
        {
            return View();
        }
        public ActionResult PatientProfile()
        {
            return View();
        }
    }
}