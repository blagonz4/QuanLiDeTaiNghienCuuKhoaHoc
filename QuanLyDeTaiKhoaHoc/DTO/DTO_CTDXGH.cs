using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTaiKhoaHoc.DTO
{
    class DTO_CTDXGH
    {
        private int _maCTDXGH;
        private string _ngayGiaHan;
        private string _ngayHoanThanh;
        private int _isAccept;

        public int maCTDXGH
        {
            get => _maCTDXGH;
            set => _maCTDXGH = value;
        }
        public string ngayGiaHan
        {
            get => _ngayGiaHan;
            set => _ngayGiaHan = value;
        }
        public string ngayHoanThanh
        {
            get => _ngayHoanThanh;
            set => _ngayHoanThanh = value;
        }
        public int isAccept
        {
            get => _isAccept;
            set => _isAccept = value;
        }

        public DTO_CTDXGH(int maCTDXGH,
                            string ngayGiaHan,
                            string ngayHoanThanh,
                            int isAccept)
        {
            this.maCTDXGH = maCTDXGH;
            this.ngayGiaHan = ngayGiaHan;
            this.ngayHoanThanh = ngayHoanThanh;
            this.isAccept = isAccept;
        }
    }
}
