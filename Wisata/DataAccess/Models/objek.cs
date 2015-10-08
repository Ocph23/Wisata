using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Wisata.DataAccess.Models
{
    [TableName("objek")]
    public class objek
    {
        [PrimaryKey("Id_Objek")]
        [DbColumn("Id_objek")]
        [DisplayName("ID")]
        public int ObjekID { get; set; }


        [DbColumn("Id_kecamatan")]
        [DisplayName("KECAMATAN")]
        public int KecamatanID { get; set; }


        [DisplayName("KECAMATAN")]
        public string KecamatanName { get; set; }

        [DbColumn("nama_objek")]
        [DisplayName("NAMA OBJEK")]
        public string Nama_Objek { get; set; }

        [DbColumn("jenis")]
        [DisplayName("JENIS")]
        public string Jenis { get; set; }

        [DbColumn("lintang")]
        [DisplayName("LINTANG")]
        public string Lintang { get; set; }

        [DbColumn("bujur")]
        [DisplayName("BUJUR")]
        public string Bujur { get; set; }
    }
}