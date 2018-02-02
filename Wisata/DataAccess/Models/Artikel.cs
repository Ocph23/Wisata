using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Web.Mvc;

namespace Wisata.DataAccess.Models
{
    [TableName("artikel")]
    public class Artikel
    {
        [PrimaryKey("Id_artikel")]
        [DbColumn("Id_artikel")]
        public int ID { get; set; }

        [DbColumn("Id_objek")]
        public int ObjekID { get; set; }

        public string ObjekName { get; set; }

        [DbColumn("Judul")]
        public string Judul { get; set; }

        [DbColumn("Description")]
        public string Description { get; set; }

         [AllowHtml]
        [DbColumn("Content")]
        public string Content { get; set; }

        [DbColumn("Author")]
        public string Author { get; set; }

        [DbColumn("Tanggal")]
        public DateTime Tanggal { get; set; }

        public string Image { get; internal set; }
    }
}