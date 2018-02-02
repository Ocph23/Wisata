using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wisata.DataAccess.Models;

namespace Wisata.Models
{
    public class ObjectWisataView
    {
       

        //public List<Fasilitas> Fasilitases { get; set; }

        public objek ObjectWisata { get; set; }
        public List<hotel> Hotels { get; set; }
        public List<FileUpload> Galeries { get; set; }
        public List<rumah_sakit> RumahSakits { get; set; }
        public List<tempat_belanja> TempatBelanjas { get; set; }
        public List<travel> Travels { get; set; }
        public List<kuliner> Kuliners { get; set; }
        public kecamatan Kecamatan { get; set; }

        public ObjectWisataView(objek obj)
        {
            this.ObjectWisata = obj;
            if (obj != null)
            {
                using (var db = new OcphDbContext())
                {
                    //Fasilitases = db.Fasilitases.Where(O => O.ObjectId == obj.ObjekID);
                    Hotels = db.Hotels.Where(O => O.KecamatanID == obj.KecamatanID).ToList();
                    Galeries = db.Photos.Where(O => O.ObjeckId == obj.ObjekID).Take(1).ToList();
                    RumahSakits = db.rumah_sakits.Where(O => O.KecamatanID == obj.KecamatanID).ToList();
                    TempatBelanjas = db.tempat_belanjas.Where(O => O.KecamatanID == obj.KecamatanID).ToList();
                    Travels = db.travels.Where(O => O.KecamatanID == obj.KecamatanID).ToList();
                    this.Kecamatan = db.kecamatans.Where(O => O.Id_Kecamatan == obj.KecamatanID).FirstOrDefault();
                    this.Kuliners = db.kuliners.Where(O => O.KecamatanID == obj.KecamatanID).ToList();
                }
            }
        }

        public ObjectWisataView(int id)
        {
            // TODO: Complete member initialization

            using (var db = new OcphDbContext())
            {
                var obj = db.objeks.Where(O => O.ObjekID == id).FirstOrDefault();
                this.ObjectWisata = obj;
                if (ObjectWisata != null)
                {
                    //Fasilitases = db.Fasilitases.Where(O => O.ObjectId == obj.ObjekID);
                    Hotels = db.Hotels.Where(O => O.KecamatanID == obj.KecamatanID).ToList();
                   var res = from p in db.Photos.Where(O => O.ObjeckId == obj.ObjekID)
                               select new FileUpload
                               {
                                   ObjeckId = p.ObjeckId,
                                   DataFile =p.DataFile,
                                   Id = p.Id,
                                   FileName = p.FileName,
                                   ApplicationFileType = p.ApplicationFileType,
                                   CategoryFile = p.CategoryFile
                               };
                   Galeries = res.ToList();
                    RumahSakits = db.rumah_sakits.Where(O => O.KecamatanID == obj.KecamatanID).ToList();
                    TempatBelanjas = db.tempat_belanjas.Where(O => O.KecamatanID == obj.KecamatanID).ToList();
                    Travels = db.travels.Where(O => O.KecamatanID == obj.KecamatanID).ToList();
                    this.Kecamatan = db.kecamatans.Where(O => O.Id_Kecamatan == obj.KecamatanID).FirstOrDefault();
                    this.Kuliners = db.kuliners.Where(O => O.KecamatanID == obj.KecamatanID).ToList();
                }
            }
        }


    }
}