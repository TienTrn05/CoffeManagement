using QuanLyQuanCaPhe.BLL;
using QuanLyQuanCaPhe.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe
{
    public partial class Login: Form
    {
        public Login()
        {
            
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắn chắn muốn thoát không?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
                this.Close();
        }


        private void Loginn()
        {
           
            if (AccountBLL.Instance.IsLoginValid(txtUsername.Text, txtPassword.Text))
            {
                Account accs = AccountBLL.Instance.GetAccountByUsername(txtUsername.Text);
                Main main = new Main(accs);
                this.Hide();
                main.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Loginn();
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Loginn();
        }

        private void cbshowpass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar =!cbshowpass.Checked;
        }
    }
}
