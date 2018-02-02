using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisata.Controllers
{
    public class ErrorHanlerController : Controller
    {
        // GET: ErrorHanler
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotHaveAccess()
        {
            return View();
        }
    }
}