using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTaiKhoaHoc.DTO
{
    class DTO_GIANGVIEN
    {
        private int _maGiangVien;
        private string _tenGiangVien;
        private string _Nganh;
        private int _maHopDong;
        private int _maAccount;
        private int _maKhoa;

        public int maGiangVien
        {
            get => _maGiangVien;
            set => _maGiangVien = value;
        }
        public string tenGiangVien
        {
            get => _tenGiangVien;
            set => _tenGiangVien = value;
        }
        public string Nganh
        {
            get => _Nganh;
            set => _Nganh = value;
        }
        public int maHopDong
        {
            get => _maHopDong;
            set => _maHopDong = value;
        }
        public int maAccount
        {
            get => _maAccount;
            set => _maAccount = value;
        }
        public int maKhoa
        {
            get => _maKhoa;
            set => _maKhoa = value;
        }
        public DTO_GIANGVIEN(int maGiangVien,
                            string tenGiangVien,
                            string Nganh,
                            int maHopDong,
                            int maAccount,
                            int maKhoa)
        {
            this.maGiangVien = maGiangVien;
            this.tenGiangVien = tenGiangVien;
            this.Nganh = Nganh;
            this.maHopDong = maHopDong;
            this.maAccount = maAccount;
            this.maKhoa = maKhoa;
        }
    }
}
