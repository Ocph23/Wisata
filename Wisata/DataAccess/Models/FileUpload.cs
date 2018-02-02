using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wisata.Controllers;

namespace Wisata.DataAccess.Models
{
    [TableName("galery")]
    public class FileUpload
    {
        [PrimaryKey("id")]
        [DbColumn("id")]
        public int Id { get; set; }

        [DbColumn("Id_objek")]
        public int ObjeckId { get; set; }

       
        [DbColumn("filename")]
        public string FileName { get; set; }

        [DbColumn("fileuploadtype")]
        public FileUploadType CategoryFile { get; set; }

        [DbColumn("applicationfiletype")]
        public string ApplicationFileType { get; set; }

        [DbColumn("data")]
        public byte[] DataFile { get; set; }
    }
}
