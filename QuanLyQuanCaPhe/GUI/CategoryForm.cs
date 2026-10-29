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
    public partial class CategoryForm: Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }


        private void LoadDataSource()
        {
            dgvCategory.DataSource = CategoryBLL.Instance.GetTable()
                .Select(c => new
                {
                    IdCategory = c.IdCategory,
                    NameCategory = c.NameCategory
                }).ToList();
            dgvCategory.Columns[0].HeaderText = "ID";
            dgvCategory.Columns[1].HeaderText = "Tên danh mục";
        }

        private event EventHandler insertCategory;
        public event EventHandler InsertCategory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }

        private event EventHandler updateCategory;
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }

        private event EventHandler deleteCategory;
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
        }

        private void dgvCategory_DataSourceChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategory.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvCategory.SelectedRows[0];
                txtID.Text = row.Cells["IdCategory"].Value.ToString();
                txtName.Text = row.Cells["NameCategory"].Value.ToString();
            }
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadDataSource();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvCategory.DataSource = CategoryBLL.Instance.SearchCategories(txtSearch.Text)
                .Select(c => new
                {
                    IdCategory = c.IdCategory,
                    NameCategory = c.NameCategory
                }).ToList();
            if (dgvCategory.RowCount == 0)
                MessageBox.Show("Không tìm thấy kết quả phù hợp với từ khoá '" + txtSearch.Text + "' này", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CategoryBLL.Instance.UpdateCategory(Convert.ToInt32(txtID.Text), txtName.Text))
            {
                MessageBox.Show("Cập nhật thành công", "Danh mục", MessageBoxButtons.OK, MessageBoxIcon.Question);
                LoadDataSource();
                if (updateCategory != null)
                    updateCategory(this, new EventArgs());
            }
            else MessageBox.Show("Cập nhật thất bại", "Danh mục", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Khi bạn nhấn OK thì tất cả thức uống thuộc danh mục này sẽ bị sẽ xoá theo", "Danh mục", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                if (CategoryBLL.Instance.DeleteCategory(Convert.ToInt32(txtID.Text)))
                {
                    MessageBox.Show("Xoá thành công", "Danh mục", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    LoadDataSource();
                    if (deleteCategory != null)
                        deleteCategory(this, new EventArgs());
                }
                else MessageBox.Show("Xoá thất bại", "Danh mục", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataSource();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên danh mục không được để trống", "Danh mục", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CategoryBLL.Instance.InsertCategory(txtName.Text))
            {
                MessageBox.Show("Thêm thành công", "Danh mục", MessageBoxButtons.OK, MessageBoxIcon.Question);
                LoadDataSource();
                if (insertCategory != null)
                    insertCategory(this, new EventArgs());
            }
            else MessageBox.Show("Thêm thất bại", "Danh mục", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
