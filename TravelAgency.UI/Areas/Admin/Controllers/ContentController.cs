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
    public class ContentController : Controller
    {
        ContentHelper ch = new ContentHelper();
        // GET: Admin/Content
        public ActionResult Index()
        {
            var content = ch.GetContentList();
            return View(content);
        }
        public ActionResult Create()
        {
            ViewBag.Category = new SelectList(new CategoryHelper().GetCategoryList(), "Id", "Name");
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(ContentViewModel model)
        {
            if (ModelState.IsValid)
            {
                int result = 0;
                result = ch.AddContent(model);
                if (result > 0)
                {
                    return RedirectToAction("index", "content", new { area = "admin" });
                }
            }
            ViewBag.Category = new SelectList(new CategoryHelper().GetCategoryList(), "Id", "Name");
            return View();
        }
        public JsonResult CreateData(ContentViewModel model, HttpPostedFileBase image)
        {
            int sonuc = 0;
            if (ModelState.IsValid)
            {
                sonuc = ch.AddContent(model);
            }
            return Json(sonuc, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int? id)
        {
            int result = 0;
            if (id != null)
            {
                result = ch.DeleteContent(id.Value);
            }
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var content = ch.GetContentsById(id.Value);

            if (content != null)
            {
                ViewBag.Category_Id = new SelectList(new CategoryHelper().GetCategoryList(), "Id", "Name", content.Category_Id);
                return View(content);
            }

            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(Content model)
        {
            if (ModelState.IsValid)
            {
                int result = 0;
                result = ch.UpdateContent(model);
                if (result > 0)
                {
                    return RedirectToAction("index", "content", new { area = "admin" });
                }
            }
            ViewBag.Category_Id = new SelectList(new CategoryHelper().GetCategoryList(), "Id", "Name", model.Category_Id);
            return View();
        }
        public JsonResult StatusContent(int? id)
        {
            int result = 0;
            if (id != null)
            {
                result = ch.UpdateStatus(id.Value);
                if (result > 0)
                {
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RemoveImage(int? id)
        {
            bool result = false;
            if (id != null)
            {
                result = ch.DeleteContentImage(id.Value);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ImageDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var image = ch.GetImageById(id.Value);
            if (image != null)
            {
                return PartialView("_PartialUpdateContentImage", image);
            }

            return RedirectToAction("index", "content", new { area = "admin" });
        }
        [HttpPost]
        public ActionResult UpdateImage(ContentImage model, HttpPostedFileBase fuImage)
        {
            if (ModelState.IsValid)
            {
                int result = 0;
                result = ch.UpdateContentImage(model, fuImage);
                if (result > 0)
                {
                    return RedirectToAction("index", "content", new { area = "admin" });
                }
            }
            return PartialView("_PartialUpdateContentImage");
        }

    }
}