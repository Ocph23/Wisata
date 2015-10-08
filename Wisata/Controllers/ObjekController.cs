using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisata.Controllers
{
    public class ObjekController : Controller
    {
        //
        // GET: /Objek/
        public ActionResult Index()
        {
            using (var db = new OcphDbContext())
            {
                var result = this.GetModel();
                return View(result);
            }


        }

        //
        // GET: /Objek/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = this.GetModel().Where(O => O.ObjekID == id).FirstOrDefault();
                return View(result);
            }

        }

        //
        // GET: /Objek/Create
        public ActionResult Create()
        {
            ViewBag.Kecamatans = this.GetKecamatans();
            return View();
        }

        //
        // POST: /Objek/Create
        [HttpPost]
        public ActionResult Create(DataAccess.Models.objek model)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var res = db.objeks.Insert(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Objek/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = this.GetModel().Where(O => O.ObjekID == id).FirstOrDefault();
                ViewBag.Kecamatans = this.GetKecamatans();
                return View(result);
            }

        }

        //
        // POST: /Objek/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DataAccess.Models.objek model)
        {
            try
            {
                // TODO: Add update logic here
                using (var db = new OcphDbContext())
                {
                    db.objeks.Update(O => new { O.ObjekID,O.KecamatanID,O.Nama_Objek,O.Lintang,O.Jenis }, model, O => O.ObjekID == id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Objek/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = this.GetModel().Where(O => O.ObjekID == id).FirstOrDefault();
                ViewBag.Kecamatans = this.GetKecamatans();
                return View(result);
            }
        }

        //
        // POST: /Objek/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (var db = new OcphDbContext())
                {
                    db.objeks.Delete(O => O.ObjekID == id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public object GetKecamatans()
        {
            using (var db = new OcphDbContext())
            {
                var result = db.kecamatans.Select().ToList();
                return result;
            }
        }

        private List<DataAccess.Models.objek> GetModel()
        {
            using (var db = new OcphDbContext())
            {

                var result = from h in db.objeks.Select().AsEnumerable()
                             join k in db.kecamatans.Select().AsEnumerable() on h.KecamatanID equals k.Id_Kecamatan
                             select new DataAccess.Models.objek
                             {
                                 KecamatanID = h.KecamatanID,  KecamatanName= k.Nama_Kecamatan,
                                Bujur =h.Bujur, Jenis=h.Jenis, Lintang = h.Lintang, Nama_Objek=h.Nama_Objek,ObjekID=h.ObjekID
                             };
                return result.ToList();
            }
        }
    }
}
