using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Services.Format
{
    internal class Format
    {
        private static Format instance;

        public static Format Instance
        {
            get { if (Equals(instance, null)) instance = new Format(); return instance; }
            private set { instance = value; }
        }

        private Format() { }

        public string GioiTinh(string gioitinh)
        {
            gioitinh = gioitinh.ToLower();
            if (Equals(gioitinh, "nam")) return "Nam";
            if (Equals(gioitinh, "nữ")) return "Nữ";
            return "_";
        }
    }
}
