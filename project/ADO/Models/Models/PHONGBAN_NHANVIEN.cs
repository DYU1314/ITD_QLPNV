namespace ADO.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PHONGBAN_NHANVIEN
    {
        public int ID { get; set; }

        public int? ID_PHONGBAN { get; set; }

        public int? ID_NHANVIEN { get; set; }

        public virtual NHAN_VIEN NHAN_VIEN { get; set; }

        public virtual PHONG_BAN PHONG_BAN { get; set; }
    }
}
