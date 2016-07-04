using System;
using System.Linq;
using System.Web.Mvc;

namespace PremiseResidentProgram.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Residents()
        {
            return View();
        }

        public ActionResult Administrators()
        {
            return View();
        }
    }
}
