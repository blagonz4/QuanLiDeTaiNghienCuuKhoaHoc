using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTaiKhoaHoc.DTO
{
    class DTO_HOPDONG
    {
        private int _maHopDong;
        private string _tenHopDong;


        public int maHopDong
        {
            get => _maHopDong;
            set => _maHopDong = value;
        }
        public string tenHopDong
        {
            get => _tenHopDong;
            set => _tenHopDong = value;
        }

        public DTO_HOPDONG(int maHopDong,
                            string tenHopDong)
        {
            this.maHopDong = maHopDong;
            this.tenHopDong = tenHopDong;

        }
    }
}
