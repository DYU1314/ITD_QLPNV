using ADO.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.DAO
{
    public class ChucVuNhanVienDAO
    {
        DatabaseContext db = new DatabaseContext();

        private static ChucVuNhanVienDAO instance;

        public static ChucVuNhanVienDAO Instance
        {
            get { if (instance == null) instance = new ChucVuNhanVienDAO(); return instance; }
            private set { instance = value; }
        }

        public ChucVuNhanVienDAO() { }

        internal bool DeleteChucVu(int id)
        {
            if (db.CHUCVU_NHANVIENs.Count(c => c.ID_CHUCVU == id) < 1) return false;

            var rows = from cv_nv in db.CHUCVU_NHANVIENs.Where(c => c.ID_CHUCVU == id) select cv_nv;

            foreach (var row in rows)
            {
                db.CHUCVU_NHANVIENs.Remove(row);
            }

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }
        
        internal bool DeleteNhanVien(int id)
        {
            if (db.CHUCVU_NHANVIENs.Count(c => c.ID_NHANVIEN == id) < 1) return false;

            var rows = from cv_nv in db.CHUCVU_NHANVIENs.Where(c => c.ID_NHANVIEN == id) select cv_nv;

            foreach (var row in rows)
            {
                db.CHUCVU_NHANVIENs.Remove(row);
            }

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        internal bool Add(CHUC_VU cv, NHAN_VIEN nv)
        {
            CHUCVU_NHANVIEN cv_nv = new CHUCVU_NHANVIEN();

            cv_nv.ID_CHUCVU = cv.ID;
            cv_nv.ID_NHANVIEN = nv.ID;

            db.CHUCVU_NHANVIENs.Add(cv_nv);

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        internal bool Update(CHUC_VU chucvu, NHAN_VIEN nhanvien, string tencv)
        {
            CHUC_VU cv = new CHUC_VU();
            CHUCVU_NHANVIEN cv_nv = new CHUCVU_NHANVIEN();

            if (tencv == "") return false;

            if (ChucVuDAO.Instance.GetCountChucVuByName(tencv) > 0)
                cv = db.CHUC_VUs.FirstOrDefault(c => c.TENCV == tencv);
            else return false;

            if (db.CHUCVU_NHANVIENs.Count() == 0)
            {
                if (Add(cv, nhanvien))
                    return true;
                return false;
            }

            cv_nv = db.CHUCVU_NHANVIENs.SingleOrDefault(
                c => c.ID_CHUCVU == chucvu.ID
                && c.ID_NHANVIEN == nhanvien.ID);

            if (cv_nv.ID_CHUCVU == cv.ID) return true;

            cv_nv.ID_CHUCVU = cv.ID;
            cv_nv.ID_NHANVIEN = nhanvien.ID;

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
