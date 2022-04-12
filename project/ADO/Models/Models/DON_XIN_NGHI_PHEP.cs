namespace ADO.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DON_XIN_NGHI_PHEP
    {
        public int ID { get; set; }

        public string MAPHEP { get; set; }

        public DateTime? NGAYBATDAUNGHI { get; set; }

        public DateTime? NGAYDILAMLAI { get; set; }

        public string TRANGTHAI { get; set; }

        public int? ID_NHANVIEN { get; set; }

        public virtual NHAN_VIEN NHAN_VIEN { get; set; }
    }
}
