using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisata.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            using (var db = new OcphDbContext())
            {
                var objs = db.objeks.Select().ToList();
                List<Models.ObjectWisataView> view = new List<Models.ObjectWisataView>();
                foreach (var item in objs)
                {
                    var a = new Models.ObjectWisataView(item);
                    view.Add(a);
                }

                return View(view);
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}