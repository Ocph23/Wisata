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
                                 Website = t.Website,
                                 Lintang=t.Lintang,
                                 Bujur=t.Bujur
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
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = this.GetViewModel();
                    return View(result);
                }

            }
            else
            {
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            }


        }

        //
        // GET: /Travel/Details/5
        public ActionResult Details(int id)
        {
            if (Request.IsAuthenticated)
            {
                var result = this.GetModel(id);
                ViewBag.Kecamatans = this.GetKecamatans();
                return View(result);
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");

        }

        //
        // GET: /Travel/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.Kecamatans = this.GetKecamatans();
                return View();
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        //
        // POST: /Fasilitas/Create
        [HttpPost]
        public ActionResult Create(DataAccess.Models.travel model)
        {
            if (Request.IsAuthenticated)
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
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        //
        // GET: /Transportasi/Edit/5
        public ActionResult Edit(int id)
        {
            if (Request.IsAuthenticated)
            {
                var result = this.GetModel(id);
                ViewBag.Kecamatans = this.GetKecamatans();
                return View(result);
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        //
        // POST: /Travel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DataAccess.Models.travel model)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    // TODO: Add update logic here
                    using (var db = new OcphDbContext())
                    {
                        db.travels.Update(O => new {O.Bujur,O.Lintang, TravelD = O.TravelID, O.Nama_Travel, O.Nomor_Telepon, O.KecamatanID, O.Nama_Direktur, O.Website }, model, O => O.TravelID == id);
                    }
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        //
        // GET: /Travel/Delete/5
        public ActionResult Delete(int id)
        {
            if (Request.IsAuthenticated)
            {
                var result = this.GetModel(id);
                return View(result);
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        //
        // POST: /Travel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (Request.IsAuthenticated)
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
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }
    }
}
