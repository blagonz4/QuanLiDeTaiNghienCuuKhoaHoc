using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
