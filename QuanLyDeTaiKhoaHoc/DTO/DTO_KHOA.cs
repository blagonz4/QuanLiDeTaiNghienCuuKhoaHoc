using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTaiKhoaHoc.DTO
{
    class DTO_KHOA
    {
        private int _maKhoa;
        private string _tenKhoa;


        public int maKhoa
        {
            get => _maKhoa;
            set => _maKhoa = value;
        }
        public string tenKhoa
        {
            get => _tenKhoa;
            set => _tenKhoa = value;
        }

        public DTO_KHOA(int maKhoa,
                        string tenKhoa)
        {
            this.maKhoa = maKhoa;
            this.tenKhoa = tenKhoa;
        }
    }
}
