using ADO.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.DAO
{
    public class PhongBanNhanVienDAO
    {
        DatabaseContext db = new DatabaseContext();

        private static PhongBanNhanVienDAO instance;

        public static PhongBanNhanVienDAO Instance
        {
            get { if (instance == null) instance = new PhongBanNhanVienDAO(); return instance; }
            private set { instance = value; }
        }

        public PhongBanNhanVienDAO() { }

        internal bool DeletePhongBan(int id)
        {
            if (db.PHONGBAN_NHANVIENs.Count(c => c.ID_PHONGBAN == id) < 1) return false;

            var rows = from pb_nv in db.PHONGBAN_NHANVIENs.Where(c => c.ID_PHONGBAN == id) select pb_nv;

            foreach (var row in rows)
            {
                db.PHONGBAN_NHANVIENs.Remove(row);
            }

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        internal bool Add(PHONG_BAN pb, NHAN_VIEN nv)
        {
            PHONGBAN_NHANVIEN pb_nv = new PHONGBAN_NHANVIEN();

            pb_nv.ID_PHONGBAN = pb.ID;
            pb_nv.ID_NHANVIEN = nv.ID;

            db.PHONGBAN_NHANVIENs.Add(pb_nv);
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        internal bool Update(PHONG_BAN phongban, NHAN_VIEN nhanvien, string tenpb)
        {
            PHONG_BAN pb = new PHONG_BAN();
            PHONGBAN_NHANVIEN pb_nv = new PHONGBAN_NHANVIEN();

            if (tenpb == "") return false;

            if (PhongBanDAO.Instance.GetCountPhongBanByName(tenpb) > 0)
                pb = db.PHONG_BANs.FirstOrDefault(c => c.TENPB == tenpb);
            else return false;

            if (db.PHONGBAN_NHANVIENs.Count() == 0)
            {
                if (Add(pb, nhanvien))
                    return true;
                return false;
            }

            pb_nv = db.PHONGBAN_NHANVIENs.SingleOrDefault(
                c => c.ID_PHONGBAN == phongban.ID
                && c.ID_NHANVIEN == nhanvien.ID);

            if (pb_nv.ID_PHONGBAN == pb.ID) return true;

            pb_nv.ID_PHONGBAN = pb.ID;
            pb_nv.ID_NHANVIEN = nhanvien.ID;

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        internal bool DeleteNhanVien(int id)
        {
            if (db.PHONGBAN_NHANVIENs.Count(c => c.ID_NHANVIEN == id) < 1) return false;

            var rows = from pb_nv in db.PHONGBAN_NHANVIENs.Where(c => c.ID_NHANVIEN == id) select pb_nv;

            foreach (var row in rows)
            {
                db.PHONGBAN_NHANVIENs.Remove(row);
            }

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
