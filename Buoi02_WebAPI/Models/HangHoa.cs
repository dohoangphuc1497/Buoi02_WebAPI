using System;
using System.Collections.Generic;

namespace Buoi02_WebAPI.Models
{
    public partial class HangHoa
    {
        public HangHoa()
        {
            ChiTietHd = new HashSet<ChiTietHd>();
        }

        public int MaHh { get; set; }
        public string TenHh { get; set; }
        public int MaLoai { get; set; }
        public string MoTaDonVi { get; set; }
        public double? DonGia { get; set; }
        public string Hinh { get; set; }
        public DateTime NgaySx { get; set; }
        public double GiamGia { get; set; }
        public int SoLanXem { get; set; }
        public string MoTa { get; set; }
        public string MaNcc { get; set; }

        public virtual Loai MaLoaiNavigation { get; set; }
        public virtual NhaCungCap MaNccNavigation { get; set; }
        public virtual ICollection<ChiTietHd> ChiTietHd { get; set; }
    }
}
