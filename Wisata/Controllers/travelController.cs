using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisata.Controllers
{
    public class travelController : Controller
    {

        public List<DataAccess.Models.travel> GetViewModel()
        {
            using (var db = new OcphDbContext())
            {
                var result = from t in db.travels.Select()
                             join k in db.kecamatans.Select() on t.KecamatanID equals k.Id_Kecamatan
                             select new DataAccess.Models.travel
                             {
                                 Email = t.Email,
                                 KecamatanID = t.KecamatanID,
                                 KecamatanName = k.Nama_Kecamatan,
                                 Nama_Direktur = t.Nama_Direktur,
                                 Nama_Travel = t.Nama_Travel,
                                 Nomor_Telepon = t.Nomor_Telepon,
                                 TravelID = t.TravelID,
                                 Website = t.Website
                             };
                return result.ToList();
            }
        }

        public DataAccess.Models.travel GetModel(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = from t in db.travels.Where(O=>O.TravelID==id)
                             join k in db.kecamatans.Select() on t.KecamatanID equals k.Id_Kecamatan
                             
                             select new DataAccess.Models.travel
                             {
                                 Email = t.Email,
                                 KecamatanID = t.KecamatanID,
                                 KecamatanName = k.Nama_Kecamatan,
                                 Nama_Direktur = t.Nama_Direktur,
                                 Nama_Travel = t.Nama_Travel,
                                 Nomor_Telepon = t.Nomor_Telepon,
                                 TravelID = t.TravelID,
                                 Website = t.Website
                             };
                return result.FirstOrDefault();
            }
        }

        public List<DataAccess.Models.kecamatan> GetKecamatans()
        {
            using (var db = new OcphDbContext())
            {
                return db.kecamatans.Select().ToList();
            }
        
        
        }

        //
        // GET: /travel/
        public ActionResult Index()
        {
            using (var db = new OcphDbContext())
            {
                var result = this.GetViewModel();
                return View(result);
            }


        }

        //
        // GET: /Travel/Details/5
        public ActionResult Details(int id)
        {
            var result = this.GetModel(id);
            ViewBag.Kecamatans = this.GetKecamatans();
            return View(result);
        }

        //
        // GET: /Travel/Create
        public ActionResult Create()
        {
            ViewBag.Kecamatans = this.GetKecamatans();
            return View();
        }

        //
        // POST: /Fasilitas/Create
        [HttpPost]
        public ActionResult Create(DataAccess.Models.travel model)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var res = db.travels.Insert(model);
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
            var result = this.GetModel(id);
            ViewBag.Kecamatans = this.GetKecamatans();
            return View(result);

        }

        //
        // POST: /Travel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DataAccess.Models.travel model)
        {
            try
            {
                // TODO: Add update logic here
                using (var db = new OcphDbContext())
                {
                    db.travels.Update(O => new { TravelD = O.TravelID,O.Nama_Travel,O.Nomor_Telepon,O.KecamatanID,O.Nama_Direktur,O.Website }, model, O => O.TravelID  == id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Travel/Delete/5
        public ActionResult Delete(int id)
        {
            var result = this.GetModel(id);
            return View(result);
        }

        //
        // POST: /Travel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (var db = new OcphDbContext())
                {
                    db.travels.Delete(O => O.TravelID == id);
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
