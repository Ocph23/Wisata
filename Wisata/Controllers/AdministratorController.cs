using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisata.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult Index()
        {
            if (Request.IsAuthenticated && new Users(User.Identity.Name).IsAdmin)
            {
                return View();
            }else
            {
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            }
        }
    }
}