namespace QuanLyQuanCaPhe
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBill = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTableDrink = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDrink = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLine = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAccountProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.fpnlTableList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDrink = new System.Windows.Forms.Label();
            this.dragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.grbTableList = new System.Windows.Forms.GroupBox();
            this.btnPayment = new System.Windows.Forms.Button();
            this.nudNumDrink = new System.Windows.Forms.NumericUpDown();
            this.dgvBillInfo = new System.Windows.Forms.DataGridView();
            this.btnAddNumDrink = new System.Windows.Forms.Button();
            this.cbDiscount = new System.Windows.Forms.ComboBox();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.cboDrink = new System.Windows.Forms.ComboBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.grbSelectedTable = new System.Windows.Forms.GroupBox();
            this.cboSwitchTable = new System.Windows.Forms.ComboBox();
            this.btnSwitchTable = new System.Windows.Forms.Button();
            this.msMenu.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.grbTableList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumDrink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillInfo)).BeginInit();
            this.grbSelectedTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.AutoSize = false;
            this.msMenu.BackColor = System.Drawing.Color.Chocolate;
            this.msMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.msMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiManage,
            this.tsmiAccountProfile});
            this.msMenu.Location = new System.Drawing.Point(0, 50);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(947, 34);
            this.msMenu.TabIndex = 0;
            // 
            // tsmiManage
            // 
            this.tsmiManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBill,
            this.tsmiTableDrink,
            this.tsmiCategory,
            this.tsmiDrink,
            this.tsmiLine,
            this.tsmiAccount});
            this.tsmiManage.Name = "tsmiManage";
            this.tsmiManage.Size = new System.Drawing.Size(64, 30);
            this.tsmiManage.Text = "&Quản lý";
            // 
            // tsmiBill
            // 
            this.tsmiBill.Name = "tsmiBill";
            this.tsmiBill.Size = new System.Drawing.Size(138, 22);
            this.tsmiBill.Text = "Doanh thu";
            this.tsmiBill.Click += new System.EventHandler(this.tsmiBill_Click);
            // 
            // tsmiTableDrink
            // 
            this.tsmiTableDrink.Name = "tsmiTableDrink";
            this.tsmiTableDrink.Size = new System.Drawing.Size(138, 22);
            this.tsmiTableDrink.Text = "Bàn";
            this.tsmiTableDrink.Click += new System.EventHandler(this.tsmiTableDrink_Click);
            // 
            // tsmiCategory
            // 
            this.tsmiCategory.Name = "tsmiCategory";
            this.tsmiCategory.Size = new System.Drawing.Size(138, 22);
            this.tsmiCategory.Text = "Danh mục";
            this.tsmiCategory.Click += new System.EventHandler(this.tsmiCategory_Click);
            // 
            // tsmiDrink
            // 
            this.tsmiDrink.Name = "tsmiDrink";
            this.tsmiDrink.Size = new System.Drawing.Size(138, 22);
            this.tsmiDrink.Text = "Thức uống";
            this.tsmiDrink.Click += new System.EventHandler(this.tsmiDrink_Click);
            // 
            // tsmiLine
            // 
            this.tsmiLine.Name = "tsmiLine";
            this.tsmiLine.Size = new System.Drawing.Size(135, 6);
            // 
            // tsmiAccount
            // 
            this.tsmiAccount.Name = "tsmiAccount";
            this.tsmiAccount.Size = new System.Drawing.Size(138, 22);
            this.tsmiAccount.Text = "Tài khoản";
            this.tsmiAccount.Click += new System.EventHandler(this.tsmiAccount_Click);
            // 
            // tsmiAccountProfile
            // 
            this.tsmiAccountProfile.Name = "tsmiAccountProfile";
            this.tsmiAccountProfile.Size = new System.Drawing.Size(132, 30);
            this.tsmiAccountProfile.Text = "&Thông tin tài khoản";
            this.tsmiAccountProfile.Click += new System.EventHandler(this.tsmiAccountProfile_Click);
            // 
            // fpnlTableList
            // 
            this.fpnlTableList.AutoScroll = true;
            this.fpnlTableList.Location = new System.Drawing.Point(6, 24);
            this.fpnlTableList.Name = "fpnlTableList";
            this.fpnlTableList.Size = new System.Drawing.Size(465, 463);
            this.fpnlTableList.TabIndex = 0;
            this.fpnlTableList.Paint += new System.Windows.Forms.PaintEventHandler(this.fpnlTableList_Paint);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.pnlTitle.Controls.Add(this.lblExit);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(947, 50);
            this.pnlTitle.TabIndex = 0;
            // 
            // lblExit
            // 
            this.lblExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExit.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.Red;
            this.lblExit.Location = new System.Drawing.Point(890, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(57, 50);
            this.lblExit.TabIndex = 0;
            this.lblExit.Text = "X";
            this.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(402, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(173, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Coffee Shop";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(39, 24);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(88, 20);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Danh mục: ";
            // 
            // lblDrink
            // 
            this.lblDrink.AutoSize = true;
            this.lblDrink.Location = new System.Drawing.Point(39, 55);
            this.lblDrink.Name = "lblDrink";
            this.lblDrink.Size = new System.Drawing.Size(92, 20);
            this.lblDrink.TabIndex = 0;
            this.lblDrink.Text = "Thức uống: ";
            // 
            // dragControl
            // 
            this.dragControl.DockIndicatorTransparencyValue = 0.6D;
            this.dragControl.TargetControl = this.pnlTitle;
            this.dragControl.UseTransparentDrag = true;
            // 
            // grbTableList
            // 
            this.grbTableList.Controls.Add(this.btnPayment);
            this.grbTableList.Controls.Add(this.nudNumDrink);
            this.grbTableList.Controls.Add(this.dgvBillInfo);
            this.grbTableList.Controls.Add(this.btnAddNumDrink);
            this.grbTableList.Controls.Add(this.cbDiscount);
            this.grbTableList.Controls.Add(this.txtTotalPrice);
            this.grbTableList.Controls.Add(this.cboDrink);
            this.grbTableList.Controls.Add(this.cboCategory);
            this.grbTableList.Controls.Add(this.lblTotalPrice);
            this.grbTableList.Controls.Add(this.lblDiscount);
            this.grbTableList.Controls.Add(this.lblCategory);
            this.grbTableList.Controls.Add(this.lblDrink);
            this.grbTableList.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTableList.Location = new System.Drawing.Point(0, 87);
            this.grbTableList.Name = "grbTableList";
            this.grbTableList.Size = new System.Drawing.Size(462, 525);
            this.grbTableList.TabIndex = 9;
            this.grbTableList.TabStop = false;
            this.grbTableList.Text = "Danh sách món";
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.btnPayment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPayment.Location = new System.Drawing.Point(94, 490);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(362, 29);
            this.btnPayment.TabIndex = 33;
            this.btnPayment.Text = "Thanh toán";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // nudNumDrink
            // 
            this.nudNumDrink.Location = new System.Drawing.Point(381, 54);
            this.nudNumDrink.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudNumDrink.Name = "nudNumDrink";
            this.nudNumDrink.Size = new System.Drawing.Size(75, 27);
            this.nudNumDrink.TabIndex = 32;
            this.nudNumDrink.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dgvBillInfo
            // 
            this.dgvBillInfo.AllowUserToAddRows = false;
            this.dgvBillInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBillInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBillInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBillInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBillInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBillInfo.ColumnHeadersHeight = 30;
            this.dgvBillInfo.Location = new System.Drawing.Point(6, 87);
            this.dgvBillInfo.Name = "dgvBillInfo";
            this.dgvBillInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBillInfo.Size = new System.Drawing.Size(450, 315);
            this.dgvBillInfo.TabIndex = 31;
            // 
            // btnAddNumDrink
            // 
            this.btnAddNumDrink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.btnAddNumDrink.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNumDrink.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddNumDrink.Location = new System.Drawing.Point(381, 19);
            this.btnAddNumDrink.Name = "btnAddNumDrink";
            this.btnAddNumDrink.Size = new System.Drawing.Size(76, 29);
            this.btnAddNumDrink.TabIndex = 23;
            this.btnAddNumDrink.Text = "Thêm";
            this.btnAddNumDrink.UseVisualStyleBackColor = false;
            this.btnAddNumDrink.Click += new System.EventHandler(this.btnAddNumDrink_Click);
            // 
            // cbDiscount
            // 
            this.cbDiscount.DisplayMember = "0%";
            this.cbDiscount.FormattingEnabled = true;
            this.cbDiscount.Items.AddRange(new object[] {
            "0%",
            "10%",
            "20%",
            "50%",
            "100%"});
            this.cbDiscount.Location = new System.Drawing.Point(192, 451);
            this.cbDiscount.Name = "cbDiscount";
            this.cbDiscount.Size = new System.Drawing.Size(264, 28);
            this.cbDiscount.TabIndex = 12;
            this.cbDiscount.ValueMember = "0%";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(192, 409);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(264, 27);
            this.txtTotalPrice.TabIndex = 11;
            // 
            // cboDrink
            // 
            this.cboDrink.FormattingEnabled = true;
            this.cboDrink.Location = new System.Drawing.Point(140, 55);
            this.cboDrink.Name = "cboDrink";
            this.cboDrink.Size = new System.Drawing.Size(216, 28);
            this.cboDrink.TabIndex = 10;
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(140, 21);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(216, 28);
            this.cboCategory.TabIndex = 9;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(4, 409);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(127, 20);
            this.lblTotalPrice.TabIndex = 0;
            this.lblTotalPrice.Text = "Tổng Thành Tiền";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(4, 451);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(73, 20);
            this.lblDiscount.TabIndex = 0;
            this.lblDiscount.Text = "Giảm Giá";
            // 
            // grbSelectedTable
            // 
            this.grbSelectedTable.Controls.Add(this.cboSwitchTable);
            this.grbSelectedTable.Controls.Add(this.btnSwitchTable);
            this.grbSelectedTable.Controls.Add(this.fpnlTableList);
            this.grbSelectedTable.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSelectedTable.Location = new System.Drawing.Point(463, 87);
            this.grbSelectedTable.Name = "grbSelectedTable";
            this.grbSelectedTable.Size = new System.Drawing.Size(480, 525);
            this.grbSelectedTable.TabIndex = 10;
            this.grbSelectedTable.TabStop = false;
            this.grbSelectedTable.Text = "Bàn ?";
            this.grbSelectedTable.Enter += new System.EventHandler(this.grbSelectedTable_Enter);
            // 
            // cboSwitchTable
            // 
            this.cboSwitchTable.FormattingEnabled = true;
            this.cboSwitchTable.Location = new System.Drawing.Point(256, 493);
            this.cboSwitchTable.Name = "cboSwitchTable";
            this.cboSwitchTable.Size = new System.Drawing.Size(102, 25);
            this.cboSwitchTable.TabIndex = 24;
            // 
            // btnSwitchTable
            // 
            this.btnSwitchTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.btnSwitchTable.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitchTable.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSwitchTable.Location = new System.Drawing.Point(377, 493);
            this.btnSwitchTable.Name = "btnSwitchTable";
            this.btnSwitchTable.Size = new System.Drawing.Size(94, 29);
            this.btnSwitchTable.TabIndex = 24;
            this.btnSwitchTable.Text = "Chuyển bàn";
            this.btnSwitchTable.UseVisualStyleBackColor = false;
            this.btnSwitchTable.Click += new System.EventHandler(this.btnSwitchTable_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(947, 617);
            this.Controls.Add(this.grbSelectedTable);
            this.Controls.Add(this.grbTableList);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.msMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.msMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý quán cà phê";
            this.Load += new System.EventHandler(this.Main_Load);
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.grbTableList.ResumeLayout(false);
            this.grbTableList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumDrink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillInfo)).EndInit();
            this.grbSelectedTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiAccountProfile;
        private System.Windows.Forms.FlowLayoutPanel fpnlTableList;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDrink;
        private Guna.UI2.WinForms.Guna2DragControl dragControl;
        private System.Windows.Forms.ToolStripMenuItem tsmiBill;
        private System.Windows.Forms.ToolStripMenuItem tsmiCategory;
        private System.Windows.Forms.ToolStripMenuItem tsmiDrink;
        private System.Windows.Forms.ToolStripSeparator tsmiLine;
        private System.Windows.Forms.ToolStripMenuItem tsmiAccount;
        private System.Windows.Forms.GroupBox grbTableList;
        private System.Windows.Forms.GroupBox grbSelectedTable;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.ToolStripMenuItem tsmiTableDrink;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.ComboBox cboDrink;
        private System.Windows.Forms.ComboBox cbDiscount;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Button btnAddNumDrink;
        private System.Windows.Forms.ComboBox cboSwitchTable;
        private System.Windows.Forms.Button btnSwitchTable;
        private System.Windows.Forms.DataGridView dgvBillInfo;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.NumericUpDown nudNumDrink;
    }

}
