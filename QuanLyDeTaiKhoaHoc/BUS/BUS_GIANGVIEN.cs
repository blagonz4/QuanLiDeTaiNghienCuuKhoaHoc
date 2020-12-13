using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTaiKhoaHoc.BUS
{
    class BUS_GIANGVIEN
    {
        private static BUS_GIANGVIEN _instance;
        public static BUS_GIANGVIEN Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_GIANGVIEN();
                return _instance;
            }
        }
    }
}
