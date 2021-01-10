using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyDeTaiKhoaHoc.GUI;
using QuanLyDeTaiKhoaHoc.BUS;
using QuanLyDeTaiKhoaHoc.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyDeTaiKhoaHoc.DAL;


namespace QuanLyDeTaiKhoaHoc.BUS
{
    class BUS_DONXINGIAHAN
    {
        private static BUS_DONXINGIAHAN _instance;
        public static BUS_DONXINGIAHAN Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_DONXINGIAHAN();
                return _instance;
            }
        }

        private BUS_DONXINGIAHAN() { }


        public DataTable GetListDXGH()
        {
            return DAL_DONXINGIAHAN.Instance.LoadListDXGH();
        }
        public void DuyetGiaHan()
        {
            DAL_DONXINGIAHAN.Instance.DuyetGiaHan();
        }
        public void GiaHanDeTai()
        {
            DAL_DONXINGIAHAN.Instance.GiaHanDeTai();
        }
        public void SetTrangThaiGiaHan()
        {
            DAL_DONXINGIAHAN.Instance.SetTrangThaiGiaHan();
        }
        public void UpdateNgayHoanThanh()
        {
            DAL_DONXINGIAHAN.Instance.UpdateNgayHoanThanh();
        }

        public int GetnextID()
        {
            return DAL_DONXINGIAHAN.Instance.GetNextID();
        }

    }
}
