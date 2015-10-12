using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sysbat.Utils
{
    public class SysBatLibContext
    {
        public static SysbatLib.Models.SysbatContext GetContext()
        {
            var dbConn = System.Configuration.ConfigurationManager.ConnectionStrings["DevConn"];
            SysbatLib.Models.SysbatContext db = new SysbatLib.Models.SysbatContext(dbConn.ConnectionString);
            return db;
        }
    }
}