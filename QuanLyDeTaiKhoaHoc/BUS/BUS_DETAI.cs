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

        public int GetnextID()
        {
            return DAL_DETAI.Instance.GetNextID();
        }
    }
}
