using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisata.Controllers
{
    public class BelanjaController : Controller
    {

        public DataAccess.Models.tempat_belanja GetModel(int id)
        {
            
            using (var db = new OcphDbContext())
            {
                var result = from b in db.tempat_belanjas.Where(O=>O.Id_tempat_belanja==id)
                             join k in db.kecamatans.Select() on b.KecamatanID equals k.Id_Kecamatan
                             select new DataAccess.Models.tempat_belanja
                             {
                                 KecamatanID = b.KecamatanID,
                                 Id_tempat_belanja = b.Id_tempat_belanja,
                                 Alamat = b.Alamat,
                                 KecamatanName = k.Nama_Kecamatan,
                                 Nama_Tempat_Belanja = b.Nama_Tempat_Belanja,Lintang=b.Lintang, Bujur=b.Bujur
                             };
                return result.FirstOrDefault();
            }
        }


        public List<DataAccess.Models.tempat_belanja> GetViewModel()
        { 
            using(var db = new OcphDbContext())
            {
                var result = from b in db.tempat_belanjas.Select()
                             join k in db.kecamatans.Select() on b.KecamatanID equals k.Id_Kecamatan
                             select new DataAccess.Models.tempat_belanja { KecamatanID=b.KecamatanID, Id_tempat_belanja=b.Id_tempat_belanja,
                              Alamat=b.Alamat, KecamatanName=k.Nama_Kecamatan, Nama_Tempat_Belanja=b.Nama_Tempat_Belanja};
                return result.ToList();
            }
        }


        public List<DataAccess.Models.kecamatan> GetKecamatans()
        {
            using(var db = new OcphDbContext())
            {
                return db.kecamatans.Select().ToList();
            }
        
        }

        // GET: Belanja
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                var result = this.GetViewModel();
                return View(result);
     
            }else
            {
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            }
        }

        // GET: Belanja/Details/5
        public ActionResult Details(int id)
        {
            if (Request.IsAuthenticated)
            {
                var result = this.GetModel(id);
                this.ViewBag.Kecamatans = this.GetKecamatans();
                return View(result);
            }
            else
            {
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            }
        }

        // GET: Belanja/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                this.ViewBag.Kecamatans = this.GetKecamatans();
                return View();
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");

        }

        // POST: Belanja/Create
        [HttpPost]
        public ActionResult Create(DataAccess.Models.tempat_belanja model)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    using (var db = new OcphDbContext())
                    {
                        var Issaved = db.tempat_belanjas.Insert(model);

                    }

                    return RedirectToAction("Index");
                }
                catch
                {
                    this.ViewBag.Kecamatans = this.GetKecamatans();
                    return View();
                }
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        // GET: Belanja/Edit/5
        public ActionResult Edit(int id)
        {
            if (Request.IsAuthenticated)
            {
                this.ViewBag.Kecamatans = this.GetKecamatans();
                var result = this.GetModel(id);
                return View(result);
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            
        }

        // POST: Belanja/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DataAccess.Models.tempat_belanja model)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    using (var db = new OcphDbContext())
                    {
                        var result = db.tempat_belanjas.Update(O => new { O.KecamatanID, O.Lintang,O.Bujur, O.Nama_Tempat_Belanja, O.Alamat }, model, O => O.Id_tempat_belanja == id);
                    }

                    return RedirectToAction("Index");
                }
                catch
                {
                    this.ViewBag.Kecamatans = this.GetKecamatans();
                    return View();
                }
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        // GET: Belanja/Delete/5
        public ActionResult Delete(int id)
        {
            if (Request.IsAuthenticated)
            {
                this.ViewBag.Kecamatans = this.GetKecamatans();
                var result = this.GetModel(id);
                return View(result);
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            
        }

        // POST: Belanja/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    using (var db = new OcphDbContext())
                    {
                        var res = db.tempat_belanjas.Delete(O => O.Id_tempat_belanja == id);
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
