using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTaiKhoaHoc.BUS
{
    class BUS_TYPEACCOUNT
    {
        private static BUS_TYPEACCOUNT _instance;
        public static BUS_TYPEACCOUNT Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_TYPEACCOUNT();
                return _instance;
            }
        }
    }
}
