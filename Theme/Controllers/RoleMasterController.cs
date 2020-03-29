using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Theme.Models;

namespace Theme.Controllers
{
    public class RoleMasterController : Controller
    {


        // 1. *************RETRIEVE ALL Role DETAILS ******************
        // GET: Role
        public ActionResult RoleList()
        {
            RoleMasterDbHandle dbhandle = new RoleMasterDbHandle();
            ModelState.Clear();
            return View(dbhandle.GetRole());
        }

        // 2. *************ADD NEW Role ******************
        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(Role smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RoleMasterDbHandle sdb = new RoleMasterDbHandle();
                    if (sdb.AddRole(smodel))
                    {
                        ViewBag.Message = "Role Details Added Successfully";
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

        // 3. ************* EDIT Role DETAILS ******************
        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            RoleMasterDbHandle sdb = new RoleMasterDbHandle();
            return View(sdb.GetRole().Find(smodel => smodel.RoleId == id));
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Role smodel)
        {
            try
            {
                RoleMasterDbHandle sdb = new RoleMasterDbHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("RoleList");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }

        // 4. ************* DELETE Role DETAILS ******************
        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                RoleMasterDbHandle sdb = new RoleMasterDbHandle();
                if (sdb.DeleteRole(id))
                {
                    ViewBag.AlertMsg = "S Deleted Successfully";
                }
                return RedirectToAction("RoleList");
            }
            catch
            {
                return View();
            }
        }
    }
}