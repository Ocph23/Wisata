using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Wisata.DataAccess.Models
{
    [TableName("tempat_belanja")]
    public class tempat_belanja
    {
        [PrimaryKey("Id_tempat_belanja")]
        [DbColumn("Id_tempat_belanja")]
        [DisplayName("ID")]
        public int Id_tempat_belanja { get; set; }

        [DbColumn("Id_kecamatan")]
        [DisplayName("KECAMATAN")]
        public int KecamatanID { get; set; }

        [DisplayName("KECAMATAN")]
        public string KecamatanName { get; set; }

        [DbColumn("nama_tempat_belanja")]
        [DisplayName("NAMA")]
        public string Nama_Tempat_Belanja { get; set; }

        [DbColumn("alamat")]
        [DisplayName("ALAMAT")]
        public string Alamat { get; set; }


    }
}