using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class Login : Form
    {
        public List<UserEmployee> useremployees = new List<UserEmployee>();
        public static int id = 1;
        public Connect conn = new Connect();
        public Cipher cipher = new Cipher();

        public Login()
        {
            InitializeComponent();
            //txtUser.Focus();
            useremployees = conn.GetUser();
            CountUserID();
            pnDangKy.Visible = false;
            pnBackGroupLogin.Visible = true;
            pnLogin.Visible = true;
        }
        #region Method
        void CountUserID()
        {
            if (useremployees.Count > 0)
            {
                id = useremployees.Max(user => user.UserID) + 1;
            }
            else
                id = 1;
            Console.WriteLine("id:" + id);
            //txtUserID.Text = id.ToString();
        }
        private bool CheckLogin()
        {
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản!", "Cảnh báo");
                txtUser.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Cảnh báo");
                txtPass.Focus();
                return false;
            }
            Console.WriteLine("Tên đăng nhập nhập vào: " + txtUser.Text);
            Console.WriteLine("Mật khẩu mã hóa nhập vào: " + cipher.HashPassword(txtPass.Text));

            foreach (UserEmployee user in useremployees)
            {
                Console.WriteLine("user: " + user.User + "pass: " + user.Password);
                if ((txtUser.Text == user.User) && (cipher.HashPassword(txtPass.Text) == user.Password))
                {
                    Static.ten = user.Name;
                    Static.role = user.Role;
                    Static._id = user.UserID;
                    return true;
                }
            }
            MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Thông báo");
            return false;
        }
        bool CheckAdd()
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Tài khoản không được để trống!", "Thông báo");
                txtUser.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Thông báo");
                txtPassword.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên không được để trống!", "Thông báo");
                txtName.Focus();
                return false;
            }
            //string genderText = cboGender.Text;

            //foreach (var item in cboGender.Items)
            //{
            //    if (!item.ToString().Equals(genderText, StringComparison.OrdinalIgnoreCase))
            //    {
            //        MessageBox.Show("Giới tính không hợp lệ!\nVui lòng chọn giới tính!", "Thông báo");
            //        cboGender.Focus();
            //        return false;
            //    }
            //    else
            //        return true;
            //}
            string genderText = cboGender.Text;
            bool genderValid = false;

            // Kiểm tra giới tính có hợp lệ không
            foreach (var item in cboGender.Items)
            {
                if (item.ToString().Equals(genderText, StringComparison.OrdinalIgnoreCase))
                {
                    genderValid = true;
                    break;
                }
            }

            if (!genderValid)
            {
                MessageBox.Show("Giới tính không hợp lệ!\nVui lòng chọn giới tính!", "Thông báo");
                cboGender.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtBirthday.Text))
            {
                MessageBox.Show("Ngày sinh không được để trống!", "Thông báo");
                txtBirthday.Focus();
                return false;
            }
            DateTime birthday;
            bool isValidate = DateTime.TryParse(txtBirthday.Text, out birthday);
            if (!isValidate)
            {
                MessageBox.Show("Ngày sinh không hợp lệ!\nVui lòng nhập đúng định dạng yyyy-MM-dd!", "Thông báo!");
                txtBirthday.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống!", "Thông báo");
                txtAddress.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email không được để trống!", "Thông báo");
                txtEmail.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Thông báo");
                txtPhone.Focus();
                return false;
            }

            return true;
        }

        #endregion
        #region Event
        private void Click_DangKy(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnBackGroupLogin.Visible = true;
            pnLogin.Visible = true;
            pnDangKy.Visible = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (CheckLogin())
            {
                this.Hide();
                Function frmFunction = new Function();
                frmFunction.ShowDialog();
                this.Close();
            }
        }


        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if(CheckAdd())
            {
                conn.insertEmployee(id, txtUserName.Text, cipher.HashPassword(txtPassword.Text), txtName.Text, txtRole.Text, cboGender.SelectedItem.ToString(), txtBirthday.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text);
                CountUserID();
                MessageBox.Show("Đăng ký thành công!", "Thông báo");
                pnBackGroupLogin.Visible = true; pnLogin.Visible = true;
                pnDangKy.Visible = false;
                useremployees = conn.GetUser();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không!", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //Application.Exit();
                pnBackGroupLogin.Visible = true; pnLogin.Visible = true;
                pnDangKy.Visible = false;
        }
        #endregion
    }
}
