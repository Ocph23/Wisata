using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Wisata.DataAccess.Models
{
    [TableName("travel")]
    public class travel
    {
        [PrimaryKey("Id_travel")]
        [DbColumn("Id_travel")]
        [DisplayName("ID")]
        public int TravelID { get; set; }

        [DbColumn("Id_kecamatan")]
        [DisplayName("KECAMATAN")]
        public int KecamatanID { get; set; }

        [DisplayName("KECAMATAN")]
        public string KecamatanName { get; set; }

        [DbColumn("nama_travel")]
        [DisplayName("NAMA TRAVEL")]
        public string Nama_Travel { get; set; }

        [DbColumn("nomor_telepon")]
        [DisplayName("NOMOR TELEPON")]
        public string Nomor_Telepon { get; set; }

        [DbColumn("email")]
        [DisplayName("E-MAIL")]
        public string Email { get; set; }

        [DbColumn("website")]
        [DisplayName("WEBSITE")]
        public string Website { get; set; }

        [DbColumn("nama_direktur")]
        [DisplayName("DIREKTUR")]
        public string Nama_Direktur { get; set; }

        [DbColumn("lintang")]
        [DisplayName("Lintang")]
        public string Lintang { get; set; }

        [DbColumn("bujur")]
        [DisplayName("Bujur")]
        public string Bujur { get; set; }

    }
}