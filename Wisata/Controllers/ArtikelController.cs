using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wisata.DataAccess.Models;
using HtmlAgilityPack;

namespace Wisata.Controllers
{
    public class ArtikelController : Controller
    {
        // GET: Artikel
        public ActionResult Index()
        {
           
            if (Request.IsAuthenticated && new Users(User.Identity.Name).IsAdmin)
            {
                using (var db = new OcphDbContext())
                {
                    var ass = db.Artikels.Select().ToList();
                    var result = from a in db.Artikels.Select()
                                 join o in db.objeks.Select() on a.ObjekID equals o.ObjekID
                                 select new Artikel
                                 {
                                     Author = a.Author,
                                     ObjekID = a.ObjekID,
                                     Content = a.Content,
                                     ObjekName = o.Nama_Objek,
                                     ID = a.ID,
                                     Judul = a.Judul,
                                     Tanggal = a.Tanggal
                                 };
                    return View(result);
                }
            }else
            {
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            }
        }

       

        // GET: Artikel/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = from a in db.Artikels.Where(O=>O.ID==id)
                             join o in db.objeks.Select() on a.ObjekID equals o.ObjekID
                             select new DataAccess.Models.Artikel
                             {
                                 Author = a.Author,
                                 ObjekID = a.ObjekID,
                                 Content = a.Content,
                                 ObjekName = o.Nama_Objek,
                                 ID = a.ID,
                                 Judul = a.Judul,
                                 Tanggal = a.Tanggal,
                             };
                return View(result.FirstOrDefault());
            }
        }

        // GET: Artikel/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.Objeks = this.GetObjekkWisata();
                return View();
            }
            else
                return RedirectToAction("NotHaveAccess", "ErroorHanler");
        }


        public List<objek> GetObjekkWisata()
        {
            using (var db = new OcphDbContext())
            {
                return db.objeks.Select().ToList();
            }
        }

        // POST: Artikel/Create
        [HttpPost]
        public ActionResult Create(Artikel model)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    // TODO: Add insert logic here
                    model.Tanggal = DateTime.Now;
                    model.Author = User.Identity.Name;

                    using (var db = new OcphDbContext())
                    {
                        db.Artikels.Insert(model);
                    }


                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }else
            {
                return RedirectToAction("NotHaveAccess", "ErroorHanler");

            }
        }

        // GET: Artikel/Edit/5
        public ActionResult Edit(int id)
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.Objeks = this.GetObjekkWisata();
                using (var db = new OcphDbContext())
                {
                    var result = db.Artikels.Where(O => O.ID == id).FirstOrDefault();
                    return View(result);
                }
            }
            else
            {
                return RedirectToAction("NotHaveAccess", "ErroorHanler");
            }
        }

        // POST: Artikel/Edit/5
        [HttpPost]
       
        public ActionResult Edit(int id, Artikel model)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    using (var db = new OcphDbContext())
                    {
                        model.Tanggal = DateTime.Now;
                        db.Artikels.Update(O => new { O.Judul, O.Content, O.Tanggal }, model, O => O.ID == id);
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
                return RedirectToAction("NotHaveAccess", "ErroorHanler");
            }
        }

        // GET: Artikel/Delete/5
        public ActionResult Delete(int id)
        {
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = from a in db.Artikels.Where(O => O.ID == id)
                                 join o in db.objeks.Select() on a.ObjekID equals o.ObjekID
                                 select new DataAccess.Models.Artikel
                                 {
                                     Author = a.Author,
                                     ObjekID = a.ObjekID,
                                     Content = a.Content,
                                     ObjekName = o.Nama_Objek,
                                     ID = a.ID,
                                     Judul = a.Judul,
                                     Tanggal = a.Tanggal,
                                 };
                    return View(result.FirstOrDefault());
                }
            }
            else
            {
                return RedirectToAction("NotHaveAccess", "ErroorHanler");
            }
        }

        // POST: Artikel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    using (var db = new OcphDbContext())
                    {
                        db.Artikels.Delete(O => O.ID == id);
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
                return RedirectToAction("NotHaveAccess", "ErroorHanler");
            }
        }
    }
}
