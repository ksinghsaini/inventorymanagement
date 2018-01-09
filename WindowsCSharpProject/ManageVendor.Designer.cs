namespace WindowsCSharpProject
{
    partial class ManageVendor
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.addPageListBox = new System.Windows.Forms.ListBox();
            this.productNameComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.searchOnAddPage = new System.Windows.Forms.Button();
            this.addVendorButton = new System.Windows.Forms.Button();
            this.clearProducts = new System.Windows.Forms.Button();
            this.assignProducts = new System.Windows.Forms.Button();
            this.phoneNumber = new System.Windows.Forms.NumericUpDown();
            this.productPriceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.deleteNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.deletePageGridView = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.vendorNameTextBox = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.searchOnDeletePage = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.vendorIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.findButton = new System.Windows.Forms.Button();
            this.discardButton = new System.Windows.Forms.Button();
            this.commitButton = new System.Windows.Forms.Button();
            this.updateGroupBox = new System.Windows.Forms.GroupBox();
            this.searchComboBox = new System.Windows.Forms.ComboBox();
            this.priceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.searchButtonUpdatePage = new System.Windows.Forms.Button();
            this.addProductButton = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.updatePageListView = new System.Windows.Forms.ListView();
            this.inventoryItemID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.inventoryItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.inventoryItemPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phoneNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productPriceNumericUpDown)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deleteNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletePageGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vendorIDNumericUpDown)).BeginInit();
            this.updateGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(363, 419);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabUpdateSwitch);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.addPageListBox);
            this.tabPage1.Controls.Add(this.productNameComboBox);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.searchOnAddPage);
            this.tabPage1.Controls.Add(this.addVendorButton);
            this.tabPage1.Controls.Add(this.clearProducts);
            this.tabPage1.Controls.Add(this.assignProducts);
            this.tabPage1.Controls.Add(this.phoneNumber);
            this.tabPage1.Controls.Add(this.productPriceNumericUpDown);
            this.tabPage1.Controls.Add(this.addressTextBox);
            this.tabPage1.Controls.Add(this.nameTextBox);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(355, 393);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Vendor";
            // 
            // addPageListBox
            // 
            this.addPageListBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addPageListBox.FormattingEnabled = true;
            this.addPageListBox.Location = new System.Drawing.Point(135, 139);
            this.addPageListBox.Name = "addPageListBox";
            this.addPageListBox.Size = new System.Drawing.Size(202, 82);
            this.addPageListBox.TabIndex = 10;
            // 
            // productNameComboBox
            // 
            this.productNameComboBox.FormattingEnabled = true;
            this.productNameComboBox.Location = new System.Drawing.Point(135, 230);
            this.productNameComboBox.Name = "productNameComboBox";
            this.productNameComboBox.Size = new System.Drawing.Size(104, 21);
            this.productNameComboBox.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 7;
            // 
            // searchOnAddPage
            // 
            this.searchOnAddPage.Location = new System.Drawing.Point(246, 230);
            this.searchOnAddPage.Name = "searchOnAddPage";
            this.searchOnAddPage.Size = new System.Drawing.Size(91, 21);
            this.searchOnAddPage.TabIndex = 5;
            this.searchOnAddPage.Text = "Search";
            this.searchOnAddPage.UseVisualStyleBackColor = true;
            this.searchOnAddPage.Click += new System.EventHandler(this.searchOnAddPage_Click);
            // 
            // addVendorButton
            // 
            this.addVendorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addVendorButton.Location = new System.Drawing.Point(12, 333);
            this.addVendorButton.Name = "addVendorButton";
            this.addVendorButton.Size = new System.Drawing.Size(325, 45);
            this.addVendorButton.TabIndex = 9;
            this.addVendorButton.Text = "Add Vendor";
            this.addVendorButton.UseVisualStyleBackColor = true;
            this.addVendorButton.Click += new System.EventHandler(this.addVendor_Click);
            // 
            // clearProducts
            // 
            this.clearProducts.Location = new System.Drawing.Point(12, 293);
            this.clearProducts.Name = "clearProducts";
            this.clearProducts.Size = new System.Drawing.Size(154, 23);
            this.clearProducts.TabIndex = 7;
            this.clearProducts.Text = "Clear Products";
            this.clearProducts.UseVisualStyleBackColor = true;
            this.clearProducts.Click += new System.EventHandler(this.clearProducts_Click);
            // 
            // assignProducts
            // 
            this.assignProducts.Location = new System.Drawing.Point(186, 293);
            this.assignProducts.Name = "assignProducts";
            this.assignProducts.Size = new System.Drawing.Size(151, 23);
            this.assignProducts.TabIndex = 8;
            this.assignProducts.Text = "Assign Product to Vendor";
            this.assignProducts.UseVisualStyleBackColor = true;
            this.assignProducts.Click += new System.EventHandler(this.addProducts_Click);
            // 
            // phoneNumber
            // 
            this.phoneNumber.Location = new System.Drawing.Point(246, 110);
            this.phoneNumber.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.phoneNumber.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.Size = new System.Drawing.Size(91, 20);
            this.phoneNumber.TabIndex = 3;
            this.phoneNumber.Value = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            // 
            // productPriceNumericUpDown
            // 
            this.productPriceNumericUpDown.DecimalPlaces = 2;
            this.productPriceNumericUpDown.Location = new System.Drawing.Point(246, 259);
            this.productPriceNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.productPriceNumericUpDown.Name = "productPriceNumericUpDown";
            this.productPriceNumericUpDown.Size = new System.Drawing.Size(91, 20);
            this.productPriceNumericUpDown.TabIndex = 6;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(135, 30);
            this.addressTextBox.MaxLength = 89;
            this.addressTextBox.Multiline = true;
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(202, 65);
            this.addressTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(135, 4);
            this.nameTextBox.MaxLength = 30;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(202, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Product Price :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Product Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Product(s) : (read-only)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Phone Number :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Address :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.deleteNumericUpDown);
            this.tabPage2.Controls.Add(this.deletePageGridView);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.vendorNameTextBox);
            this.tabPage2.Controls.Add(this.deleteButton);
            this.tabPage2.Controls.Add(this.searchOnDeletePage);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(355, 393);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Delete Vendor";
            // 
            // deleteNumericUpDown
            // 
            this.deleteNumericUpDown.Location = new System.Drawing.Point(176, 276);
            this.deleteNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.deleteNumericUpDown.Name = "deleteNumericUpDown";
            this.deleteNumericUpDown.Size = new System.Drawing.Size(167, 20);
            this.deleteNumericUpDown.TabIndex = 5;
            // 
            // deletePageGridView
            // 
            this.deletePageGridView.AllowUserToAddRows = false;
            this.deletePageGridView.AllowUserToDeleteRows = false;
            this.deletePageGridView.AllowUserToOrderColumns = true;
            this.deletePageGridView.AllowUserToResizeColumns = false;
            this.deletePageGridView.AllowUserToResizeRows = false;
            this.deletePageGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.deletePageGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.deletePageGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deletePageGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.deletePageGridView.Location = new System.Drawing.Point(11, 99);
            this.deletePageGridView.Name = "deletePageGridView";
            this.deletePageGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.deletePageGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.deletePageGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.deletePageGridView.Size = new System.Drawing.Size(332, 150);
            this.deletePageGridView.TabIndex = 3;
            this.deletePageGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.deletePageGridView_CellClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(277, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Please check the vendor ID and enter it below to delete :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 278);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Enter Vendor ID :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Vendor Name (Contains):";
            // 
            // vendorNameTextBox
            // 
            this.vendorNameTextBox.Location = new System.Drawing.Point(176, 7);
            this.vendorNameTextBox.Name = "vendorNameTextBox";
            this.vendorNameTextBox.Size = new System.Drawing.Size(167, 20);
            this.vendorNameTextBox.TabIndex = 1;
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(176, 310);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(138, 49);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // searchOnDeletePage
            // 
            this.searchOnDeletePage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchOnDeletePage.Location = new System.Drawing.Point(176, 33);
            this.searchOnDeletePage.Name = "searchOnDeletePage";
            this.searchOnDeletePage.Size = new System.Drawing.Size(85, 23);
            this.searchOnDeletePage.TabIndex = 2;
            this.searchOnDeletePage.Text = "Search";
            this.searchOnDeletePage.UseVisualStyleBackColor = true;
            this.searchOnDeletePage.Click += new System.EventHandler(this.searchDeletePage_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.vendorIDNumericUpDown);
            this.tabPage3.Controls.Add(this.findButton);
            this.tabPage3.Controls.Add(this.discardButton);
            this.tabPage3.Controls.Add(this.commitButton);
            this.tabPage3.Controls.Add(this.updateGroupBox);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(355, 393);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Update Vendor";
            // 
            // vendorIDNumericUpDown
            // 
            this.vendorIDNumericUpDown.Location = new System.Drawing.Point(151, 11);
            this.vendorIDNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.vendorIDNumericUpDown.Name = "vendorIDNumericUpDown";
            this.vendorIDNumericUpDown.Size = new System.Drawing.Size(97, 20);
            this.vendorIDNumericUpDown.TabIndex = 1;
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(266, 9);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 26);
            this.findButton.TabIndex = 2;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.Find_Click);
            // 
            // discardButton
            // 
            this.discardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discardButton.Location = new System.Drawing.Point(151, 343);
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(190, 29);
            this.discardButton.TabIndex = 9;
            this.discardButton.Text = "Discard";
            this.discardButton.UseVisualStyleBackColor = true;
            this.discardButton.Click += new System.EventHandler(this.Discard_Click);
            // 
            // commitButton
            // 
            this.commitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commitButton.Location = new System.Drawing.Point(151, 308);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(190, 29);
            this.commitButton.TabIndex = 8;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.Commit_Click);
            // 
            // updateGroupBox
            // 
            this.updateGroupBox.Controls.Add(this.updatePageListView);
            this.updateGroupBox.Controls.Add(this.searchComboBox);
            this.updateGroupBox.Controls.Add(this.priceNumericUpDown);
            this.updateGroupBox.Controls.Add(this.searchButtonUpdatePage);
            this.updateGroupBox.Controls.Add(this.addProductButton);
            this.updateGroupBox.Controls.Add(this.button10);
            this.updateGroupBox.Controls.Add(this.label12);
            this.updateGroupBox.Controls.Add(this.label14);
            this.updateGroupBox.Controls.Add(this.label13);
            this.updateGroupBox.Location = new System.Drawing.Point(12, 46);
            this.updateGroupBox.Name = "updateGroupBox";
            this.updateGroupBox.Size = new System.Drawing.Size(336, 239);
            this.updateGroupBox.TabIndex = 2;
            this.updateGroupBox.TabStop = false;
            this.updateGroupBox.Text = "Vendor Properties";
            // 
            // searchComboBox
            // 
            this.searchComboBox.FormattingEnabled = true;
            this.searchComboBox.Location = new System.Drawing.Point(139, 163);
            this.searchComboBox.Name = "searchComboBox";
            this.searchComboBox.Size = new System.Drawing.Size(97, 21);
            this.searchComboBox.TabIndex = 4;
            // 
            // priceNumericUpDown
            // 
            this.priceNumericUpDown.DecimalPlaces = 2;
            this.priceNumericUpDown.Location = new System.Drawing.Point(139, 200);
            this.priceNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.priceNumericUpDown.Name = "priceNumericUpDown";
            this.priceNumericUpDown.Size = new System.Drawing.Size(97, 20);
            this.priceNumericUpDown.TabIndex = 6;
            // 
            // searchButtonUpdatePage
            // 
            this.searchButtonUpdatePage.Location = new System.Drawing.Point(254, 163);
            this.searchButtonUpdatePage.Name = "searchButtonUpdatePage";
            this.searchButtonUpdatePage.Size = new System.Drawing.Size(75, 23);
            this.searchButtonUpdatePage.TabIndex = 5;
            this.searchButtonUpdatePage.Text = "Search";
            this.searchButtonUpdatePage.UseVisualStyleBackColor = true;
            this.searchButtonUpdatePage.Click += new System.EventHandler(this.searchButtonUpdateClick);
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(254, 200);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(75, 23);
            this.addProductButton.TabIndex = 7;
            this.addProductButton.Text = "Add Product";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.addProductButtonClick);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(254, 15);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 3;
            this.button10.Text = "Unlink";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.unlink_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(211, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Check all item to unlink and click \"Unlink\" :\r\n";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 202);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Price :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 166);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Enter Product Name : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Enter vendor ID to begin :";
            // 
            // updatePageListView
            // 
            this.updatePageListView.CheckBoxes = true;
            this.updatePageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.inventoryItemID,
            this.inventoryItemName,
            this.inventoryItemPrice});
            this.updatePageListView.Location = new System.Drawing.Point(8, 42);
            this.updatePageListView.Name = "updatePageListView";
            this.updatePageListView.Size = new System.Drawing.Size(321, 115);
            this.updatePageListView.TabIndex = 8;
            this.updatePageListView.UseCompatibleStateImageBehavior = false;
            this.updatePageListView.View = System.Windows.Forms.View.Details;
            // 
            // inventoryItemID
            // 
            this.inventoryItemID.Text = "InventoryID";
            this.inventoryItemID.Width = 85;
            // 
            // inventoryItemName
            // 
            this.inventoryItemName.Text = "Item Name";
            this.inventoryItemName.Width = 124;
            // 
            // inventoryItemPrice
            // 
            this.inventoryItemPrice.Text = "Vendor Price";
            this.inventoryItemPrice.Width = 90;
            // 
            // ManageVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 421);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageVendor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Vendor";
            this.Load += new System.EventHandler(this.ManageVendor_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phoneNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productPriceNumericUpDown)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deleteNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletePageGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vendorIDNumericUpDown)).EndInit();
            this.updateGroupBox.ResumeLayout(false);
            this.updateGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.NumericUpDown productPriceNumericUpDown;
        private System.Windows.Forms.Button addVendorButton;
        private System.Windows.Forms.Button assignProducts;
        private System.Windows.Forms.Button clearProducts;
        private System.Windows.Forms.NumericUpDown phoneNumber;
        private System.Windows.Forms.Button searchOnAddPage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox productNameComboBox;
        private System.Windows.Forms.TextBox vendorNameTextBox;
        private System.Windows.Forms.Button searchOnDeletePage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView deletePageGridView;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button discardButton;
        private System.Windows.Forms.Button commitButton;
        private System.Windows.Forms.GroupBox updateGroupBox;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.NumericUpDown vendorIDNumericUpDown;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown priceNumericUpDown;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox searchComboBox;
        private System.Windows.Forms.Button searchButtonUpdatePage;
        private System.Windows.Forms.ListBox addPageListBox;
        private System.Windows.Forms.NumericUpDown deleteNumericUpDown;
        private System.Windows.Forms.ListView updatePageListView;
        private System.Windows.Forms.ColumnHeader inventoryItemID;
        private System.Windows.Forms.ColumnHeader inventoryItemName;
        private System.Windows.Forms.ColumnHeader inventoryItemPrice;
    }
}