using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wisata.DataAccess.Models;


namespace Wisata.Controllers
{
    public class HotelController : Controller
    {
        //
        // GET: /Hotel/
        public ActionResult Index()
        {
            using (var db = new OcphDbContext())
            {

                var result = GetModel();
                return View(result);
            }


        }

        private List<hotel> GetModel()
        {
            using (var db = new OcphDbContext())
            {

                var result = from h in db.Hotels.Select().AsEnumerable()
                             join k in db.kecamatans.Select().AsEnumerable() on h.KecamatanID equals k.Id_Kecamatan
                             select new hotel
                             {
                                 KecamatanID = k.Id_Kecamatan,
                                 HotelID = h.HotelID,
                                 Email = h.Email,
                                 Harga_Satu_Malam = h.Harga_Satu_Malam,
                                 Jumlah_kamar = h.Jumlah_kamar,
                                 KecamatanName = k.Nama_Kecamatan,
                                 Nama_Direktur = h.Nama_Direktur,
                                 Nama_Hotel = h.Nama_Hotel,
                                 Nomor_Telpon = h.Nomor_Telpon,
                                 Status = h.Status,
                                 Website = h.Website
                             };
                return result.ToList();
            }
        }

        //
        // GET: /Hotel/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new OcphDbContext())
            {
                var collection = this.GetModel();
                var result = collection.Where(O => O.HotelID == id).FirstOrDefault();
                
                return View(result);
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
        //
        // GET: /Hotel/Create
        public ActionResult Create()
        {
            ViewBag.Kecamatans = this.GetKecamatans();
            return View();
        }

        //
        // POST: /Hotel/Create
        [HttpPost]
        public ActionResult Create (hotel model)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var res = db.Hotels.Insert(model);
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        //
        // GET: /Hotel/Edit/5
        public ActionResult Edit(int id)
        {

            var collection = this.GetModel();
            var result = collection.Where(O => O.HotelID == id).FirstOrDefault();
            ViewBag.Kecamatans = this.GetKecamatans();
            
                return View(result);

        }

        //
        // POST: /Hotel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DataAccess.Models.hotel model)
        {
            try
            {
                // TODO: Add update logic here
                using (var db = new OcphDbContext())
                {
                    db.Hotels.Update(O => new { O.Harga_Satu_Malam, O.Jumlah_kamar, O.KecamatanID, O.Nama_Direktur, O.Nama_Hotel, O.Nomor_Telpon, O.Status }, model, O => O.HotelID == id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Hotel/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new OcphDbContext())
            {
                var collection = this.GetModel();
               var result= collection.Where(O => O.HotelID == id).FirstOrDefault();
                return View(result);
            }
        }

        //
        // POST: /Hotel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (var db = new OcphDbContext())
                {
                    db.Hotels.Delete(O => O.HotelID == id);
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
