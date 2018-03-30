using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelAgency.BusinessLayer;

namespace TravelAgency.UI.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var services = new ServiceHelper().GetServiceById(id.Value);
            if (services != null)
            {
                return View(services);
            }
            return View();
        }
    }
}