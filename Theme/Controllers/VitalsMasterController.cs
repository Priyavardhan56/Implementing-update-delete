using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Theme.Models;


namespace Theme.Controllers
{
    public class VitalsMasterController : Controller
    {// 1. *************RETRIEVE ALL Vitals DETAILS ******************
        // GET: Vitals
        public ActionResult VitalsList()
        {
            VitalsMasterDbHandle dbhandle = new VitalsMasterDbHandle();
            ModelState.Clear();
            return View(dbhandle.GetVitals());
        }

        // 2. *************ADD NEW Vitals ******************
        // GET: Vitals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vitals/Create
        [HttpPost]
        public ActionResult Create(Vitals smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    VitalsMasterDbHandle sdb = new VitalsMasterDbHandle();
                    if (sdb.AddVitals(smodel))
                    {
                        ViewBag.Message = "Vitals Details Added Successfully";
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

        // 3. ************* EDIT Vitals DETAILS ******************
        // GET: Vitals/Edit/5
        public ActionResult Edit(int id)
        {
            VitalsMasterDbHandle sdb = new VitalsMasterDbHandle();
            return View(sdb.GetVitals().Find(smodel => smodel.Id == id));
        }

        // POST: Vitals/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Vitals smodel)
        {
            try
            {
                VitalsMasterDbHandle sdb = new VitalsMasterDbHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("VitalsList");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }

        // 4. ************* DELETE Vitals DETAILS ******************
        // GET: Vitals/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                VitalsMasterDbHandle sdb = new VitalsMasterDbHandle();
                if (sdb.DeleteVitals(id))
                {
                    ViewBag.AlertMsg = "S Deleted Successfully";
                }
                return RedirectToAction("VitalsList");
            }
            catch
            {
                return View();
            }
        }
    }
}