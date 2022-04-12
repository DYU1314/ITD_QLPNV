using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Models.Models_Customs
{
    public class ChucVu
    {
        private int id;
        private string maCV;
        private string tenCV;

        public int Id { get => id; set => id = value; }
        public string MaCV { get => maCV; set => maCV = value; }
        public string TenCV { get => tenCV; set => tenCV = value; }
    }
}
