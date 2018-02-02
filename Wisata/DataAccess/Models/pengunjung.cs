using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Wisata.DataAccess.Models
{
    [TableName("pengunjung")]
    public class pengunjung
    {
        [PrimaryKey("Id_pengunjung")]
        [DbColumn("Id_pengunjung")]
        [DisplayName("ID")]
        public int PengunjungID { get; set; }

        [DbColumn("email")]
        [DisplayName("E-MAIL")]
        public string Email { get; set; }

        [DbColumn("nama")]
        [DisplayName("NAMA")]
        public string Nama { get; set; }

        [DbColumn("komentar")]
        [DisplayName("KOMENTAR")]
        public string Komentar { get; set; }

        [DbColumn("tanggal_jam")]
        [DisplayName("TANGGAL DAN JAM")]
        public DateTime Tanggal_Jam { get; set; }
    }
}