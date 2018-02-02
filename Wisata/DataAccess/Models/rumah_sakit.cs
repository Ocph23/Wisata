using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Wisata.DataAccess.Models
{
    [TableName("rumah_sakit")]
    public class rumah_sakit
    {
        [PrimaryKey("Id_rumah_sakit")]
        [DbColumn("Id_rumah_sakit")]
        [DisplayName("ID")]
        public int Rumah_SakitID { get; set; }

        [DbColumn("id_kecamatan")]
        [DisplayName("KECAMATAN")]
        public int KecamatanID { get; set; }

        [DisplayName("KECAMATAN")]
        public string KecamatanName { get; set; }

        [DbColumn("nama_rumah_sakit")]
        [DisplayName("NAMA RUMAH SAKIT")]
        public string Nama_Rumah_sakit { get; set; }

        [DbColumn("alamat")]
        [DisplayName("ALAMAT")]
        public string Alamat { get; set; }

        [DbColumn("lintang")]
        [DisplayName("Lintang")]
        public string Lintang { get; set; }

        [DbColumn("bujur")]
        [DisplayName("Bujur")]
        public string Bujur { get; set; }
    }
}