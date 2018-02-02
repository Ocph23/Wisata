using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisata.Controllers
{
    public class rumah_sakitController : Controller
    {
        //
        // GET: /rumah_sakit/
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = from rs in db.rumah_sakits.Select()
                                 join k in db.kecamatans.Select() on rs.KecamatanID equals k.Id_Kecamatan
                                 select new DataAccess.Models.rumah_sakit
                                 {
                                     Alamat = rs.Alamat,
                                     KecamatanName = k.Nama_Kecamatan,
                                     KecamatanID = rs.KecamatanID,
                                     Nama_Rumah_sakit = rs.Nama_Rumah_sakit,
                                     Rumah_SakitID = rs.Rumah_SakitID
                                 };
                    return View(result);
                }

            }
            else
            {
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            }
            

        }



        //
        // GET: /Rumah_Sakit/Details/5
        public ActionResult Details(int id)
        {
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = from rs in db.rumah_sakits.Where(O => O.Rumah_SakitID == id)
                                 join k in db.kecamatans.Select() on rs.KecamatanID equals k.Id_Kecamatan
                                 select new DataAccess.Models.rumah_sakit
                                 {
                                     Alamat = rs.Alamat,
                                     KecamatanName = k.Nama_Kecamatan,
                                     KecamatanID = rs.KecamatanID,
                                     Nama_Rumah_sakit = rs.Nama_Rumah_sakit,
                                     Rumah_SakitID = rs.Rumah_SakitID
                                 };
                    return View(result.FirstOrDefault());
                }
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            

        }


        public List<DataAccess.Models.kecamatan> GetKecamatan()
        {
            using (var db = new OcphDbContext())
            {
                return db.kecamatans.Select().ToList();
                
               
            }
        }

        //
        // GET: /Rumah_Sakit/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.Kecamatans = this.GetKecamatan();
                return View();
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            
        }

        //
        // POST: /Rumah_Sakit/Create
        [HttpPost]
        public ActionResult Create(DataAccess.Models.rumah_sakit model)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    using (var db = new OcphDbContext())
                    {
                        var res = db.rumah_sakits.Insert(model);
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
        // GET: /Rumah_Sakit/Edit/5
        public ActionResult Edit(int id)
        {
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.rumah_sakits.Where(O => O.Rumah_SakitID == id).FirstOrDefault();
                    ViewBag.Kecamatans = this.GetKecamatan();
                    return View(result);
                }
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            

        }

        //
        // POST: /Rumah_Sakit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DataAccess.Models.rumah_sakit model)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    // TODO: Add update logic here
                    using (var db = new OcphDbContext())
                    {
                        db.rumah_sakits.Update(O => new { O.Rumah_SakitID, O.Nama_Rumah_sakit, O.Alamat, O.KecamatanID ,O.Bujur,O.Lintang}, model, O => O.Rumah_SakitID == id);
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
        // GET: /Rumah_Sakit/Delete/5
        public ActionResult Delete(int id)
        {
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = from rs in db.rumah_sakits.Where(O => O.Rumah_SakitID == id)
                                 join k in db.kecamatans.Select() on rs.KecamatanID equals k.Id_Kecamatan
                                 select new DataAccess.Models.rumah_sakit
                                 {
                                     Alamat = rs.Alamat,
                                     KecamatanName = k.Nama_Kecamatan,
                                     KecamatanID = rs.KecamatanID,
                                     Nama_Rumah_sakit = rs.Nama_Rumah_sakit,
                                     Rumah_SakitID = rs.Rumah_SakitID
                                 };
                    return View(result.FirstOrDefault());
                }
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            
        }

        //
        // POST: /Rumah_Sakit/Delete/5
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
                        db.rumah_sakits.Delete(O => O.Rumah_SakitID == id);
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
