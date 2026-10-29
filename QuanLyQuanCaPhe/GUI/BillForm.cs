using QuanLyQuanCaPhe.BLL;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.View
{
    public partial class BillForm: Form
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public BillForm()
        {
            InitializeComponent();
            
        }

        private void Bill_Load(object sender, EventArgs e)
        {

          btnFirstPage.Enabled = btnPrevPage.Enabled =
          btnNextPage.Enabled = btnLastPage.Enabled = false;
            ShowBillByDateAndPage();
        }

        private void ShowBillByDateAndPage()
        {
            txtCurrentPage.Text = CurrentPage + "/" + TotalPage;
            dgvBill.DataSource = BillBLL.Instance.GetBillByDateAndPage( CurrentPage)
                .Select(b => new
                {
                    b.IdBill,
                    b.DateCheckInBill,
                    b.DateCheckOutBill,
                    b.StatusBill,
                    b.Discount,
                    b.TotalPrice,
                    b.IdTable
                })
                .ToList();
        }

        private void ChangeEnabledOfButtons()   
        {
            btnFirstPage.Enabled = btnPrevPage.Enabled = true;
            btnLastPage.Enabled = btnNextPage.Enabled = true;

            if (CurrentPage == 1)
                btnFirstPage.Enabled = btnPrevPage.Enabled = false;
            if (CurrentPage == TotalPage)
                btnLastPage.Enabled = btnNextPage.Enabled = false;
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            ShowBillByDateAndPage();
            ChangeEnabledOfButtons();
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
            ShowBillByDateAndPage();
            ChangeEnabledOfButtons();
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {   
            CurrentPage--;
            ShowBillByDateAndPage();
            ChangeEnabledOfButtons();
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            CurrentPage = TotalPage;
            ShowBillByDateAndPage();    
            ChangeEnabledOfButtons();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStatistical_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
            TotalPage = (int)Math.Ceiling(BillBLL.Instance.GetTotalBillCount() / 10.0);
            ShowBillByDateAndPage();
            ChangeEnabledOfButtons();
        }
    }
}
