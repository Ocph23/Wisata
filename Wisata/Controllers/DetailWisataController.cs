using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisata.Controllers
{
    public class DetailWisataController : Controller
    {
        //
        // GET: /DetailWisata/
        public ActionResult Index(int id)
        {
            var result = new Models.ObjectWisataView(id);

            return View(result);
        }
	}
}