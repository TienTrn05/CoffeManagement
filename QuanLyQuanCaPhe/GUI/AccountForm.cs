using QuanLyQuanCaPhe.BLL;
using QuanLyQuanCaPhe.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.View
{
    public partial class AccountForm : Form
    {
        public Account LoginAccount { get; set; }

        public AccountForm(Account loginAccount)
        {
            InitializeComponent();
            LoginAccount = loginAccount;
            LoadDataSource();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            LoadDataSource();
        }

        private void LoadDataSource()
        {
            dgvAccount.DataSource = AccountBLL.Instance.GetAllAccounts()
                .Select(a => new
                {
                    a.Username,
                    a.DisplayName,
                    a.Access
                })
                .ToList();
            dgvAccount.Columns[0].HeaderText = "Tên đăng nhập";
            dgvAccount.Columns[1].HeaderText = "Tên hiển thị";
            dgvAccount.Columns[2].HeaderText = "Quyền truy cập";

        }

        private event EventHandler insertAccount;
        public event EventHandler InsertAccount
        {
            add { insertAccount += value; }
            remove { insertAccount -= value; }
        }

        private event EventHandler updateAccount;
        public event EventHandler UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        private event EventHandler deleteAccount;
        public event EventHandler DeleteAccount
        {
            add { deleteAccount += value; }
            remove { deleteAccount -= value; }
        }

     

        private void btnAdd_Click(object sender, EventArgs e)
        {

           if(string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtDisplayName.Text) || string.IsNullOrWhiteSpace(cboAccess.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (AccountBLL.Instance.InsertAccount(txtUsername.Text, txtDisplayName.Text, cboAccess.Text))
            {
                MessageBox.Show("Thêm thành công", "Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataSource();
                insertAccount?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           

            if (AccountBLL.Instance.EditAccount(txtUsername.Text, txtDisplayName.Text, cboAccess.Text))
            {
                MessageBox.Show("Cập nhật thành công", "Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataSource();
                updateAccount?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại", "Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (LoginAccount.Username == txtUsername.Text)
            {
                MessageBox.Show("Bạn không thể xoá tài khoản đang đăng nhập", "Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (AccountBLL.Instance.DeleteAccount(txtUsername.Text))
            {
                MessageBox.Show("Xoá thành công", "Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataSource();
                deleteAccount?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Xoá thất bại", "Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataSource();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAccount.SelectedRows.Count > 0)
            {
                var row = dgvAccount.SelectedRows[0];
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtDisplayName.Text = row.Cells["DisplayName"].Value.ToString();
                cboAccess.Text = row.Cells["Access"].Value.ToString();
            }
        }

        private void lbreload_Click(object sender, EventArgs e)
        {
            LoadDataSource();
        }
    }
}
