using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPExciseLTS.Models
{
    public class BOLogin
    {
            public string clientCaptcha { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string UserID { get; set; }
            public string UserLevel { get; set; }
            public string OldPassword { get; set; }
            public string NewPassword { get; set; }
            public string ConFirmPassword { get; set; }
            public int LoginAttempts { get; set; }
            public int Userlock { get; set; }
            public string LastlPasswordChangeDate { get; set; }
            public int TypeOfUser { get; set; }
            public int RoleId { get; set; }
            public int DistrictCode { get; set; }
            public string Districtname { get; set; }
            public string Name { get; set; }
            public byte[] UserImg { get; set; }
    }
}