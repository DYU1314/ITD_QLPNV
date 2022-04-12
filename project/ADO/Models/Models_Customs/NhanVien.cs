using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Models.Models_Customs
{
    public class NhanVien
    {
        private int id;
        private string tenPB;
        private string tenCV;
        private string userName;
        private string maNV;
        private string tenNV;
        private string gioiTinh;
        private DateTime? ngaySinh;
        private string soDienThoai;
        private string email;
        private string diaChi;

        public int Id { get => id; set => id = value; }
        public string TenPB { get => tenPB; set => tenPB = value; }
        public string TenCV { get => tenCV; set => tenCV = value; }
        public string UserName { get => userName; set => userName = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime? NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}
