using ADO.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.DAO
{
    public class QuyenDAO
    {
        DatabaseContext db = new DatabaseContext();

        private static QuyenDAO instance;

        public static QuyenDAO Instance
        {
            get { if (instance == null) instance = new QuyenDAO(); return instance; }
            private set { instance = value; }
        }

        public QuyenDAO() { }

        public LEVEL_USER GetQuyenByUser(ACCOUNT user)
        {
            return db.LEVEL_USERs.FirstOrDefault(c => c.ID == user.ID_QUYEN);
        }

        public List<LEVEL_USER> GetListUser()
        {
            return db.LEVEL_USERs.Where(c => c.QUYEN != "ADMIN").ToList();
        }

        internal int GetCountQuyenByName(string quyen)
        {
            return db.LEVEL_USERs.Count(c => c.QUYEN == quyen);
        }

        internal LEVEL_USER GetQuyenByName(string quyen)
        {
            return db.LEVEL_USERs.FirstOrDefault(c => c.QUYEN == quyen);
        }
    }
}
