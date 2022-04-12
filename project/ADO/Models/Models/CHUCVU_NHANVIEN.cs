namespace ADO.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHUCVU_NHANVIEN
    {
        public int ID { get; set; }

        public int? ID_CHUCVU { get; set; }

        public int? ID_NHANVIEN { get; set; }

        public virtual CHUC_VU CHUC_VU { get; set; }

        public virtual NHAN_VIEN NHAN_VIEN { get; set; }
    }
}
