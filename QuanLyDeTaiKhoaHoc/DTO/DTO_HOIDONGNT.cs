using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTaiKhoaHoc.DTO
{
    class DTO_HOIDONGNT
    {
        private int _maHoiDong;
        private string _chuTichHoiDong;
        private string _phanBien1;
        private string _phanBien2;
        private string _thuKi;
        private string _ngayNghiemThu;
        private int _maKhoa;


        public int maHoiDong
        {
            get => _maHoiDong;
            set => _maHoiDong = value;
        }
        public string chuTichHoiDong
        {
            get => _chuTichHoiDong;
            set => _chuTichHoiDong = value;
        }
        public string phanBien1
        {
            get => _phanBien1;
            set => _phanBien1 = value;
        }
        public string phanBien2
        {
            get => _phanBien2;
            set => _phanBien2 = value;
        }
        public string thuKi
        {
            get => _thuKi;
            set => _thuKi = value;
        }
        public string ngayNghiemThu
        {
            get => _ngayNghiemThu;
            set => _ngayNghiemThu = value;
        }
        public int maKhoa
        {
            get => _maKhoa;
            set => _maKhoa = value;
        }

        public DTO_HOIDONGNT(int maHoiDong,
                            string chuTichHoiDong,
                            string phanBien1,
                            string phanBien2,
                            string thuKi,
                            string ngayNghiemThu,
                            int maKhoa)
        {
            this.maHoiDong = maHoiDong;
            this.chuTichHoiDong = chuTichHoiDong;
            this.phanBien1 = phanBien1;
            this.phanBien2 = phanBien2;
            this.thuKi = thuKi;
            this.ngayNghiemThu = ngayNghiemThu;
            this.maKhoa = maKhoa;
        }
    }
}
