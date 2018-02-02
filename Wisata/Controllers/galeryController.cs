using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wisata.DataAccess.Models;

namespace Wisata.Controllers
{
    public class galeryController : Controller
    {
        //
        // GET: /galery/
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.objeks.Select();
                    ViewBag.Objeks = result.ToList();
                    return View();
                }
            }else
            {
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            }
           


        }
        public ActionResult UploadPhoto(FileUpload upload,HttpPostedFileBase file)
        {
            bool isSuccess = true;
            using (var db = new OcphDbContext())
            {
                try
                {
                    MemoryStream target = new MemoryStream();
                    file.InputStream.CopyTo(target);
                    byte[] data1 = target.ToArray();

                    byte[] data = data1;//DataAccess.Models.ImageHelpers.CreateThumbnail(data1,1024);

                    upload.ApplicationFileType = file.ContentType;
                    upload.CategoryFile = FileUploadType.Image;
                    upload.DataFile = data;
                    upload.FileName = file.FileName;

                    var Inserted = db.Photos.Insert(upload);
                    ViewBag.IsSaved = false;
                    if (Inserted)
                    {
                         isSuccess = true;
                    }
                    else
                        isSuccess = false;
                }
                catch (Exception)
                {

                    isSuccess = false;
                }

                if (isSuccess)
                {
                    return Json(new { Message = file.FileName});
                }
                else
                {
                    return Json(new { Message = "Error in saving file" });
                }
              
            }
        }

        [HttpGet]
        public JsonResult GetPictures(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = from data in db.Photos.Where(O => O.ObjeckId == id)
                             select new { Id = data.Id, FileData = Convert.ToBase64String(ImageHelpers.CreateThumbnail(data.DataFile,300,300)) };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        //
        // GET: /Galery/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new OcphDbContext())
            {
                return View();
            }

        }

        //
        // GET: /Galery/Create
        public ActionResult Create()
        {
            using (var db = new OcphDbContext())
            {
                var result = db.objeks.Select();
                ViewBag.Objeks = result.ToList();
                return View();
            }
        }

        //
        // POST: /Transportasi/Create
        [HttpPost]
        public ActionResult Create(FormCollection model)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Galery/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new OcphDbContext())
            {
                return View();
            }

        }

        //
        // POST: /Galery/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            try
            {
                // TODO: Add update logic here
                using (var db = new OcphDbContext())
                {
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Galery/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new OcphDbContext())
            {
                db.Photos.Delete(O => O.Id == id);
                return RedirectToAction("Index");
            }
        }

        //
        // POST: /Galery/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (var db = new OcphDbContext())
                {
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
