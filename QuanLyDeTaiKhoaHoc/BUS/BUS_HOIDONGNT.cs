﻿using System;
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
    class BUS_HOIDONGNT
    {
        private static BUS_HOIDONGNT _instance;
        public static BUS_HOIDONGNT Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_HOIDONGNT();
                return _instance;
            }

        }


        private BUS_HOIDONGNT() { }

        public DataTable GetListHOIDONGNT()
        {
            return DAL_HOIDONGNT.Instance.LoadListHOIDONGNT();
        }

        public void XoaHD()
        {
            DAL_HOIDONGNT.Instance.Xoa();
        }

        public void ThemHD()
        {
            DAL_HOIDONGNT.Instance.Add();
        }

        public void SuaHD()
        {
            DAL_HOIDONGNT.Instance.Sua();
        }
        public int GetNextID()
        {
            return DAL_HOIDONGNT.Instance.GetNextID();
        }
        public DataTable BaoCaoThanhVien()
        {
            return DAL_HOIDONGNT.Instance.BaoCaoThanhVien();
        }
    }
}
