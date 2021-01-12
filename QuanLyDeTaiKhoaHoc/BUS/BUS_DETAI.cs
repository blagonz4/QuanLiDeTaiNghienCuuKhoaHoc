using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyDeTaiKhoaHoc.DAL;
using System.Data;
using System.Data.SqlClient;
namespace QuanLyDeTaiKhoaHoc.BUS
{
    class BUS_DETAI
    {
        private static BUS_DETAI _instance;
        public static BUS_DETAI Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_DETAI();
                return _instance;
            }
        }
        private BUS_DETAI() { }
        public DataTable GetListDeTai()
        {
            return DAL_DETAI.Instance.LoadListDeTai();
        }
        public void AddDeTai()
        {
            DAL_DETAI.Instance.AddDeTai();
        }
        public void XoaDeTai()
        {
            DAL_DETAI.Instance.XoaDeTai();
        }
        public DataTable GetListDeTaiChoDuyet()
        {
            return DAL_DETAI.Instance.LoadListDeTaiChoDuyet();
        }
        public void DuyetDeTai()
        {
            DAL_DETAI.Instance.DuyetDeTai();
        }
        public void SuaDeTai()
        {
            DAL_DETAI.Instance.SuaDeTai();
        }
        public int GetnextID()
        {
            return DAL_DETAI.Instance.GetNextID();
        }

        public void Updateketqua(string ketQua)
        {
            DAL_DETAI.Instance.Updateketqua(ketQua);
        }
        public void AddHoiDong()
        {
            DAL_DETAI.Instance.AddHoiDong();
        }
        public DataTable GetListHoiDong()
        {
            return DAL_DETAI.Instance.LoadListPhanCong();
        }
        public bool GetError()
        {
            return DAL_DETAI.Instance.GetError();
        }
        public DataTable BaoCaoNamKhoa()
        {
            return DAL_DETAI.Instance.BaoCaoNamKhoa();
        }
        public DataTable BaoCaoLoai()
        {
            return DAL_DETAI.Instance.BaoCaoLoai();
        }
        public DataTable BaoCaoTinhTrang()
        {
            return DAL_DETAI.Instance.BaoCaoTinhTrang();
        }
        public DataTable BaoCaoLinhVuc()
        {
            return DAL_DETAI.Instance.BaoCaoLinhVuc();
        }
        public DataTable BaoCaoGiangVienThucHienDeTai()
        {
            return DAL_DETAI.Instance.BaoCaoGiangVienThucHienDeTai();
        }
        public DataTable BaoCaoChiTiet()
        {
            return DAL_DETAI.Instance.BaoCaoChiTiet();
        }
    }
}
