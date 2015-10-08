using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisata.Controllers
{
    public class userController : Controller
    {
        //
        // GET: /user/
        public ActionResult Index()
        {
            using (var db = new OcphDbContext())
            {
                var result = db.users.Select().ToList();
                return View(result);
            }


        }

        //
        // GET: /F\User/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.users.Where(O => O.Id_User == id).FirstOrDefault();
                return View(result);
            }

        }

        //
        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create
        [HttpPost]
        public ActionResult Create(DataAccess.Models.user model)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var res = db.users.Insert(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.users.Where(O => O.Id_User == id).FirstOrDefault();
                return View(result);
            }

        }

        //
        // POST: /User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DataAccess.Models.user model)
        {
            try
            {
                // TODO: Add update logic here
                using (var db = new OcphDbContext())
                {
                    db.users.Update(O => new { O.Id_User,O.User,O.Password }, model, O=> O.Id_User == id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.users.Where(O => O.Id_User == id).FirstOrDefault();
                return View(result);
            }
        }

        //
        // POST: /User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (var db = new OcphDbContext())
                {
                    db.users.Delete(O => O.Id_User == id);
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
