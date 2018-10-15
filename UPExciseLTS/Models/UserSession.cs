using System;
using System.Web;
using System.Web.SessionState;
using System.Data;


namespace UPExciseLTS.Models
{
    public static class UserSession
    {
        public static UserManager LoggedInUser
        {
            get
            {
                UserManager user = new UserManager();
                return user;
            }
        }     
        public static string LoggedInUserId
        {
            get
            {
                return LoggedInUser.UserId;
            }
            set
            {
                LoggedInUser.UserId = value;
            }
        }
        public static string LoggedInUserName
        {
            get
            {
                return LoggedInUser.UserName;
            }
            set
            {
                LoggedInUser.UserName = value;
            }
        }
        public static int LoggedInUserRole
        {
            get
            {
                return LoggedInUser.Role;
            }
            set
            {
                LoggedInUser.Role = value;
            }
        }
        public static int LoggedInUserDistictId
        {
            get
            {
                return LoggedInUser.UserDistictId;
            }
            set
            {
                LoggedInUser.UserDistictId = value;
            }
        }
        public static string LoggedInName
        {
            get
            {
                return LoggedInUser.Name;
            }
            set
            {
                LoggedInUser.Name = value;
            }
        }
        public static string Lastlogin
        {
            get
            {
                return LoggedInUser.Lastlogin;
            }
            set
            {
                LoggedInUser.Lastlogin = value;
            }
        }

        public static byte[] LoggedInImage
        {
            get
            {
                return LoggedInUser.UserImg;
            }
            set
            {
                LoggedInUser.UserImg = value;
            }
        }
        public static int LoggedUserType
        {
            get
            {
                return LoggedInUser.TypeOfUser;
            }
            set
            {
                LoggedInUser.TypeOfUser = value;
            }
        }
        public static string LoggedInUserLevelId
        {
            get
            {
                return LoggedInUser.UserLevel;
            }
            set
            {
                LoggedInUser.UserLevel = value;
            }
        }

        public static string LoggedDistrictname
        {
            get
            {
                return LoggedInUser.Districtname;
            }
            set
            {
                LoggedInUser.Districtname = value;
            }
        }


    }
}