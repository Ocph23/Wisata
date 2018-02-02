using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Wisata.DataAccess.Models
{
    [TableName("kuliner")]
    public class kuliner
    {
        [PrimaryKey("Id_kuliner")]
        [DbColumn("Id_kuliner")]
        [DisplayName("ID")]
        public int KulinerID { get; set; }

        [DbColumn("id_kecamatan")]
        [DisplayName("KECAMATAN")]
        public int KecamatanID { get; set; }

         [DisplayName("KECAMATAN")]
        public string KecamatanName { get; set; }

        [DbColumn("nama_tempat_kuliner")]
        [DisplayName("NAMA TEMPAT KULINER")]
        public string Nama_Tempat_Kuliner { get; set; }

        [DbColumn("nomor_telpon")]
        [DisplayName("TELEPON")]
        public string Telpon { get; set; }

        [DbColumn("nama_pemilik")]
        [DisplayName("PEMILIK")]
        public string Pemilik { get; set; }

        [DbColumn("lintang")]
        [DisplayName("Lintang")]
        public string Lintang { get; set; }

        [DbColumn("bujur")]
        [DisplayName("bujur")]
        public string Bujur { get; set; }


    }
}