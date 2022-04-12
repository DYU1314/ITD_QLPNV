using ADO.Models.Models;
using ADO.Models.Models_Customs;
using ADO.Services.Auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.DAO
{
    public class ChucVuDAO
    {
        DatabaseContext db = new DatabaseContext();

        private static ChucVuDAO instance;

        public static ChucVuDAO Instance
        {
            get { if (instance == null) instance = new ChucVuDAO(); return instance; }
            private set { instance = value; }
        }

        public ChucVuDAO() { }

        public List<ChucVu> GetListChucVuCustoms()
        {
            List<ChucVu> list = new List<ChucVu>(
                            (from cv in db.CHUC_VUs
                             select new ChucVu
                             {
                                 Id = cv.ID,
                                 MaCV = cv.MACV,
                                 TenCV = cv.TENCV
                             })
                             .OrderBy(c => c.MaCV)
                             .ToList());

            return list;
        }

        public bool Add(string macv, string tencv)
        {
            CHUC_VU cv = new CHUC_VU();

            cv.MACV = macv;
            cv.TENCV = tencv;

            db.CHUC_VUs.Add(cv);

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        public string GetCode()
        {
            return CodeIdentity.Instance.PositionCode();
        }

        public bool Update(CHUC_VU chucvu, string tencv)
        {
            chucvu.TENCV = tencv;

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        public CHUC_VU GetChucVuById(int id)
        {
            return db.CHUC_VUs.Find(id);
        }

        public bool Dalete(int id)
        {
            ChucVuNhanVienDAO.Instance.DeleteChucVu(id);
            CHUC_VU cv = new CHUC_VU();

            cv = db.CHUC_VUs.SingleOrDefault(c => c.ID == id);

            db.CHUC_VUs.Attach(cv);
            db.CHUC_VUs.Remove(cv);

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        internal int GetCountChucVuByName(string tencv)
        {
            return db.CHUC_VUs.Count(c => c.TENCV == tencv);
        }

        public CHUC_VU GetChucVuByName(string tencv)
        {
            return db.CHUC_VUs.FirstOrDefault(c => c.TENCV == tencv);
        }
    }
}
