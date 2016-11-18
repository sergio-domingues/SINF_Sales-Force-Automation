using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmaCRM.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
