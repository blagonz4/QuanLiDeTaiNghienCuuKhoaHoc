using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTaiKhoaHoc.DTO
{
    class DTO_DETAI
    {
        private int _maDeTai;
        private string _tenDeTai;
        private string _ngayThucHien;
        private string _ngayHoanThanh;
        private string _linhVuc;
        private string _capDo;
        private string _ketQua;
        private int _maTrangThai;
        private int _maGiangVien;

        public int maDeTai
        {
            get => _maDeTai;
            set => _maDeTai = value;
        }
        public string tenDeTai
        {
            get => _tenDeTai;
            set => _tenDeTai = value;
        }
        public string ngayThucHien
        {
            get => _ngayThucHien;
            set => _ngayThucHien = value;
        }
        public string ngayHoanThanh
        {
            get => _ngayHoanThanh;
            set => _ngayHoanThanh = value;
        }
        public string linhVuc
        {
            get => _linhVuc;
            set => _linhVuc = value;
        }
        public string capDo
        {
            get => _capDo;
            set => _capDo = value;
        }
        public string ketQua
        {
            get => _ketQua;
            set => _ketQua = value;
        }
        public int maTrangThai
        {
            get => _maTrangThai;
            set => _maTrangThai = value;
        }
        public int maGiangVien
        {
            get => _maGiangVien;
            set => _maGiangVien = value;
        }
        public DTO_DETAI(int maDeTai,
                            string tenDeTai,
                            string ngayThucHien,
                            string ngayHoanThanh,
                            string linhVuc,
                            string capDo,
                            string ketQua,
                            int maTrangThai,
                            int maGiangVien)
        {
            this.maDeTai = maDeTai;
            this.tenDeTai = tenDeTai;
            this.ngayThucHien = ngayThucHien;
            this.ngayHoanThanh = ngayHoanThanh;
            this.linhVuc = linhVuc;
            this.capDo = capDo;
            this.ketQua = ketQua;
            this.maTrangThai = maTrangThai;
            this.maGiangVien = maGiangVien;
        }
    }
}
