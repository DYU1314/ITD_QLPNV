namespace ADO.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NHAN_VIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAN_VIEN()
        {
            ACCOUNTs = new HashSet<ACCOUNT>();
            CHUCVU_NHANVIEN = new HashSet<CHUCVU_NHANVIEN>();
            DON_XIN_NGHI_PHEP = new HashSet<DON_XIN_NGHI_PHEP>();
            NGHI_PHEP = new HashSet<NGHI_PHEP>();
            PHONGBAN_NHANVIEN = new HashSet<PHONGBAN_NHANVIEN>();
        }

        public int ID { get; set; }

        public string MANV { get; set; }

        public string HOTEN { get; set; }

        public string GIOITINH { get; set; }

        public DateTime? NGAYSINH { get; set; }

        public string SODIENTHOAI { get; set; }

        public string EMAIL { get; set; }

        public string DIACHI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCOUNT> ACCOUNTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHUCVU_NHANVIEN> CHUCVU_NHANVIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DON_XIN_NGHI_PHEP> DON_XIN_NGHI_PHEP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NGHI_PHEP> NGHI_PHEP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHONGBAN_NHANVIEN> PHONGBAN_NHANVIEN { get; set; }
    }
}
