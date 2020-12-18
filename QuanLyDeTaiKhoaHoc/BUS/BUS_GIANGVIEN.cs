using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyDeTaiKhoaHoc.DAL;
namespace QuanLyDeTaiKhoaHoc.BUS
{
    class BUS_GIANGVIEN
    {
        private static BUS_GIANGVIEN instance;
        public static BUS_GIANGVIEN Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUS_GIANGVIEN();
                }
                return instance;
            }
            set { instance = value; }
        }
        private BUS_GIANGVIEN() { }
        public void AddGV()
        {
            DAL_GIANGVIEN.Instance.AddGV();
        }
        public void XoaGV()
        {
            DAL_GIANGVIEN.Instance.XoaGV();
        }
        public void SuaGV()
        {
            DAL_GIANGVIEN.Instance.SuaGV();
        }
    }
}
