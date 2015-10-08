using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wisata.DataAccess.Models;

namespace Wisata.Controllers
{
    public class KulinerController : Controller
    {
        //
        // GET: /Kuliner/
        public ActionResult Index()
        {
            using (var db = new OcphDbContext())
            {
                var result = from kul in db.kuliners.Select()
                             join kec in db.kecamatans.Select() on kul.KecamatanID equals kec.Id_Kecamatan
                             select new kuliner{ KecamatanID=kul.KecamatanID, Telpon=kul.Telpon, Pemilik=kul.Pemilik, Nama_Tempat_Kuliner =kul.Nama_Tempat_Kuliner, KulinerID=kul.KulinerID, KecamatanName=kec.Nama_Kecamatan};
                return View(result);
            }


        }

        //
        // GET: /Kuliner/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new OcphDbContext())
            {
                var r = from kul in db.kuliners.Select()
                             join kec in db.kecamatans.Select() on kul.KecamatanID equals kec.Id_Kecamatan
                             select new kuliner { KecamatanID = kul.KecamatanID, Telpon = kul.Telpon, Pemilik = kul.Pemilik, Nama_Tempat_Kuliner = kul.Nama_Tempat_Kuliner, KulinerID = kul.KulinerID, KecamatanName = kec.Nama_Kecamatan };

                var result = r.Where(O => O.KulinerID == id).FirstOrDefault();
                return View(result);
            }

        }

        //
        // GET: /Kuliner/Create
        public ActionResult Create()
        {
            using (var db = new OcphDbContext())
            {
                var result = db.kecamatans.Select().ToList();
                ViewBag.Kecamatans = result;
            }
            return View();
        }

        //
        // POST: /Kuliner/Create
        [HttpPost]
        public ActionResult Create(DataAccess.Models.kuliner model)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var res = db.kuliners.Insert(model);
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        //
        // GET: /Kuliner/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.kuliners.Where(O => O.KulinerID == id).FirstOrDefault();
                ViewBag.Kecamatans = db.kecamatans.Select().ToList();
                return View(result);
            }

        }

        //
        // POST: /Kuliner/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DataAccess.Models.kuliner model)
        {
            try
            {
                // TODO: Add update logic here
                using (var db = new OcphDbContext())
                {
                    db.kuliners.Update(O => new { O.KulinerID,O.Nama_Tempat_Kuliner,O.KecamatanID,O.Pemilik,O.Telpon }, model, O => O.KulinerID == id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Kuliner/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.kuliners.Where(O => O.KulinerID == id).FirstOrDefault();
                return View(result);
            }
        }

        //
        // POST: /Kuliner/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (var db = new OcphDbContext())
                {
                    db.kuliners.Delete(O => O.KulinerID == id);
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
