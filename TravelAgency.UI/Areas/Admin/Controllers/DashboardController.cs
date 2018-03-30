using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.BusinessLayer;
using TravelAgency.UI.Helpers;

namespace TravelAgency.UI.Areas.Admin.Controllers
{
    [Authentication]
    public class DashboardController : Controller
    {
        // GET: Admin/Home

        public ActionResult Index()
        {
            ViewBag.userCount = new UserHelper().GetUsertCount();
            ViewBag.contentCount = new ContentHelper().GetContentCount();
            ViewBag.categoryCount = new CategoryHelper().GetCategoryCount();
            ViewBag.serviceCount = new ServiceHelper().GetServiceCount();
            return View();
        }
    }
}