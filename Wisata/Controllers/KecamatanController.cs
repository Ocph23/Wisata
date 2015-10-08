using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisata.Controllers
{
    public class KecamatanController : Controller
    {
        //
        // GET: /Kecamatan/
        public ActionResult Index()
        {
            using (var db = new OcphDbContext())
            {
                var result = db.kecamatans.Select().ToList();
                return View(result);
            }


        }

        //
        // GET: /Fasilitas/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.kecamatans.Where(O => O.Id_Kecamatan== id).FirstOrDefault();
                return View(result);
            }

        }

        //
        // GET: /Fasilitas/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Fasilitas/Create
        [HttpPost]
        public ActionResult Create(DataAccess.Models.kecamatan model)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var res = db.kecamatans.Insert(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Fasilitas/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.kecamatans.Where(O => O.Id_Kecamatan== id).FirstOrDefault();
                return View(result);
            }

        }

        //
        // POST: /Fasilitas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DataAccess.Models.kecamatan model)
        {
            try
            {
                // TODO: Add update logic here
                using (var db = new OcphDbContext())
                {
                    db.kecamatans.Update(O => new { O.Nama_Kecamatan }, model, O => O.Id_Kecamatan== id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Fasilitas/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.kecamatans.Where(O => O.Id_Kecamatan== id).FirstOrDefault();
                return View(result);
            }
        }

        //
        // POST: /Fasilitas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (var db = new OcphDbContext())
                {
                    db.kecamatans.Delete(O => O.Id_Kecamatan == id);
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
