using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisata.Controllers
{
    public class DetailWisataController : Controller
    {
        //
        // GET: /DetailWisata/
        public ActionResult Index(int id)
        {
            var result = new Models.ObjectWisataView(id);
            var a = this.GetLagen(id);
            ViewBag.Maps = a;
            return View(result);
        }






        public List<Models.MapObject> GetLagen(int id)
        {
            List<Models.MapObject> list = new List<Models.MapObject>();
            var result = new Models.ObjectWisataView(id);


            if (result.ObjectWisata.Lintang != string.Empty && result.ObjectWisata.Bujur != null)
                {
                    var m = new Models.MapObject { Bujur = result.ObjectWisata.Bujur, Lintang = result.ObjectWisata.Lintang, Name = result.ObjectWisata.Nama_Objek };
                    list.Add(m);
                }
           


            foreach(var item in result.Hotels)
            {
                if (item.Lintang != string.Empty && item.Bujur != null)
                {
                    var m = new Models.MapObject { Bujur = item.Bujur, Lintang = item.Lintang, Name = item.Nama_Hotel };
                    list.Add(m);
                }
            }


            foreach(var item in result.Kuliners)
            {
                if (item.Lintang != string.Empty && item.Bujur != null)
                {
                    var m = new Models.MapObject { Bujur = item.Bujur, Lintang = item.Lintang, Name = item.Nama_Tempat_Kuliner };
                    list.Add(m);
                }
            }
            foreach (var item in result.RumahSakits)
            {
                if (item.Lintang != string.Empty && item.Bujur != null)
                {
                    var m = new Models.MapObject { Bujur = item.Bujur, Lintang = item.Lintang, Name = item.Nama_Rumah_sakit };
                    list.Add(m);
                }
            }
            foreach (var item in result.TempatBelanjas)
            {
                if (item.Lintang != string.Empty && item.Bujur != null)
                {
                    var m = new Models.MapObject { Bujur = item.Bujur, Lintang = item.Lintang, Name = item.Nama_Tempat_Belanja };
                    list.Add(m);
                }
            }
            foreach (var item in result.Travels)
            {
                if (item.Lintang != string.Empty && item.Bujur != null)
                {
                    var m = new Models.MapObject { Bujur = item.Bujur, Lintang = item.Lintang, Name = item.Nama_Travel };
                    list.Add(m);
                }
            }


            return  list;

        }

  
	}
}