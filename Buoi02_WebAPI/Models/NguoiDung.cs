using System;
using System.Collections.Generic;

namespace Buoi02_WebAPI.Models
{
    public partial class NguoiDung
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string Hinh { get; set; }
        public bool HieuLuc { get; set; }
        public string VaiTro { get; set; }
        public string RandomKey { get; set; }

        public virtual VaiTro VaiTroNavigation { get; set; }
    }
}
