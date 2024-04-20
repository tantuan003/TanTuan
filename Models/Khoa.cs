using System;
using System.Collections.Generic;

namespace EF.Models
{
    public partial class Khoa
    {
        public Khoa()
        {
            SinhVien = new HashSet<SinhVien>();
        }

        public string TenKhoa { get; set; }

        public virtual ICollection<SinhVien> SinhVien { get; set; }
    }
}
