using ADO.Models.Models;
using ADO.Models.Models_Customs;
using ADO.Services.Auto;
using ADO.Services.Check;
using ADO.Services.Format;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.DAO
{
    public class NhanVienDAO
    {
        DatabaseContext db = new DatabaseContext();

        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; }
            private set { instance = value; }
        }

        public NhanVienDAO() { }

        public List<NhanVien> GetListNhanVienCustoms()
        {
            List<NhanVien> list = new List<NhanVien>(
                (from nv in db.NHAN_VIENs
                 from u in db.ACCOUNTs.Where(c => c.ID_NHANVIEN == nv.ID).DefaultIfEmpty()
                 from pb_nv in db.PHONGBAN_NHANVIENs.Where(c => c.ID_NHANVIEN == nv.ID).DefaultIfEmpty()
                 from pb in db.PHONG_BANs.Where(c => c.ID == pb_nv.ID_PHONGBAN).DefaultIfEmpty()
                 from cv_nv in db.CHUCVU_NHANVIENs.Where(c => c.ID_NHANVIEN == nv.ID).DefaultIfEmpty()
                 from cv in db.CHUC_VUs.Where(c => c.ID == cv_nv.ID_CHUCVU).DefaultIfEmpty()
                 select new NhanVien
                 {
                     Id = nv.ID,
                     TenPB = pb.TENPB,
                     TenCV = cv.TENCV,
                     UserName = u.USERNAME,
                     MaNV = nv.MANV,
                     TenNV = nv.HOTEN,
                     GioiTinh = nv.GIOITINH,
                     NgaySinh = nv.NGAYSINH,
                     SoDienThoai = nv.SODIENTHOAI,
                     Email = nv.EMAIL,
                     DiaChi = nv.DIACHI
                 }).OrderBy(c => c.MaNV).ToList());
            return list;
        }

        public NHAN_VIEN GetNhanVienByUser(ACCOUNT user)
        {
            NHAN_VIEN nv = (from nhanvien in db.NHAN_VIENs
                            from u in db.ACCOUNTs.Where(c => c.ID == user.ID).DefaultIfEmpty()
                            select nhanvien).FirstOrDefault();
            return nv;
        }

        public bool Add(
            string tenpb,
            string tencv,
            string manv,
            string tennv,
            string gioitinh,
            DateTime ngaysinh,
            string sodienthoai,
            string email,
            string diachi)
        {
            NHAN_VIEN nv = new NHAN_VIEN();
            PHONG_BAN pb = new PHONG_BAN();
            CHUC_VU cv = new CHUC_VU();

            if (tenpb != null)
                if (PhongBanDAO.Instance.GetCountPhongBanByName(tenpb) < 1)
                    return false;
            pb = PhongBanDAO.Instance.GetPhongBanByName(tenpb);

            if (tencv != null)
                if (ChucVuDAO.Instance.GetCountChucVuByName(tencv) < 1)
                    return false;
            cv = ChucVuDAO.Instance.GetChucVuByName(tencv);

            if (gioitinh != "")
            {
                if (Check.Instance.GioiTinh(gioitinh))
                    gioitinh = Format.Instance.GioiTinh(gioitinh);
                else return false;
            }

            if (sodienthoai != "")
                if (Check.Instance.SoDienThoai(sodienthoai) == false)
                    return false;

            nv.MANV = manv;
            nv.HOTEN = tencv;
            nv.GIOITINH = gioitinh;
            nv.NGAYSINH = ngaysinh;
            nv.SODIENTHOAI = sodienthoai;
            nv.EMAIL = email;
            nv.DIACHI = diachi;

            db.NHAN_VIENs.Add(nv);

            if (db.SaveChanges() > 0)
            {
                nv = new NHAN_VIEN();
                nv = NhanVienDAO.Instance.GetNhanVienByMa(manv);

                if (PhongBanNhanVienDAO.Instance.Add(pb, nv) == false)
                {
                    db.NHAN_VIENs.Attach(nv);
                    db.NHAN_VIENs.Remove(nv);

                    db.SaveChanges();

                    return false;
                }

                if (ChucVuNhanVienDAO.Instance.Add(cv, nv) == false)
                {
                    db.NHAN_VIENs.Attach(nv);
                    db.NHAN_VIENs.Remove(nv);

                    db.SaveChanges();

                    PhongBanDAO.Instance.Dalete(pb, nv);

                    return false;
                }
                return true;
            }
            return false;
        }

        public bool Update(
            PHONG_BAN phongban,
            CHUC_VU chucvu,
            NHAN_VIEN nhanvien,
            string tenpb,
            string tencv,
            string tennv,
            string gioitinh,
            DateTime ngaysinh,
            string sodienthoai,
            string email,
            string diachi)
        {
            if (PhongBanNhanVienDAO.Instance.Update(phongban, nhanvien, tenpb) == false)
                return false;

            if (ChucVuNhanVienDAO.Instance.Update(chucvu, nhanvien, tencv) == false)
                return false;

            if (gioitinh != "")
                if (Check.Instance.GioiTinh(gioitinh))
                    gioitinh = Format.Instance.GioiTinh(gioitinh);
                else return false;

            if (sodienthoai != "")
                if (Check.Instance.SoDienThoai(sodienthoai) == false)
                    return false;

            if (
            nhanvien.HOTEN == tennv
            && nhanvien.GIOITINH == gioitinh
            && nhanvien.NGAYSINH == ngaysinh
            && nhanvien.SODIENTHOAI == sodienthoai
            && nhanvien.EMAIL == email
            && nhanvien.DIACHI == diachi
            ) return true;

            nhanvien.HOTEN = tennv;
            nhanvien.GIOITINH = gioitinh;
            nhanvien.NGAYSINH = ngaysinh;
            nhanvien.SODIENTHOAI = sodienthoai;
            nhanvien.EMAIL = email;
            nhanvien.DIACHI = diachi;

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        private NHAN_VIEN GetNhanVienByMa(string manv)
        {
            return db.NHAN_VIENs.FirstOrDefault(c => c.MANV == manv);
        }

        public string GetCode()
        {
            return CodeIdentity.Instance.StaffCode();
        }

        public NHAN_VIEN GetNhanVienById(int id)
        {
            return db.NHAN_VIENs.FirstOrDefault(c => c.ID == id);
        }

        public bool Dalete(int id)
        {
            PhongBanNhanVienDAO.Instance.DeleteNhanVien(id);
            ChucVuNhanVienDAO.Instance.DeleteNhanVien(id);
            UserDAO.Instance.DeleteNhanVien(id);

            NHAN_VIEN nv = new NHAN_VIEN();
            nv = db.NHAN_VIENs.SingleOrDefault(c => c.ID == id);

            db.NHAN_VIENs.Attach(nv);
            db.NHAN_VIENs.Remove(nv);

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
