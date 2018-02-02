using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Wisata.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new OcphDbContext())
            {
                var objs = db.objeks.Select().ToList();
                ViewBag.NewArticle = (from i in db.Artikels.Select()
                                      select new DataAccess.Models.Artikel { Author = i.Author, ID = i.ID, ObjekID = i.ObjekID,
                                          Judul = i.Judul, Image = LinkPicCorrect(i.Content), Tanggal = i.Tanggal, 
                                          Description = GetPlainTextFromHtml(i.Content) }).ToList().FirstOrDefault();

                ViewBag.Kecamatans = (from i in db.kecamatans.Select(O => new { O.Id_Kecamatan, O.Nama_Kecamatan })
                                     select i).ToList();

                ViewBag.Artikels = (from i in db.Artikels.Select() select new  DataAccess.Models.Artikel 
                    { Author=i.Author,  ID=i.ID, ObjekID=i.ObjekID, Judul=i.Judul, Image=LinkPicCorrect(i.Content), Tanggal=i.Tanggal, Description=GetPlainTextFromHtml(i.Content)  }).ToList();
                return View(objs);
            }
            
        }
        private string GetPlainTextFromHtml(string htmlString)
        {
            string htmlTagPattern = "<.*?>";
            var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            htmlString = regexCss.Replace(htmlString, string.Empty);
            htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
            htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
            htmlString = htmlString.Replace("&nbsp;", string.Empty);
            if(htmlString.Length<=300)
            {
                return htmlString + "....";
            }else
                return htmlString.Substring(0,300)+" .... ";
        }

        public string LinkPicCorrect(string path)
        {
            string matchString = Regex.Match(path, @"(<img([^>]+)>)").Value;
           
            return matchString;
        }

        public ActionResult ViewObjekWisata()
        {
            using (var db = new OcphDbContext())
            {
                var objs = db.objeks.Select().ToList();
                List<Models.ObjectWisataView> view = new List<Models.ObjectWisataView>();
                foreach (var item in objs)
                {
                    var a = new Models.ObjectWisataView(item);
                    view.Add(a);
                }

                return View(view.ToList());
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}