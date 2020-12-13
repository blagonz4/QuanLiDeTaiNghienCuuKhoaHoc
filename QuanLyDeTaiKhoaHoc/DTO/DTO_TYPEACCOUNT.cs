using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTaiKhoaHoc.DTO
{
    class DTO_TYPEACCOUNT
    {
        private int _maTypeAccount;
        private string _tenTypeAccount;


        public int maTypeAccount
        {
            get => _maTypeAccount;
            set => _maTypeAccount = value;
        }
        public string tenTypeAccount
        {
            get => _tenTypeAccount;
            set => _tenTypeAccount = value;
        }

        public DTO_TYPEACCOUNT(int maTypeAccount,
                        string tenTypeAccount)
        {
            this.maTypeAccount = maTypeAccount;
            this.tenTypeAccount = tenTypeAccount;
        }
    }
}
