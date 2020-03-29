using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Theme.Models;

namespace Theme.Controllers
{
    public class HospitalMasterController : Controller
    { // 1. *************RETRIEVE ALL Hospital DETAILS ******************
        // GET: Hospital
        public ActionResult HospitalList()
        {
            HospitalMasterDbHandle dbhandle = new HospitalMasterDbHandle();
            ModelState.Clear();
            return View(dbhandle.GetHospital());
        }

        // 2. *************ADD NEW Hospital ******************
        // GET: Hospital/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hospital/Create
        [HttpPost]
        public ActionResult Create(Hospital smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HospitalMasterDbHandle sdb = new HospitalMasterDbHandle();
                    if (sdb.AddHospital(smodel))
                    {
                        ViewBag.Message = "Hospital Details Added Successfully";
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

        // 3. ************* EDIT Hospital DETAILS ******************
        // GET: Hospital/Edit/5
        public ActionResult Edit(int id)
        {
            HospitalMasterDbHandle sdb = new HospitalMasterDbHandle();
            return View(sdb.GetHospital().Find(smodel => smodel.HospitalId == id));
        }

        // POST: Hospital/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Hospital smodel)
        {
            try
            {
                HospitalMasterDbHandle sdb = new HospitalMasterDbHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("HospitalList");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }

        // 4. ************* DELETE Hospital DETAILS ******************
        // GET: Hospital/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                HospitalMasterDbHandle sdb = new HospitalMasterDbHandle();
                if (sdb.DeleteHospital(id))
                {
                    ViewBag.AlertMsg = "S Deleted Successfully";
                }
                return RedirectToAction("HospitalList");
            }
            catch
            {
                return View();
            }
        }
    }
}