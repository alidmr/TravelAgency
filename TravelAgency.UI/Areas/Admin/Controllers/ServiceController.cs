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
    public class ServiceController : Controller
    {
        ServiceHelper sh = new ServiceHelper();
        // GET: Admin/Service
        public ActionResult Index()
        {
            var service = sh.GetServicesList();
            return View(service);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Service serviceModel)
        {
            if (ModelState.IsValid)
            {
                int result = 0;
                result = sh.AddService(serviceModel);
                if (result > 0)
                {
                    return RedirectToAction("index", "service", new { area = "admin" });
                }
            }
            return View();
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var service = sh.GetServiceById(id.Value);
            if (service != null)
            {
                return View(service);
            }
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Service model)
        {
            if (ModelState.IsValid)
            {
                int result = 0;
                result = sh.UpdateService(model);
                if (result > 0)
                {
                    return RedirectToAction("index", "service", new { area = "admin" });
                }
            }
            return View();
        }
        public JsonResult Delete(int? id)
        {
            int result = 0;
            if (id != null)
            {
                result = sh.DeleteService(id.Value);
                if (result > 0)
                {
                    return Json(new { result }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}