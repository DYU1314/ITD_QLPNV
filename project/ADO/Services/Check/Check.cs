using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Services.Check
{
    internal class Check
    {
        private static Check instance;

        public static Check Instance
        {
            get { if (Equals(instance, null)) instance = new Check(); return instance; }
            private set { instance = value; }
        }
        
        private Check() { }
        
        internal bool GioiTinh(string gioitinh)
        {
            if (Equals(gioitinh, null))
                return false;
            gioitinh = gioitinh.ToLower();
            if (Equals(gioitinh, "nam") || Equals(gioitinh, "nữ"))
                return true;
            return false;
        }
        
        internal bool SoDienThoai(string sdt)
        {
            string str = "1234567890";
            int count = 0;
            for (int i = 0; i < sdt.Length; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (sdt[i] == str[j])
                    {
                        count++;
                    }
                }
            }
            if (count == sdt.Length)
                return true;
            return false;
        }
    }
}
