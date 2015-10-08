using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Wisata.DataAccess.Models
{
    [TableName("galery")]
    public class Galery
    {
        [PrimaryKey("Id_galery")]
        [DbColumn("Id_galery")]
        [DisplayName("ID")]
        public int GaleryID { get; set; }

        [DbColumn("Id_objek")]
        [DisplayName("KODE GALERY")]
        public string ObjectID { get; set; }

        [DbColumn("foto")]
        [DisplayName("FOTO")]
        public string Foto { get; set; }

        [DbColumn("deskripsi")]
        [DisplayName("DESKRIPSI")]
        public string Deskripsi { get; set; }

    
    }
}