using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Wisata.Models;

namespace Wisata.DataAccess.Models
{
    [TableName("transportasi")]
    public class transportasi
    {
        [PrimaryKey("Id_transportasi")]
        [DbColumn("Id_transportasi")]
        [DisplayName("ID")]
        public int TransportasiID { get; set; }

        [DbColumn("Id_objek")]
        [DisplayName("OBJEK")]
        public string Objek { get; set; }

        [DbColumn("kategori")]
        [DisplayName("KATEGORI")]
        public kategori_transportasi Kategori { get; set; }

    }
}