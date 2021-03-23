using System;
using System.Collections.Generic;

namespace Buoi02_WebAPI.Models
{
    public partial class VaiTro
    {
        public VaiTro()
        {
            NguoiDung = new HashSet<NguoiDung>();
        }

        public string MaVt { get; set; }
        public string TenVaiTro { get; set; }
        public string ThongTin { get; set; }

        public virtual ICollection<NguoiDung> NguoiDung { get; set; }
    }
}
