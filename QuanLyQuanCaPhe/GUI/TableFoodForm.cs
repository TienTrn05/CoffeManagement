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
    public partial class TableFoodForm: Form
    {
        public TableFoodForm()
        {
            InitializeComponent();
        }
        private void LoadDataSource()
        {
            dgvTable.DataSource = TableBLL.Instance.GetTableFoods()
                .Select(t => new
                {
                    IdTable = t.IdTable,
                    NameTable = t.NameTable,
                    StatusTable = t.StatusTable 
                }).ToList();

            dgvTable.Columns[0].HeaderText = "ID";
            dgvTable.Columns[1].HeaderText = "Tên bàn";
            dgvTable.Columns[2].HeaderText = "Trạng thái bàn";
        }

        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }

        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }

        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên bàn không được để trống", "Bàn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (TableBLL.Instance.AddTable(txtName.Text))
            {
                MessageBox.Show("Thêm thành công", "Bàn", MessageBoxButtons.OK, MessageBoxIcon.Question);
                LoadDataSource();
                if (insertTable != null)
                    insertTable(this, new EventArgs());
            }
            else MessageBox.Show("Thêm thất bại", "Bàn", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (TableBLL.Instance.UpdateTable(Convert.ToInt32(txtID.Text), txtName.Text))
            {
                MessageBox.Show("Cập nhật thành công", "Bàn", MessageBoxButtons.OK, MessageBoxIcon.Question);
                LoadDataSource();
                if (updateTable != null)
                    updateTable(this, new EventArgs());
            }
            else MessageBox.Show("Cập nhật thất bại", "Bàn", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedRows[0].Cells[2].Value.ToString() == "Có người")
            {
                MessageBox.Show("Bạn không thể có bàn đang có khách", "Bàn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (TableBLL.Instance.DeleteTable(Convert.ToInt32(txtID.Text)))
            {
                MessageBox.Show("Xoá thành công", "Bàn", MessageBoxButtons.OK, MessageBoxIcon.Question);
                LoadDataSource();
                if (updateTable != null)
                    updateTable(this, new EventArgs());
            }
            else MessageBox.Show("Xoá thất bại", "Bàn", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataSource();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTable.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvTable.SelectedRows[0];
                txtID.Text = row.Cells["IdTable"].Value.ToString();
                txtName.Text = row.Cells["NameTable"].Value.ToString();
                ckbStatusTable.Checked = (row.Cells["StatusTable"].Value.ToString() == "Có người");
            }
        }

        private void dgvTable_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

        private void TableFoodForm_Load(object sender, EventArgs e)
        {
            LoadDataSource();
        }

        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbreload_Click(object sender, EventArgs e)
        {
            LoadDataSource();
        }
    }
}
