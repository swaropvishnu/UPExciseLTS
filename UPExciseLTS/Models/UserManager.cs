using System;
using System.Web;
using System.Web.SessionState;
using System.Data;
using UPExciseLTS.Models;

namespace UPExciseLTS.Models
{
    public class UserManager
    {
        protected HttpSessionState session;

        public UserManager(HttpSessionState httpSessionState)
        {
            session = httpSessionState;
        }

        public UserManager()
        {
            session = HttpContext.Current.Session;
        }

        public void Dispose()
        {
            session.Clear();
            session.Abandon();
        }


        public BOLogin tbl_Session
        {
            get
            {
                return session["tbl_Session"] as BOLogin;
            }
            set { session["tbl_Session"] = value; }
        }



        public string TokenPage
        {
            get
            {
                return
                  HttpContext.Current.Session["__TokenPage"] as string;
            }
            set { HttpContext.Current.Session["__TokenPage"] = value; }
        }



        public string UserName
        {
            get
            {
                return
                    tbl_Session.UserName;
            }
            set { tbl_Session.UserName = value; }
        }

        public string UserLevel
        {
            get
            {
                return tbl_Session.UserLevel;
            }
            set { tbl_Session.UserLevel = value; }
        }

        public string UserId
        {
            get
            {
                return
                       tbl_Session.UserID;
            }
            set
            {
                tbl_Session.UserID = value;
            }
        }
        public int Role
        {
            get
            {
                return
                    tbl_Session.RoleId;
            }
            set { tbl_Session.RoleId = value; }
        }
        public int UserDistictId
        {
            get
            {
                return
                   Convert.ToInt32(tbl_Session.DistrictCode);
            }
            set
            {
                tbl_Session.DistrictCode = value;
            }
        }
        public string Name
        {
            get
            {
                return
                 tbl_Session.Name;
            }
            set
            {
                tbl_Session.Name = value;
            }
        }
        public string Lastlogin
        {
            get
            {
                return
                    tbl_Session.LastlPasswordChangeDate;
            }
            set
            {
                tbl_Session.LastlPasswordChangeDate = value;
            }
        }

        public string Districtname
        {
            get
            {
                return
                    tbl_Session.Districtname;
            }
            set
            {
                tbl_Session.Districtname = value;
            }
        }

        public byte[] UserImg
        {
            get
            {
                return
                    tbl_Session.UserImg;
            }
            set
            {
                tbl_Session.UserImg = value;
            }
        }
        public int TypeOfUser
        {
            get
            {
                return
                    tbl_Session.TypeOfUser;
            }
            set
            {
                tbl_Session.TypeOfUser = value;
            }
        }
        



    }
}