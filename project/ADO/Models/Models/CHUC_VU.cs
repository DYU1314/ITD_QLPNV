namespace ADO.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHUC_VU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHUC_VU()
        {
            CHUCVU_NHANVIEN = new HashSet<CHUCVU_NHANVIEN>();
        }

        public int ID { get; set; }

        public string MACV { get; set; }

        public string TENCV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHUCVU_NHANVIEN> CHUCVU_NHANVIEN { get; set; }
    }
}
