using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Wisata.Models;

namespace Wisata.DataAccess.Models
{
    [TableName("hotel")]
    public class hotel
    {
        [PrimaryKey("Id_hotel")]
        [DbColumn("Id_hotel")]
        [DisplayName("ID")]
        public int HotelID { get; set; }

        [DbColumn("Id_kecamatan")]
        [DisplayName("KECAMATAN")]
        public int KecamatanID { get; set; }

         [DisplayName("KECAMATAN")]
        public string KecamatanName { get; set; }

        [DbColumn("nama_hotel")]
        [DisplayName("NAMA HOTEL")]
        public string Nama_Hotel { get; set; }

        [DbColumn("status_hotel")]
        [DisplayName("STATUS HOTEL")]
        public status_hotel Status { get; set;}

        public double Statuses { get; set; }
        [DbColumn("jumlah_kamar")]
        [DisplayName("JUMLAH KAMAR")]
        public int Jumlah_kamar { get; set; }

        [DbColumn("harga_satu_malam")]
        [DisplayName("HARGA 1 MALAM")]
        public int Harga_Satu_Malam {get; set;}

        [DbColumn("nama_direktur")]
        [DisplayName("NAMA DIREKTUR")]
        public string Nama_Direktur { get; set; }

        [DbColumn("nomor_telpon")]
        [DisplayName("NOMOR TELEPON")]
        public string Nomor_Telpon { get; set; }

        [DbColumn("email")]
        [DisplayName("E-MAIL")]
        public string Email { get; set; }

        [DbColumn("website")]
        [DisplayName("WEBSITE")]
        public string Website { get; set; }

    }
}
