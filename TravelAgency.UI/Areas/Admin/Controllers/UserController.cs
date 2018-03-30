using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelAgency.BusinessLayer;
using TravelAgency.UI.Helpers;

namespace TravelAgency.UI.Areas.Admin.Controllers
{
    [Authentication]
    public class UserController : Controller
    {
        UserHelper uh = new UserHelper();
        // GET: Admin/User
        public ActionResult Index()
        {
            var user = uh.GetUserList();
            return View(user);
        }
        public ActionResult Create()
        {
            ViewBag.Role_Id = new SelectList(new RoleHelper().GetRoleList(), "Id", "Role_Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(User userModel)
        {
            if (ModelState.IsValid)
            {
                int result = 0;
                result = uh.AddUser(userModel);
                if (result > 0)
                {
                    return RedirectToAction("index", "user", new { area = "admin" });
                }
            }
            return View();
        }
        public JsonResult Delete(int id)
        {
            int result = 0;
            result = uh.DeleteUser(id);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = uh.GetUserById(id.Value);
            ViewBag.Role_Id = new SelectList(new RoleHelper().GetRoleList(), "Id", "Role_Name", user.Role_Id);
            if (user != null)
            {
                return View(user);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(User userModel)
        {
            if (ModelState.IsValid)
            {
                int result = 0;
                result = uh.UpdateUser(userModel);
                if (result > 0)
                {
                    return RedirectToAction("index", "user", new { area = "admin" });
                }
            }
            ViewBag.Role_Id = new SelectList(new RoleHelper().GetRoleList(), "Id", "Role_Name");
            return View();
        }
    }
}