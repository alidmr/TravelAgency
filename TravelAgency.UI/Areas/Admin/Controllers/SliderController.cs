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
    public class SliderController : Controller
    {
        SliderHelper sliderHelper = new SliderHelper();
        // GET: Admin/Slider
        public ActionResult Index()
        {
            var slider = sliderHelper.GetSliderList();
            return View(slider);
        }
        public JsonResult Delete(int? id)
        {
            int result = 0;
            if (id != null)
            {
                result = sliderHelper.DeleteSlider(id.Value);
                if (result > 0)
                {
                    return Json(new { result }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Slider model)
        {
            if (ModelState.IsValid)
            {
                int result = 0;
                result = sliderHelper.AddSlider(model);
                if (result > 0)
                {
                    return RedirectToAction("index", "slider", new { area = "admin" });
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
            var slider = sliderHelper.GetSliderById(id.Value);
            if (slider != null)
            {
                return View(slider);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Slider model)
        {
            if (ModelState.IsValid)
            {
                int result = 0;
                result = sliderHelper.UpdateSlider(model);
                if (result > 0)
                {
                    return RedirectToAction("index", "slider", new { area = "admin" });
                }
            }
            return View();
        }
    }
}