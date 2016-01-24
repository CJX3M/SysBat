using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatesAdmin.Utils
{
    public class ContextDB
    {
        public static SysbatLib.Models.SysbatContext GetContext()
        {
            var conn = System.Configuration.ConfigurationManager.ConnectionStrings["DevConn"];
            return new SysbatLib.Models.SysbatContext(conn.ConnectionString);
        }
    }
}