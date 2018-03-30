using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelAgency.BusinessLayer;
using TravelAgency.Entities;
using TravelAgency.UI.Helpers;

namespace TravelAgency.UI.Areas.Admin.Controllers
{
    [Authentication]
    public class RoleController : Controller
    {
        RoleHelper roleHelper = new RoleHelper();

        public ActionResult Index()
        {
            var role = roleHelper.GetRoleList();
            return View(role);
        }
        public ActionResult Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                roleModel.CreatedDate = DateTime.Now;
                int result = roleHelper.AddRole(roleModel);
                if (result > 0)
                {
                    return RedirectToAction("index", "role", new { area = "admin" });
                }
            }
            return View(roleModel);
        }
        public JsonResult Delete(int id)
        {
            int result = 0;
            if (id != null)
            {
                result = roleHelper.DeleteRole(id);
            }
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = roleHelper.GetRoleById(id);
            if (role != null)
            {
                return View(role);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Role roleModel)
        {
            if (ModelState.IsValid)
            {
                int result = 0;
                result = roleHelper.UpdateRole(roleModel);
                if (result > 0)
                {
                    return RedirectToAction("index", "role", new { area = "admin" });
                }
            }
            return View();
        }
    }
}