using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Wisata.DataAccess.Models
{
    [TableName("user")]
    public class user
    {
        [PrimaryKey("Id_user")]
        [DbColumn("Id_user")]
        [DisplayName("ID")]
        public int Id_User { get; set; }

        [DbColumn("user")]
        [DisplayName("USER")]
        public string User { get; set; }

        [DbColumn("password")]
        [DisplayName("PASSWORD")]
        public string Password { get; set; }
    }
}