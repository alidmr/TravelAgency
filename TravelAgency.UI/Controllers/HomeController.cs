using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.BusinessLayer;

namespace TravelAgency.UI.Controllers
{
    public class HomeController : Controller
    {
        CategoryHelper cat = new CategoryHelper();
        ContentHelper con = new ContentHelper();
        // GET: Home
        public ActionResult Index()
        {
            var category = cat.GetCategoryContentList();
            //var content = con.GetContentList();
            return View(category);
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Mission_Vision()
        {
            return View();
        }
        public ActionResult Detail(int? id)
        {
            if (id != null)
            {
                var contentDetail = con.GetContentsDetailById(id.Value);
                if (contentDetail != null)
                {
                    return View(contentDetail);
                }
            }
            return View();
        }
    }
}