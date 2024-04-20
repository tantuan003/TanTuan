using System;
using System.Collections.Generic;

namespace EF.Models
{
    public partial class SinhVien
    {
        public string MaSsv { get; set; }
        public string Ten { get; set; }
        public int? Tuoi { get; set; }
        public string Lop { get; set; }
        public string Khoa { get; set; }

        public virtual Khoa KhoaNavigation { get; set; }
        public virtual Lop LopNavigation { get; set; }
    }
}
