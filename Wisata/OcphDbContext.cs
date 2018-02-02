using DAL.DContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DAL.Repository;
using Wisata.DataAccess.Models;

namespace Wisata
{
    public class OcphDbContext:IDbContext,IDisposable
    {
        private string ConnectionString;
        private IDbConnection _Connection;
        public OcphDbContext()
        {
            this.ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public System.Data.IDbConnection Connection
        {
            get
            {
                if(_Connection==null)
                {
                    _Connection = new MySqlDbContext(this.ConnectionString);
                    return _Connection;
                }else
                {
                    return _Connection;
                }
            }
        }

        public IRepository<hotel> Hotels { get { return new Repository<hotel>(this); } }
        public IRepository<kuliner> kuliners { get { return new Repository<kuliner>(this); } }
        public IRepository<kecamatan> kecamatans { get { return new Repository<kecamatan>(this); } }
        public IRepository<objek> objeks { get { return new Repository<objek>(this); } }
        public IRepository<pengunjung> pengunjungs { get { return new Repository<pengunjung>(this); } }
        public IRepository<rumah_sakit> rumah_sakits { get { return new Repository<rumah_sakit>(this); } }
        public IRepository<tempat_belanja> tempat_belanjas { get { return new Repository<tempat_belanja>(this); } }
       public IRepository<travel> travels { get { return new Repository<travel>(this); } }
        public IRepository<user> users { get { return new Repository<user>(this); } }
        public IRepository<Artikel> Artikels { get { return new Repository<Artikel>(this); } }
        public IRepository<FileUpload> Photos { get { return new Repository<FileUpload>(this); } }



        public void Dispose()
        {
            if(_Connection!=null)
            {
                if(this.Connection.State!=ConnectionState.Closed)
                {
                    this.Connection.Close();
                }
            }
        }
    }
}