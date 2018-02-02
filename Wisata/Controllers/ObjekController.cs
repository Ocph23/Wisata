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
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = this.GetModel();
                    return View(result);
                }

            }else
            {
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            }
           

        }

        //
        // GET: /Objek/Details/5
        public ActionResult Details(int id)
        {
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = this.GetModel().Where(O => O.ObjekID == id).FirstOrDefault();
                    return View(result);
                }
            }
            else
            {
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            }

        }

        //
        // GET: /Objek/Create
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
        // POST: /Objek/Create
        [HttpPost]
        public ActionResult Create(DataAccess.Models.objek model)
        {
            if (Request.IsAuthenticated)
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
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        //
        // GET: /Objek/Edit/5
        public ActionResult Edit(int id)
        {
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = this.GetModel().Where(O => O.ObjekID == id).FirstOrDefault();
                    ViewBag.Kecamatans = this.GetKecamatans();
                    return View(result);
                }
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        //
        // POST: /Objek/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DataAccess.Models.objek model)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    // TODO: Add update logic here
                    using (var db = new OcphDbContext())
                    {
                        db.objeks.Update(O => new { O.ObjekID, O.KecamatanID, O.Nama_Objek, O.Lintang, O.Bujur, O.Jenis, O.Description }, model, O => O.ObjekID == id);
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
        // GET: /Objek/Delete/5
        public ActionResult Delete(int id)
        {
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = this.GetModel().Where(O => O.ObjekID == id).FirstOrDefault();
                    ViewBag.Kecamatans = this.GetKecamatans();
                    return View(result);
                }
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        //
        // POST: /Objek/Delete/5
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
                        db.objeks.Delete(O => O.ObjekID == id);
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
                                 KecamatanID = h.KecamatanID,  KecamatanName= k.Nama_Kecamatan, Description=h.Description,
                                Bujur =h.Bujur, Jenis=h.Jenis, Lintang = h.Lintang, Nama_Objek=h.Nama_Objek,ObjekID=h.ObjekID
                             };
                return result.ToList();
            }
        }
    }
}
