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
            if(Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.kecamatans.Select().ToList();
                    return View(result);
                }

            }else
            {
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
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
            if (Request.IsAuthenticated)
            {
                return View();
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        //
        // POST: /Fasilitas/Create
        [HttpPost]
        public ActionResult Create(DataAccess.Models.kecamatan model)
        {
            if (Request.IsAuthenticated)
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
            else
            {
                return RedirectToAction("NoHaveAccess", "ErrorHanler");
            
            }
        }

        //
        // GET: /Fasilitas/Edit/5
        public ActionResult Edit(int id)
        {
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.kecamatans.Where(O => O.Id_Kecamatan == id).FirstOrDefault();
                    return View(result);
                }
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");

        }

        //
        // POST: /Fasilitas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DataAccess.Models.kecamatan model)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    // TODO: Add update logic here
                    using (var db = new OcphDbContext())
                    {
                        db.kecamatans.Update(O => new { O.Nama_Kecamatan }, model, O => O.Id_Kecamatan == id);
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
        // GET: /Fasilitas/Delete/5
        public ActionResult Delete(int id)
        {
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.kecamatans.Where(O => O.Id_Kecamatan == id).FirstOrDefault();
                    return View(result);
                }
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        //
        // POST: /Fasilitas/Delete/5
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
                        db.kecamatans.Delete(O => O.Id_Kecamatan == id);
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
