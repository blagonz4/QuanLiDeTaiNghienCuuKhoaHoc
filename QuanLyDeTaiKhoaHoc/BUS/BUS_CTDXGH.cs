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
    class BUS_CTDXGH
    {
        private static BUS_CTDXGH _instance;
        public static BUS_CTDXGH Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_CTDXGH();
                return _instance;
            }
        }


        private BUS_CTDXGH() { }


        public DataTable GetListCTDXGH()
        {
            return DAL_CTDXGH.Instance.LoadListCTDXGH();
        }
    }
}
