using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Wisata.DataAccess.Models
{
    [TableName("fasilitas")]
    public class Fasilitas
    {
        [PrimaryKey("Id_fasilitas")]
        [DbColumn("Id_fasilitas")]
        [DisplayName("ID")]
        public int FasilitasID { get; set; }

        [DbColumn("Id_Objek")]
        [DisplayName("KODE FASILITAS")]
        public int ObjectId { get; set; }

        [DbColumn("nama_fasilitas")]
        [DisplayName("NAMA FASILITAS")]
        public string Nama_Fasilitas { get; set; }

    }
}