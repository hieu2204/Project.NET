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
    public partial class Function : Form
    {
        #region Properties
        private UserEmployee Employ = new UserEmployee();
        public Connect conn = new Connect();
        public static int id = 1;
        public static List<UserEmployee> useremployees = new List<UserEmployee>();
        public Cipher cipher = new Cipher();
        public Supplier supplier;
        public List<Supplier> suppliers = new List<Supplier>();
        private bool check_Insert_Update = true;
        private static int purchaseOrder_ID = 1;
        private List<PurchaseOrder> purchaseOrder_list = new List<PurchaseOrder>();
        #endregion
        public Function()
        {
            InitializeComponent();
            Console.WriteLine(" tên: " + Static.ten + " " + Static.role);
            lbName.Text = Static.ten;
            lbRole.Text = Static.role;
            PhanQuyen();
            LoadDataGriviewEmployee();
            CountUserID();
            ShowButton(btnTrangChu);
            ShowPanel(pnHome);
            cboDisplaySupplier.SelectedIndex = 0;

            //Product
            CountPurchaseOrderID();
        }
        void ShowButton(Button button)
        {
            foreach(Control control in pnFunction.Controls)
            {
                if(control is Button)
                {
                    control.BackColor = Color.SlateBlue;
                }
            }
            button.BackColor = Color.Pink;
        }
        void ShowPanel(Panel panel)
        {
            foreach(Control control in this.Controls)
            {
                if(control is Panel)
                    control.Visible = false;
            }
            pnFunction.Visible = true;
            panel.Visible = true;
        }
        #region Method Employee
        void LoadDataGriviewEmployee()
        {
            useremployees = conn.GetUser();
            dgvEmployee.DataSource = null;
            dgvEmployee.DataSource = useremployees;
        }
        private void PhanQuyen()
        {
            if (Static.role == "Employee")
                btnQuanLyNhanVien.Enabled = false;
        }
        void Refeshtext()
        {
            txtUser.Text = "";
            txtPassword.Text = "";
            txtName.Text = "";
            txtBirthday.Text = "";
            cboGender.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }
        void CountUserID()
        {
            useremployees = conn.GetUser();
            if (useremployees.Count > 0)
            {
                id = useremployees.Max(user => user.UserID) + 1;
            }
            else
                id = 1;
            Console.WriteLine("id:" + id);
            txtUserID.Text = id.ToString();
        }
        bool CheckAdd()
        {
            if (string.IsNullOrEmpty(txtUser.Text))
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
        #region Method Supplier
        void LoadDataGridViewSupplier()
        {
            List<Supplier> suppliers = new List<Supplier>();
            suppliers = conn.getSupplier();
            dgvSupplier.DataSource = null;
            dgvSupplier.DataSource = suppliers;
        }
        void RefreshSupplier()
        {
            txtSupplierID.Text = "";
            txtSupplierName.Text = "";
            txtSupplierEmail.Text = "";
            txtSupplierPhone.Text = "";
            cboStatusSupplier.Text = cboStatusSupplier.Items[0].ToString();
        }
        #endregion
        #region Method Product
        void CountPurchaseOrderID()
        {
            purchaseOrder_list = conn.GetPurchaseOrders();
            if(purchaseOrder_list != null && purchaseOrder_list.Any())
            {
                purchaseOrder_ID = purchaseOrder_list.Max(purchaseOrder_ID => purchaseOrder_ID.PurchaseOrderID) + 1;
            }
            else
            {
                purchaseOrder_ID = 1;
            }
            txtPurchaseOrderID.Text = purchaseOrder_ID.ToString();
        }

        #endregion
        #region Envent Employee
        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            ShowButton(btnQuanLyNhanVien);
            ShowPanel(pnManagerEmployee);
        }
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            ShowPanel(pnHome);
            ShowButton(btnTrangChu);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowPanel(pnAddProduct);
            ShowButton(btnQuanLyNhanVien);
            Employ = null;
            txtUser.Focus();
            pnInsertUpdateEmployee.Visible = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ShowButton(btnQuanLyNhanVien);
            ShowPanel(pnManagerEmployee);
            pnInsertUpdateEmployee.Visible = true;
            if (CheckAdd())
            {
                if(Employ != null)
                {
                    int Id = Employ.UserID;
                    string user = txtUser.Text;
                    string password = txtPassword.Text;
                    string name = txtName.Text;
                    string role = txtRole.Text;
                    string gender = cboGender.Text;
                    string birthday = txtBirthday.Text;
                    string address = txtAddress.Text;
                    string phone = txtPhone.Text;
                    string email = txtEmail.Text;
                    if (password.Equals(Employ.Password))
                        conn.UpdateUser(Id, user, password, name, role, gender, birthday, address, phone, email);
                    else
                    {
                        conn.UpdateUser(Id, user, cipher.HashPassword(password), name, role, gender, birthday, address, phone, email);
                    }
                    useremployees = conn.GetUser();
                    MessageBox.Show("Update successful!", "Thông báo");
                    LoadDataGriviewEmployee();
                }
                else
                {
                    conn.insertEmployee(id, txtUser.Text, cipher.HashPassword(txtPassword.Text), txtName.Text, txtRole.Text, cboGender.Text, txtBirthday.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text);
                    MessageBox.Show("Insert successful!", "Thông báo");
                    LoadDataGriviewEmployee();
                    btnQuanLyNhanVien.BackColor =  Color.Pink;
                    pnManagerEmployee.Visible = true;
                    Refeshtext();
                    CountUserID();
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShowPanel(pnManagerEmployee);
            ShowButton(btnQuanLyNhanVien);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dgvEmployee.SelectedRows.Count > 0 && dgvEmployee.SelectedRows.Count > 0)
            {
                // Lấy chỉ số của hàng được chọn đầu tiên
                int selectedRowIndex = dgvEmployee.SelectedRows[0].Index;
                // Kiểm tra chỉ số hàng có hợp lệ không
                if (selectedRowIndex >= 0 && selectedRowIndex < dgvEmployee.Rows.Count)
                {
                    // Lấy ID của người dùng trước khi xóa hàng
                    int ID = int.Parse(dgvEmployee.Rows[selectedRowIndex].Cells[0].Value.ToString());
                    // Hỏi người dùng có muốn xóa không
                    if (MessageBox.Show("Bạn có muốn xóa không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        useremployees.RemoveAt(selectedRowIndex);
                        // Xóa người dùng từ cơ sở dữ liệu
                        conn.DeleteUser(ID);
                        LoadDataGriviewEmployee();
                        CountUserID();
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa!", "Thông báo");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Employ != null) // Check if Employ is not null
            {
                txtUserID.Text = Employ.UserID.ToString();
                txtUser.Text = Employ.User;
                txtPassword.Text = Employ.Password;
                txtName.Text = Employ.Name;
                txtRole.Text = Employ.Role;
                cboGender.SelectedItem = Employ.Gender;
                txtBirthday.Text = Employ.Birthday;
                txtAddress.Text = Employ.Address;
                txtPhone.Text = Employ.Phone;
                txtEmail.Text = Employ.Email;
                pnHome.Visible = false;
                pnManagerEmployee.Visible = false;
                pnInsertUpdateEmployee.Visible = true;
                txtUser.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để update!", "Thông báo");
            }

        }
        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmployee.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dgvEmployee.SelectedRows[0].Index;
                if (selectedRowIndex >= 0 && selectedRowIndex < dgvEmployee.Rows.Count)
                {
                    Employ = new UserEmployee(
                        int.Parse(dgvEmployee.Rows[selectedRowIndex].Cells[0].Value.ToString()),
                        dgvEmployee.Rows[selectedRowIndex].Cells[1].Value.ToString(),
                        dgvEmployee.Rows[selectedRowIndex].Cells[2].Value.ToString(),
                        dgvEmployee.Rows[selectedRowIndex].Cells[3].Value.ToString(),
                        dgvEmployee.Rows[selectedRowIndex].Cells[4].Value.ToString(),
                        dgvEmployee.Rows[selectedRowIndex].Cells[5].Value.ToString(),
                        dgvEmployee.Rows[selectedRowIndex].Cells[6].Value.ToString(),
                        dgvEmployee.Rows[selectedRowIndex].Cells[7].Value.ToString(),
                        dgvEmployee.Rows[selectedRowIndex].Cells[8].Value.ToString(),
                        dgvEmployee.Rows[selectedRowIndex].Cells[9].Value.ToString());
                }
            }
            else
            {
                Employ = null;
                MessageBox.Show("Vui lòng chọn một hàng để update!", "Thông báo");
            }
        }
        #endregion
        
        private void btnQuanLyNhaCungCap_Click(object sender, EventArgs e)
        {
            LoadDataGridViewSupplier();
            ShowPanel(pnSupplier);
            ShowButton(btnQuanLyNhaCungCap);
            cboStatusSupplier.SelectedIndex = 0;
        }

        #region Event Supplier
        private void pnSupplier_Paint(object sender, PaintEventArgs e)
        {

        }
        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu chỉ mục dòng hợp lệ
            if (e.RowIndex >= 0 && e.RowIndex < dgvSupplier.Rows.Count)
            {
                supplier = new Supplier(
                    dgvSupplier.Rows[e.RowIndex].Cells[0].Value.ToString(),
                    dgvSupplier.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    dgvSupplier.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    dgvSupplier.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    dgvSupplier.Rows[e.RowIndex].Cells[4].Value.ToString()
                );
                Console.WriteLine("id Supplier: " + supplier.SupplierID);
            }
            else
            {
                supplier = null;
                Console.WriteLine("Error");
            }
        }
        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            check_Insert_Update = true;
            if(supplier == null)
            {
                MessageBox.Show("Vui lòng chọn 1 hàng để Update!", "Thông báo");
                btnUpdateSupplier.Enabled = true;

            }
            else
            {
                txtSupplierID.Enabled = false;
                cboStatusSupplier.Enabled = true;
                txtSupplierID.Text = supplier.SupplierID;
                txtSupplierName.Text = supplier.SupplierName;
                txtSupplierEmail.Text = supplier.Email;
                txtSupplierPhone.Text = supplier.Phone;
                cboStatusSupplier.Text = supplier.Status;
                btnUpdateSupplier.Enabled = true;
            }
            btnAddSupplier.Enabled = false;
            btnDeleteSupplier.Enabled = false;
            
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            RefreshSupplier();
            //cboStatusSupplier.Text = cboStatusSupplier.Items[0].ToString();
            cboStatusSupplier.Enabled = false;
            btnDeleteSupplier.Enabled = false;
            btnUpdateSupplier.Enabled = false;
            btnAddSupplier.Enabled = false;
            check_Insert_Update = false;
        }
        #endregion

        private void btnSaveSupplier_Click(object sender, EventArgs e)
        {
            if(!check_Insert_Update)
            {
                conn.InsertSupplier(txtSupplierID.Text, txtSupplierName.Text, txtSupplierEmail.Text, txtSupplierPhone.Text, cboStatusSupplier.Text);
                MessageBox.Show("Insert successful!", "Thông báo");
            }
            else
            {
                conn.UpdateSupplier(txtSupplierID.Text, txtSupplierName.Text, txtSupplierEmail.Text, txtSupplierPhone.Text, cboStatusSupplier.Text);
                MessageBox.Show("Update successful!", "Thông báo");
            }
            LoadDataGridViewSupplier();
        }
        private void btnCancelSupplier_Click(object sender, EventArgs e)
        {
            btnAddSupplier.Enabled = true;
            btnSaveSupplier.Enabled = true;
            btnDeleteSupplier.Enabled = true;
            btnUpdateSupplier.Enabled = true;
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            txtSupplierID.Text = supplier.SupplierID;
            txtSupplierName.Text = supplier.SupplierName;
            txtSupplierEmail.Text = supplier.Email;
            txtSupplierPhone.Text = supplier.Phone;
            cboStatusSupplier.Text = supplier.Status;
            if(MessageBox.Show("Bạn có muốn ngưng hợp tác không!", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                conn.UpdateSupplier(txtSupplierID.Text, "Ngưng hợp tác");
                MessageBox.Show("Ngưng hợp tác thành công!", "Thông báo");
                LoadDataGridViewSupplier();
            }
        }

        private void cboDisplaySupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStatus = cboDisplaySupplier.SelectedItem.ToString();
            if(selectedStatus == "Tất cả")
                LoadDataGridViewSupplier();
            else if(selectedStatus == "Hợp tác")
            {
                suppliers = conn.getSupplierHopTac(selectedStatus);
                dgvSupplier.DataSource = null;
                dgvSupplier.DataSource = suppliers;
            }
            else
            {
                suppliers = conn.getSupplierNgungHopTac(selectedStatus);
                dgvSupplier.DataSource = null;
                dgvSupplier.DataSource = suppliers;
            }
        }

        private void btnNhapSanPham_Click(object sender, EventArgs e)
        {
            ShowPanel(pnAddProduct);
            ShowButton(btnNhapSanPham);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            pnAddProduct.Visible = true;
            ShowPanel(pnPurchaseOrderDetail);
            ShowButton(btnNhapSanPham);
            //pnPurchaseOrderDetail.Visible = true;
            cboListSupplier.DataSource = null;
            cboListSupplier.DataSource = conn.getSupplierHopTac("Hợp tác");
        }

        private void btnAddOrderDetail_Click(object sender, EventArgs e)
        {
            txtPurchaseOrderID.Text = purchaseOrder_ID.ToString();
            txtUserEmploy.Text = Static._id.ToString();

        }
    }
}
