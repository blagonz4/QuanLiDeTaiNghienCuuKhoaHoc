using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
