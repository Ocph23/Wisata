using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisata.Controllers
{
    public class pengunjungController : Controller
    {
        //
        // GET: /pengunjung/
        public ActionResult Index()
        {
            using (var db = new OcphDbContext())
            {
                var result = db.pengunjungs.Select().ToList();
                return View(result);
            }


        }

        //
        // GET: /Pengunjung/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.pengunjungs.Where(O => O.PengunjungID == id).FirstOrDefault();
                return View(result);
            }

        }

        //
        // GET: /Pengunjung/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pengunjung/Create
        [HttpPost]
        public ActionResult Create(DataAccess.Models. pengunjung model)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var res = db.pengunjungs.Insert(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Pengunjung/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.pengunjungs.Where(O => O.PengunjungID == id).FirstOrDefault();
                return View(result);
            }

        }

        //
        // POST: /Pengunjung/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DataAccess.Models.pengunjung model)
        {
            try
            {
                // TODO: Add update logic here
                using (var db = new OcphDbContext())
                {
                    db.pengunjungs.Update(O => new { O.Email, O.Komentar, O.Nama, O.Tanggal_Jam, O.PengunjungID }, model, O => O.PengunjungID == id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Pengunjung/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.pengunjungs.Where(O => O.PengunjungID == id).FirstOrDefault();
                return View(result);
            }
        }

        //
        // POST: /Pengunjung/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (var db = new OcphDbContext())
                {
                    db.pengunjungs.Delete(O => O.PengunjungID == id);
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
