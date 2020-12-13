using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTaiKhoaHoc.DTO
{
    class DTO_DONXINGIAHAN
    {
        private int _maDonXin;
        private int _maGiangVien;
        private int _maCTDX;
        private string _link;

        public int maDonXin
        {
            get => _maDonXin;
            set => _maDonXin = value;
        }
        public int maGiangVien
        {
            get => _maGiangVien;
            set => _maGiangVien = value;
        }
        public int maCTDX
        {
            get => _maCTDX;
            set => _maCTDX = value;
        }
        public string link
        {
            get => _link;
            set => _link = value;
        }

        public DTO_DONXINGIAHAN(int maDonXin,
                            int maGiangVien,
                            int maCTDX,
                            string link)
        {
            this.maDonXin = maDonXin;
            this.maGiangVien = maGiangVien;
            this.maCTDX = maCTDX;
            this.link = link;
        }
    }
}
