namespace ADO.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACCOUNT")]
    public partial class ACCOUNT
    {
        public int ID { get; set; }

        public string USERNAME { get; set; }

        public string PASSWORK { get; set; }

        public int? ID_QUYEN { get; set; }

        public int? ID_NHANVIEN { get; set; }

        public virtual NHAN_VIEN NHAN_VIEN { get; set; }

        public virtual LEVEL_USER LEVEL_USER { get; set; }
    }
}
