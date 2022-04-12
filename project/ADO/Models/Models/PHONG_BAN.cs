namespace ADO.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PHONG_BAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHONG_BAN()
        {
            PHONGBAN_NHANVIEN = new HashSet<PHONGBAN_NHANVIEN>();
        }

        public int ID { get; set; }

        public string MAPB { get; set; }

        public string TENPB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHONGBAN_NHANVIEN> PHONGBAN_NHANVIEN { get; set; }
    }
}
