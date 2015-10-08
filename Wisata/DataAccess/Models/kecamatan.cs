using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Wisata.DataAccess.Models
{
    [TableName("kecamatan")]
    public class kecamatan
    {
        [PrimaryKey("Id_kecamatan")]
        [DbColumn("Id_kecamatan")]
        [DisplayName("ID")]
        public int Id_Kecamatan { get; set; }

        [DbColumn("nama_kecamatan")]
        [DisplayName("NAMA KECAMATAN")]
        public string Nama_Kecamatan { get; set; }

        [DbColumn("keterangan")]
        [DisplayName("Keterangan")]
        public string Description { get; set; }

    }
}