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
    public class PhongBanDAO
    {
        DatabaseContext db = new DatabaseContext();

        private static PhongBanDAO instance;

        public static PhongBanDAO Instance
        {
            get { if (instance == null) instance = new PhongBanDAO(); return instance; }
            private set { instance = value; }
        }

        private PhongBanDAO() { }

        public List<PhongBan> GetListPhongBanCustoms()
        {
            List<PhongBan> list = new List<PhongBan>(
                (from pb in db.PHONG_BANs
                 select new PhongBan
                 {
                     Id = pb.ID,
                     MaPB = pb.MAPB,
                     TenPB = pb.TENPB
                 })
                 .OrderBy(c => c.MaPB)
                 .ToList());

            return list;
        }

        public bool Add(string mapb, string tenpb)
        {
            PHONG_BAN p = new PHONG_BAN();

            p.MAPB = mapb;
            p.TENPB = tenpb;

            db.PHONG_BANs.Add(p);

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        public string GetCode()
        {
            return CodeIdentity.Instance.DepartmentCode();
        }

        public PHONG_BAN GetPhongBanById(int id)
        {
            return db.PHONG_BANs.Find(id);
        }

        public bool Update(PHONG_BAN phongban, string tenpb)
        {
            phongban.TENPB = tenpb;

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool Dalete(int id)
        {
            PhongBanNhanVienDAO.Instance.DeletePhongBan(id);

            PHONG_BAN p = new PHONG_BAN();

            p = db.PHONG_BANs.SingleOrDefault(c => c.ID == id);

            db.PHONG_BANs.Attach(p);
            db.PHONG_BANs.Remove(p);

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        internal int GetCountPhongBanByName(string tenpb)
        {
            return db.PHONG_BANs.Count(c => c.TENPB == tenpb);
        }

        public PHONG_BAN GetPhongBanByName(string tenpb)
        {
            return db.PHONG_BANs.FirstOrDefault(c => c.TENPB == tenpb);
        }

        internal void Dalete(PHONG_BAN pb, NHAN_VIEN nv)
        {
            PHONGBAN_NHANVIEN pb_nv = new PHONGBAN_NHANVIEN();

            pb_nv = db.PHONGBAN_NHANVIENs.FirstOrDefault(
                c => c.ID_PHONGBAN == pb.ID
                && c.ID_NHANVIEN == nv.ID);

            db.PHONGBAN_NHANVIENs.Attach(pb_nv);
            db.PHONGBAN_NHANVIENs.Remove(pb_nv);

            db.SaveChanges();
        }
    }
}
