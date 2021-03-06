﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using QuanLyDeTaiKhoaHoc.GUI;
using QuanLyDeTaiKhoaHoc.BUS;
using QuanLyDeTaiKhoaHoc.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace QuanLyDeTaiKhoaHoc.DAL
{
    class DAL_HOPDONG
    {
        private static DAL_HOPDONG instance;

        public static DAL_HOPDONG Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_HOPDONG();
                }
                return instance;
            }
            set { instance = value; }
        }


        public DataTable LoadListHOPDONG()
        {
            Form main = Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "";
            LoadQuery += "SELECT * FROM HOPDONG";
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }
    }
}
