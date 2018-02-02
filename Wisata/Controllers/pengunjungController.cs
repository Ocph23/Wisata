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
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.pengunjungs.Select().ToList();
                    return View(result);
                }
            }else
            {
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            }
         


        }

        //
        // GET: /Pengunjung/Details/5
        public ActionResult Details(int id)
        {
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.pengunjungs.Where(O => O.PengunjungID == id).FirstOrDefault();
                    return View(result);
                }
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");

        }

        //
        // GET: /Pengunjung/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
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
                        model.Tanggal_Jam = DateTime.Now;
                        var res = db.pengunjungs.Insert(model);
                    }

                    return RedirectToAction("Index","Home");
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
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.pengunjungs.Where(O => O.PengunjungID == id).FirstOrDefault();
                    return View(result);
                }
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");

        }

        //
        // POST: /Pengunjung/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DataAccess.Models.pengunjung model)
        {
            if (Request.IsAuthenticated)
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
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        //
        // GET: /Pengunjung/Delete/5
        public ActionResult Delete(int id)
        {
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.pengunjungs.Where(O => O.PengunjungID == id).FirstOrDefault();
                    return View(result);
                }
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        //
        // POST: /Pengunjung/Delete/5
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
                        db.pengunjungs.Delete(O => O.PengunjungID == id);
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
