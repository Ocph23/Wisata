using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Wisata
{



    public class Users
    {
        private string username;
        public Users(string name)
        {
            this.username = name;
        }

        public  bool IsActived
        {
            get
            {

                using (var db = new OcphDbContext())
                {
                    var res = db.users.Where(O => O.User == this.username).FirstOrDefault();
                    if (res != null)
                    {
                        if (res.Status == 1)
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
            }

        }

        public bool IsAdmin
        {
            get
            {

                using (var db = new OcphDbContext())
                {
                    var res = db.users.Where(O => O.User == this.username).FirstOrDefault();
                    if (res != null)
                    {
                        if (res.Status >= 1)
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
            }

        }

        
    }
}