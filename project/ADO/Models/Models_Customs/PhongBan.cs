using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Models.Models_Customs
{
    public class PhongBan
    {
        private int id;
        private string maPB;
        private string tenPB;

        public int Id { get => id; set => id = value; }
        public string MaPB { get => maPB; set => maPB = value; }
        public string TenPB { get => tenPB; set => tenPB = value; }
    }
}
