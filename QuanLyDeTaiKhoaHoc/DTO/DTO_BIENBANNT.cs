using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTaiKhoaHoc.DTO
{
    class DTO_BIENBANNT
    {
        private int _maBienBan;
        private int _maHoiDong;
        private int _tongDiem;
        private string _nhanXet;

        public int maBienBan
        {
            get => _maBienBan;
            set => _maBienBan = value;
        }
        public int maHoiDong
        {
            get => _maHoiDong;
            set => _maHoiDong = value;
        }
        public int tongDiem
        {
            get => _tongDiem;
            set => _tongDiem = value;
        }
        public string nhanXet
        {
            get => _nhanXet;
            set => _nhanXet = value;
        }

        public DTO_BIENBANNT(int maBienBan,
                            int maHoiDong,
                            int tongDiem,
                            string nhanXet)
        {
            this.maBienBan = maBienBan;
            this.maHoiDong = maHoiDong;
            this.tongDiem = tongDiem;
            this.nhanXet = nhanXet;
        }
    }
}
