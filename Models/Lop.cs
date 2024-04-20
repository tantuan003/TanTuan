using System;
using System.Collections.Generic;

namespace EF.Models
{
    public partial class Lop
    {
        public Lop()
        {
            SinhVien = new HashSet<SinhVien>();
        }

        public string TenLop { get; set; }

        public virtual ICollection<SinhVien> SinhVien { get; set; }
    }
}
