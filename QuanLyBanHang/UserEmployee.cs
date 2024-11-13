using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    public class UserEmployee
    {
        private int userid;
        private string username;
        private string password;
        private string name;
        private string role;
        private string gender;
        private string birthday;
        private string address;
        private string email;
        private string phone;
        //private List<UserEmployee> useremployees = new List<UserEmployee>();
        public UserEmployee()
        {

        }
        public UserEmployee(int userid, string username,string password,string name, string role,string gender,string birth,string address,string phone,string email)
        {
            this.userid = userid;
            this.username = username;
            this.password = password;
            this.name = name;
            this.role = role;
            this.gender = gender;
            this.Birthday = birth;
            this.Address = address;
            this.phone = phone;
            this.Email = email;
        }
        public int UserID
        {
            get { return userid; }
            set { userid = value; }
        }
        public string User
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        public string Gender { get { return gender; } set { gender = value; } }
        public string Birthday { get { return birthday; } set { birthday = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public string Email { get { return email; } set { email = value; } }


        //public List<UserEmployee> getEmployee()
        //{
        //    return useremployees;
        //}
    }
}
