using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.BusinessLayer;
using TravelAgency.Entities;
using TravelAgency.UI.Models;

namespace TravelAgency.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            if (CurrentSession.User != null)
            {
                return RedirectToAction("index", "dashboard", new { area = "admin" });
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = new UserHelper().Login(loginModel);
                if (user != null)
                {
                    CurrentSession.Set<User>("login", user);
                    return RedirectToAction("index", "dashboard", new { area = "admin" });
                }
                else
                {
                    ViewBag.ErrorMessage = true;
                    ModelState.AddModelError("", "Email veya şifre hatalı!");
                }
            }
            else
            {
                ViewBag.ErrorMessage = true;
            }
            return View(loginModel);
        }
        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index","Home");
        }
    }
}