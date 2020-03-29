using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Theme.Models;


namespace Theme.Controllers
{
    public class AppointmentMasterController : Controller
    {// 1. *************RETRIEVE ALL Appointment DETAILS ******************
        // GET: Appointment
        public ActionResult AppointmentList()
        {
            AppointmentMasterDbHandle dbhandle = new AppointmentMasterDbHandle();
            ModelState.Clear();
            return View(dbhandle.GetAppointment());
        }

        // 2. *************ADD NEW Appointment ******************
        // GET: Appointment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        public ActionResult Create(Appointment smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AppointmentMasterDbHandle sdb = new AppointmentMasterDbHandle();
                    if (sdb.AddAppointment(smodel))
                    {
                        ViewBag.Message = "Appointment Details Added Successfully";
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

        // 3. ************* EDIT Appointment DETAILS ******************
        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            AppointmentMasterDbHandle sdb = new AppointmentMasterDbHandle();
            return View(sdb.GetAppointment().Find(smodel => smodel.AppointmentId == id));
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Appointment smodel)
        {
            try
            {
                AppointmentMasterDbHandle sdb = new AppointmentMasterDbHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("AppointmentList");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }

        // 4. ************* DELETE Appointment DETAILS ******************
        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                AppointmentMasterDbHandle sdb = new AppointmentMasterDbHandle();
                if (sdb.DeleteAppointment(id))
                {
                    ViewBag.AlertMsg = "S Deleted Successfully";
                }
                return RedirectToAction("AppointmentList");
            }
            catch
            {
                return View();
            }
        }
    }
}