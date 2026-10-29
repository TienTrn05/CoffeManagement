using QuanLyQuanCaPhe.BLL;
using QuanLyQuanCaPhe.Security;
using System;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.View
{
    public partial class AccountProfileForm : Form
    {
        public Account LoginAccount { get; set; }

        public AccountProfileForm(Account loginAccount)
        {
            InitializeComponent();
            LoginAccount = loginAccount;
            txtUsername.Text = LoginAccount.Username;
            txtDisplayName.Text = LoginAccount.DisplayName;
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text != txtEnterPassword.Text)
            {
                MessageBox.Show("Mật khẩu mới không khớp", "Thông tin tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtUsername.Text;
            string displayName = txtDisplayName.Text;
            string password = txtPassword.Text;
            string newPassword = txtNewPassword.Text;

            if (AccountBLL.Instance.UpdateAccount(username, password, newPassword, displayName))
            {
                MessageBox.Show("Cập nhật thành công", "Thông tin tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                updateAccount?.Invoke(this, new AccountEvent(AccountBLL.Instance.GetAccountByUsername(username)));
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại", "Thông tin tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class AccountEvent : EventArgs
    {
        public AccountEvent(Account loginAcc)
        {
            LoginAcc = loginAcc;
        }

        public Account LoginAcc { get; set; }
    }
}
