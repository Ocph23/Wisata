using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisata.Controllers
{
    public class galeryController : Controller
    {
        //
        // GET: /galery/
        public ActionResult Index()
        {
            using (var db = new OcphDbContext())
            {
                var result = db.galeries.Select().ToList();
                return View(result);
            }


        }

        //
        // GET: /Galery/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.galeries.Where(O => O.GaleryID == id).FirstOrDefault();
                return View(result);
            }

        }

        //
        // GET: /Galery/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Transportasi/Create
        [HttpPost]
        public ActionResult Create(DataAccess.Models.Galery model)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var res = db.galeries.Insert(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Galery/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.galeries.Where(O => O.GaleryID == id).FirstOrDefault();
                return View(result);
            }

        }

        //
        // POST: /Galery/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DataAccess.Models.Galery model)
        {
            try
            {
                // TODO: Add update logic here
                using (var db = new OcphDbContext())
                {
                    db.galeries.Update(O => new { O.GaleryID,O.ObjectID,O.Foto,O.Deskripsi }, model, O => O.GaleryID == id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Galery/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.galeries.Where(O => O.GaleryID == id).FirstOrDefault();
                return View(result);
            }
        }

        //
        // POST: /Galery/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (var db = new OcphDbContext())
                {
                    db.galeries.Delete(O => O.GaleryID == id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
