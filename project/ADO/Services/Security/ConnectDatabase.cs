using ADO.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Services.Security
{
    internal class ConnectDatabase
    {
        public ConnectDatabase()
        {
            TestConnect();
        }
        private List<LEVEL_USER> TestConnect()
        {
            DatabaseContext db = new DatabaseContext();
            List<LEVEL_USER> q = new List<LEVEL_USER>();
            q = db.LEVEL_USERs.ToList();
            return q;
        }
    }
}
