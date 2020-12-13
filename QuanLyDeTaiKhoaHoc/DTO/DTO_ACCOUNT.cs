using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTaiKhoaHoc.DTO
{
    class DTO_ACCOUNT
    {
        private int _maAccount;
        private string _tenAccount;
        private string _Email;
        private string _password;
        private string _Phone;
        private int _maTypeAccount;

        public int maAccount
        {
            get => _maAccount;
            set => _maAccount = value;
        }
        public string tenAccount
        {
            get => _tenAccount;
            set => _tenAccount = value;
        }
        public string Email
        {
            get => _Email;
            set => _Email = value;
        }
        public string password
        {
            get => _password;
            set => _password = value;
        }
        public string Phone
        {
            get => _Phone;
            set => _Phone = value;
        }
        public int maTypeAccount
        {
            get => _maTypeAccount;
            set => _maTypeAccount = value;
        }
        public DTO_ACCOUNT(int maAccount, 
                            string name, 
                            string email, 
                            string password, 
                            string Phone, 
                            int maTypeAccount)
        {
            this.maAccount = maAccount;
            this.tenAccount = name;
            this.Email = email;
            this.password = password;
            this.Phone = Phone;
            this.maTypeAccount = maTypeAccount;
        }
    }
}
