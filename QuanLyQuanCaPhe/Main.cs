        using Guna.UI2.WinForms;
        using QuanLyQuanCaPhe.BLL;

        using QuanLyQuanCaPhe.View;
        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Globalization;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Web.UI.WebControls;
        using System.Windows.Forms;
        using Image = System.Drawing.Image;

namespace QuanLyQuanCaPhe
        {
            public partial class Main: Form
            {
                public Account LoginAccount { get; set; }
                public Main(Account loginAccount)
                {
                    InitializeComponent();
                    LoginAccount = loginAccount;
                    tsmiManage.Enabled = (LoginAccount.Access == "Admin");

                    // Gán tên hiển thị hoặc username nếu không có DisplayName
                    tsmiAccountProfile.Text += string.IsNullOrEmpty(LoginAccount.DisplayName)
                        ? " (" + LoginAccount.Username + ")"
                        : " (" + LoginAccount.DisplayName + ")";
                }

                private void LoadComboBoxTable()
                {
                    cboSwitchTable.DataSource = TableBLL.Instance.GetTableFoods();
                    cboSwitchTable.DisplayMember = "NameTable";
                    cboSwitchTable.ValueMember = "IdTable";

                }

                private void LoadComboBoxDrink()
                {
                    cboCategory.DataSource = CategoryBLL.Instance.GetTable();
                    cboCategory.DisplayMember = "NameCategory";
                    cboCategory.ValueMember = "IdCategory";

                    cboCategory.SelectedIndexChanged -= cboCategory_SelectedIndexChanged; // Đảm bảo không đăng ký nhiều lần
                    cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;

                    // Gọi lần đầu để load đúng dữ liệu
                    if (cboCategory.SelectedValue != null)
                        cboCategory_SelectedIndexChanged(null, null);
                }

                private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
                {
            
                    int id;
                    if (!Int32.TryParse(cboCategory.SelectedValue.ToString(), out id))
                        return;

                    cboDrink.DataSource = DrinkBLL.Instance.GetDrinksByIdCategory(id);
                    cboDrink.DisplayMember = "NameDrink";
                    cboDrink.ValueMember = "IdDrink";
                }

                private void LoadInsEditDel_Drink()
                {
                    int id;
                    if (!Int32.TryParse(cboCategory.SelectedValue.ToString(), out id))
                        return;
                    cboDrink.DataSource = DrinkBLL.Instance.GetDrinksByIdCategory(id);
                    if (dgvBillInfo.Tag != null)
                        ShowBill(Convert.ToInt32((dgvBillInfo.Tag as DataRow)["IdTable"]));
                }

                private void LoadTable()
                {
                    List<TableFood> tables = TableBLL.Instance.GetTableFoods();
                        
                    fpnlTableList.Controls.Clear();
                    foreach (var table in tables)
                    {   
                     
                Guna2Button btn = new Guna2Button();
                        btn.FillColor = Color.Transparent;
                        btn.Font = new Font("Segoe UI", 9.75F);
                        btn.ForeColor = Color.Black;

                   btn.Image = (table.StatusTable == "Trống")
                          ? Image.FromFile("image/coffee-null.png")
                         : Image.FromFile("image/coffee-cup.png");

                       

                        btn.ImageOffset = new Point(10, -15);
                        btn.ImageSize = new Size(Content.tableWidth, Content.tableHeight);
                        btn.Size = new Size(Content.tableWidth, Content.tableHeight);

                        btn.Tag = table; 
                        btn.Text = table.NameTable ;
                        btn.TextAlign = HorizontalAlignment.Left;
                        btn.TextOffset = new Point(30, -10);
                        btn.Click += Btn_Click;

                        fpnlTableList.Controls.Add(btn);
                    }
                }

                private void Btn_Click(object sender, EventArgs e)
                {
                    if (sender is Guna2Button btn && btn.Tag is TableFood table)
                    {
                        dgvBillInfo.Tag = table; 

                        ShowBill(table.IdTable); 
                        grbSelectedTable.Text = table.NameTable; 
                    }
                    else
                    {
                        MessageBox.Show("Không thể lấy thông tin bàn!");
                    }
                }

                private void ShowBill(int id)
                {
                    int idBill = BillBLL.Instance.GetUncheckBillIDByTableID(id);
                    dgvBillInfo.DataSource = BillInfoBLL.Instance.GetBillInfoByIdBill(idBill);
                   
                      
                    CultureInfo culture = new CultureInfo("vi-VN");
                    //Thread.CurrentThread.CurrentCulture = culture; Áp dụng thay đổi cả Thread
                    txtTotalPrice.Text = TotalPrice().ToString("c", culture);
                }

                private int TotalPrice()
                {
                    int sum = 0;
                    for (int i = 0; i < dgvBillInfo.RowCount; i++)
                        sum += Convert.ToInt32(dgvBillInfo.Rows[i].Cells["ThanhTien"].Value);
                    return sum;
                }
                private void lblExit_Click(object sender, EventArgs e)
                {
                    this.Close();
                }

                private void Main_Load(object sender, EventArgs e)
                {
                    LoadTable();
                    LoadComboBoxDrink();
                    LoadComboBoxTable();
                    cbDiscount.SelectedIndex = 0;
                    
           
                }

                private void btnPayment_Click(object sender, EventArgs e)
                {
                    if (dgvBillInfo.Tag is TableFood table)
                    {
                        int idBill = BillBLL.Instance.GetUncheckBillIDByTableID(table.IdTable);

                        if (idBill != -1)
                        {
                    string discountText = cbDiscount.SelectedItem.ToString().Replace("%", "").Trim();
                    int discount = int.Parse(discountText);


                    string rawPrice = new string(txtTotalPrice.Text.Where(char.IsDigit).ToArray());
                            int totalPrice = int.Parse(rawPrice);

                            int finalTotalPrice = totalPrice - (int)(totalPrice / 100 * discount);

                            string msg = $"Bạn có chắc chắn muốn thanh toán {table.NameTable}\n" +
                                        $"Giảm giá: {discount}%\n" +
                                        $"Tổng tiền = {totalPrice} - {(int)(totalPrice / 100 * discount)} = {finalTotalPrice}";
                            if (MessageBox.Show(msg, "Thanh toán", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                        BillBLL.Instance.Payment(idBill, discount, finalTotalPrice);
                        ShowBill(table.IdTable);
                                LoadTable();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin bàn!");
                    }
                }

                private void btnAddNumDrink_Click(object sender, EventArgs e)
                {
            
                    if (!(dgvBillInfo.Tag is TableFood currentTable))
                    {
                        MessageBox.Show("Hãy chọn bàn trước khi thêm đồ uống", "Quản lý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int idBill = BillBLL.Instance.GetUncheckBillIDByTableID(currentTable.IdTable);
                     
                     int idDrink = Convert.ToInt32(cboDrink.SelectedValue);
                     int amount = (int)nudNumDrink.Value;
                    if (amount == 0) return;

                    if (idBill == -1)
                    {
                BillBLL.Instance.InsertBill(currentTable.IdTable);
                BillInfoBLL.Instance.InsertBillInfo(BillBLL.Instance.GetMaxIDBill(), idDrink, amount);
                    }
                    else
                    {
                        BillInfoBLL.Instance.InsertBillInfo(idBill, idDrink, amount);
                    }
                   
                     ShowBill(currentTable.IdTable);
                    
                    LoadTable();
                }

                private void btnSwitchTable_Click(object sender, EventArgs e)
                {
                    if (dgvBillInfo.Tag is TableFood currentTable)
                    {
                        int id1 = currentTable.IdTable;
                        int id2 = Convert.ToInt32(cboSwitchTable.SelectedValue);

                        DialogResult result = MessageBox.Show(
                            $"Bạn có thật sự muốn chuyển từ {currentTable.NameTable} sang {cboSwitchTable.Text} không?",
                            "Chuyển bàn",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.OK)
                        {
                    TableBLL.Instance.SwitchTable(id1, id2);

                    ShowBill(id1);
                    LoadTable();
                }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin bàn hiện tại");
                    }
                }

             

                private void tsmiBill_Click(object sender, EventArgs e)
                {
                    BillForm bill = new BillForm();
                    bill.ShowDialog();
                }

                private void tsmiTableDrink_Click(object sender, EventArgs e)
                {
                    TableFoodForm table = new TableFoodForm();
                    table.InsertTable += Table_InsertTable;
                    table.UpdateTable += Table_UpdateTable;
                    table.DeleteTable += Table_DeleteTable;
                    table.ShowDialog();
                }

                private void tsmiCategory_Click(object sender, EventArgs e)
                {
                    CategoryForm category = new CategoryForm();
                    category.InsertCategory += Category_InsertCategory;
                    category.UpdateCategory += Category_UpdateCategory;
                    category.DeleteCategory += Category_DeleteCategory;
                    category.ShowDialog();
                }

                private void tsmiDrink_Click(object sender, EventArgs e)
                {
                    DrinkForm drink = new DrinkForm();
                    drink.InsertDrink += Drink_InsertDrink;
                    drink.UpdateDrink += Drink_UpdateDrink;
                    drink.DeleteDrink += Drink_DeleteDrink;
                    drink.ShowDialog();
                }

                private void tsmiAccount_Click(object sender, EventArgs e)
                {
                    AccountForm account = new AccountForm(LoginAccount);
                    account.ShowDialog();
                }

                private void tsmiAccountProfile_Click(object sender, EventArgs e)
                {
                    AccountProfileForm profile = new AccountProfileForm(LoginAccount);
                    profile.UpdateAccount += Profile_UpdateAccount;
                    profile.ShowDialog();
                }

                private void tsmiAddNumDrink_Click(object sender, EventArgs e)
                {
                    btnAddNumDrink_Click(this, new EventArgs());
                }

                private void tsmiSwitchTable_Click(object sender, EventArgs e)
                {
                    btnSwitchTable_Click(this, new EventArgs());
                }

                private void tsmiMergeTable_Click(object sender, EventArgs e)
                {
                  
                }

                private void tsmiPayment_Click(object sender, EventArgs e)
                {
                    btnPayment_Click(this, new EventArgs());
                }

                private void Profile_UpdateAccount(object sender, AccountEvent e)
                {
                    LoginAccount = e.LoginAcc;
                    tsmiAccountProfile.Text = (LoginAccount.DisplayName.ToString() == "")
                                                    ? "&Thông tin tài khoản (" + LoginAccount.Username + ")"
                                                    : "&Thông tin tài khoản (" + LoginAccount.DisplayName + ")";
                }

                private void Table_InsertTable(object sender, EventArgs e)
                {
                    LoadTable();
                }

                private void Table_UpdateTable(object sender, EventArgs e)
                {
                    LoadTable();
                }

                private void Table_DeleteTable(object sender, EventArgs e)
                {
                    LoadTable();
                }

                private void Category_InsertCategory(object sender, EventArgs e)
                {
                    LoadComboBoxDrink();
                }

                private void Category_UpdateCategory(object sender, EventArgs e)
                {
                    LoadComboBoxDrink();
                }

                private void Category_DeleteCategory(object sender, EventArgs e)
                {
                    LoadComboBoxDrink();
                }

                private void Drink_InsertDrink(object sender, EventArgs e)
                {
                    LoadInsEditDel_Drink();
                }

                private void Drink_UpdateDrink(object sender, EventArgs e)
                {
                    LoadInsEditDel_Drink();
                }

                private void Drink_DeleteDrink(object sender, EventArgs e)
                {
                    LoadInsEditDel_Drink();
                    LoadTable();
                }

        private void tsmiFunction_Click(object sender, EventArgs e)
        {

        }

        private void grbSelectedTable_Enter(object sender, EventArgs e)
        {

        }

        private void cboMergeTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fpnlTableList_Paint(object sender, PaintEventArgs e)
        {

        }
    }
        }
