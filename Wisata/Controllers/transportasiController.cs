using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisata.Controllers
{
    public class transportasiController : Controller
    {
        //
        // GET: /transportasi/
        public ActionResult Index()
        {
            using (var db = new OcphDbContext())
            {
                var result = db.transportasis.Select().ToList();
                return View(result);
            }


        }

        //
        // GET: /Transportasi/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.transportasis.Where(O => O.TransportasiID == id).FirstOrDefault();
                return View(result);
            }

        }

        //
        // GET: /Transportasi/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Transportasi/Create
        [HttpPost]
        public ActionResult Create(DataAccess.Models.transportasi model)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var res = db.transportasis.Insert(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Transportasi/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.transportasis.Where(O => O.TransportasiID == id).FirstOrDefault();
                return View(result);
            }

        }

        //
        // POST: /Transportasi/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DataAccess.Models.transportasi model)
        {
            try
            {
                // TODO: Add update logic here
                using (var db = new OcphDbContext())
                {
                    db.transportasis.Update(O => new { O.TransportasiID,O.Objek,O.Kategori }, model, O => O.TransportasiID == id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Transportasi/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.transportasis.Where(O => O.TransportasiID == id).FirstOrDefault();
                return View(result);
            }
        }

        //
        // POST: /Transportasi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (var db = new OcphDbContext())
                {
                    db.transportasis.Delete(O => O.TransportasiID == id);
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
