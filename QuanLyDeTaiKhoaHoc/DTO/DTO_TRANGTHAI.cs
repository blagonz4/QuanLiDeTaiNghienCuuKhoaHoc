using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTaiKhoaHoc.DTO
{
    class DTO_TRANGTHAI
    {
        private int _maTrangThai;
        private string _tenTrangThai;


        public int maTrangThai
        {
            get => _maTrangThai;
            set => _maTrangThai = value;
        }
        public string tenTrangThai
        {
            get => _tenTrangThai;
            set => _tenTrangThai = value;
        }

        public DTO_TRANGTHAI(int maTrangThai,
                        string tenTrangThai)
        {
            this.maTrangThai = maTrangThai;
            this.tenTrangThai = tenTrangThai;
        }
    }
}
