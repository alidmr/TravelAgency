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
    public class CategoryController : Controller
    {
        CategoryHelper cat = new CategoryHelper();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var categoryList = cat.GetCategoryList();
            return View(categoryList);
        }
        public JsonResult Delete(int? id)
        {
            int result = 0;
            if (id != null)
            {
                result = cat.DeleteCategory(id.Value);
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
        public ActionResult Create(Category categoryModel)
        {
            if (ModelState.IsValid)
            {
                int result = 0;
                result = cat.AddCategory(categoryModel);
                if (result > 0)
                {
                    return RedirectToAction("index", "category", new { area = "admin" });
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

            var category_ = cat.GetCategoryById(id.Value);
            if (category_ != null)
            {
                return View(category_);
            }

            return View();
        }
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                int result = 0;
                result = cat.UpdateCategory(model);
                if (result > 0)
                {
                    return RedirectToAction("index", "category", new { area = "admin" });
                }
            }
            return View();
        }
    }
}