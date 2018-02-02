using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Wisata.DataAccess.Models
{
    [TableName("users")]
    public class user
    {
        [PrimaryKey("Id")]
        [DbColumn("Id")]
        [DisplayName("ID")]
        public string Id_User { get; set; }

        [DbColumn("UserName")]
        [DisplayName("USER NAME")]
        public string User { get; set; }

        [DbColumn("LockoutEnabled")]
        [DisplayName("Status")]
        public int Status { get; set; }




    }
}