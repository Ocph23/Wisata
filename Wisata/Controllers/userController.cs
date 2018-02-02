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
            if (Request.IsAuthenticated && new Users( User.Identity.Name).IsAdmin)
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.users.Select().ToList();
                    return View(result);
                }

            }else
            {
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            }
        }

        //
        // GET: /F\User/Details/5
        public ActionResult Details(string id)
        {
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.users.Where(O => O.Id_User == id).FirstOrDefault();
                    return View(result);
                }
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        //
        // GET: /User/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }else

                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        //
        // POST: /User/Create
        [HttpPost]
        public ActionResult Create(DataAccess.Models.user model)
        {
            if (Request.IsAuthenticated)
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
            }else

                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        //
        // GET: /User/Edit/5
        public ActionResult Edit(string id)
        {
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.users.Where(O => O.Id_User == id).FirstOrDefault();
                    return View(result);
                }
            }else

                return RedirectToAction("NotHaveAccess", "ErrorHanler");
            
        }


        public ActionResult Change(string Id, int status)
        {
            using(var db = new OcphDbContext())
            {
                int s;
                if(status==0)
                     s=1;
                else
                     s=0;
                var res = db.users.Update(O => new { O.Status }, new DataAccess.Models.user { Status = s, Id_User = Id }, O => O.Id_User == Id);
            }
            return RedirectToAction("Index");
        }


        //
        // POST: /User/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, DataAccess.Models.user model)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    // TODO: Add update logic here
                    using (var db = new OcphDbContext())
                    {
                        db.users.Update(O => new { O.Id_User, O.User }, model, O => O.Id_User == id);
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
        // GET: /User/Delete/5
        public ActionResult Delete(string id)
        {
            if (Request.IsAuthenticated)
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.users.Where(O => O.Id_User == id).FirstOrDefault();
                    return View(result);
                }
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }

        //
        // POST: /User/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            if (Request.IsAuthenticated)
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
            }else
                return RedirectToAction("NotHaveAccess", "ErrorHanler");
        }
    }
}
