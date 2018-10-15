using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPExciseLTS
{
    public static class CommonConfig
    {
        public static string Conn()
        {
            string Comm = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ToString();
            return Comm;
        }        
    }
}