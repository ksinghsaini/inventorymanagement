namespace WindowsCSharpProject
{
    partial class UpdateInventory
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.transactionType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.itemNameFindButton = new System.Windows.Forms.Button();
            this.updateInventoryGrid = new System.Windows.Forms.DataGridView();
            this.operationsGroupBox = new System.Windows.Forms.GroupBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.numericValue = new System.Windows.Forms.NumericUpDown();
            this.operationHelp = new System.Windows.Forms.Label();
            this.operationNameLabel = new System.Windows.Forms.Label();
            this.inventoryID = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.updateInventoryGrid)).BeginInit();
            this.operationsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryID)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.MaximumSize = new System.Drawing.Size(360, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Perform an update to a particular item in inventory : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select the type of transaction: ";
            // 
            // transactionType
            // 
            this.transactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transactionType.FormattingEnabled = true;
            this.transactionType.Items.AddRange(new object[] {
            "Add Quantity",
            "Remove Quantity"});
            this.transactionType.Location = new System.Drawing.Point(237, 38);
            this.transactionType.Name = "transactionType";
            this.transactionType.Size = new System.Drawing.Size(160, 21);
            this.transactionType.TabIndex = 2;
            this.transactionType.SelectedIndexChanged += new System.EventHandler(this.transactionType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Search for an item by name : (Convenience)";
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.Location = new System.Drawing.Point(237, 72);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.itemNameTextBox.TabIndex = 4;
            // 
            // itemNameFindButton
            // 
            this.itemNameFindButton.Location = new System.Drawing.Point(343, 70);
            this.itemNameFindButton.Name = "itemNameFindButton";
            this.itemNameFindButton.Size = new System.Drawing.Size(54, 24);
            this.itemNameFindButton.TabIndex = 5;
            this.itemNameFindButton.Text = "Find";
            this.itemNameFindButton.UseVisualStyleBackColor = true;
            this.itemNameFindButton.Click += new System.EventHandler(this.itemNameFindButton_Click);
            // 
            // updateInventoryGrid
            // 
            this.updateInventoryGrid.AllowUserToAddRows = false;
            this.updateInventoryGrid.AllowUserToDeleteRows = false;
            this.updateInventoryGrid.AllowUserToResizeColumns = false;
            this.updateInventoryGrid.AllowUserToResizeRows = false;
            this.updateInventoryGrid.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.updateInventoryGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.updateInventoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.updateInventoryGrid.Location = new System.Drawing.Point(3, 103);
            this.updateInventoryGrid.MultiSelect = false;
            this.updateInventoryGrid.Name = "updateInventoryGrid";
            this.updateInventoryGrid.ReadOnly = true;
            this.updateInventoryGrid.RowHeadersVisible = false;
            this.updateInventoryGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.updateInventoryGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.updateInventoryGrid.Size = new System.Drawing.Size(400, 134);
            this.updateInventoryGrid.TabIndex = 6;
            this.updateInventoryGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.updateInventoryGrid_CellClick);
            // 
            // operationsGroupBox
            // 
            this.operationsGroupBox.Controls.Add(this.confirmButton);
            this.operationsGroupBox.Controls.Add(this.numericValue);
            this.operationsGroupBox.Controls.Add(this.operationHelp);
            this.operationsGroupBox.Controls.Add(this.operationNameLabel);
            this.operationsGroupBox.Enabled = false;
            this.operationsGroupBox.Location = new System.Drawing.Point(4, 274);
            this.operationsGroupBox.Name = "operationsGroupBox";
            this.operationsGroupBox.Size = new System.Drawing.Size(399, 145);
            this.operationsGroupBox.TabIndex = 7;
            this.operationsGroupBox.TabStop = false;
            this.operationsGroupBox.Text = "Operations";
            // 
            // confirmButton
            // 
            this.confirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.Location = new System.Drawing.Point(233, 52);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(160, 45);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // numericValue
            // 
            this.numericValue.Location = new System.Drawing.Point(233, 16);
            this.numericValue.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericValue.Name = "numericValue";
            this.numericValue.Size = new System.Drawing.Size(160, 20);
            this.numericValue.TabIndex = 2;
            // 
            // operationHelp
            // 
            this.operationHelp.AutoSize = true;
            this.operationHelp.Location = new System.Drawing.Point(6, 108);
            this.operationHelp.MaximumSize = new System.Drawing.Size(380, 0);
            this.operationHelp.Name = "operationHelp";
            this.operationHelp.Size = new System.Drawing.Size(90, 13);
            this.operationHelp.TabIndex = 1;
            this.operationHelp.Text = "<Operation Help>";
            // 
            // operationNameLabel
            // 
            this.operationNameLabel.AutoSize = true;
            this.operationNameLabel.Location = new System.Drawing.Point(6, 18);
            this.operationNameLabel.Name = "operationNameLabel";
            this.operationNameLabel.Size = new System.Drawing.Size(96, 13);
            this.operationNameLabel.TabIndex = 1;
            this.operationNameLabel.Text = "<Operation Name>";
            // 
            // inventoryID
            // 
            this.inventoryID.Location = new System.Drawing.Point(237, 243);
            this.inventoryID.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.inventoryID.Name = "inventoryID";
            this.inventoryID.Size = new System.Drawing.Size(160, 20);
            this.inventoryID.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Enter the inventory ID :\r\n";
            // 
            // UpdateInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 421);
            this.Controls.Add(this.inventoryID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.operationsGroupBox);
            this.Controls.Add(this.updateInventoryGrid);
            this.Controls.Add(this.itemNameFindButton);
            this.Controls.Add(this.itemNameTextBox);
            this.Controls.Add(this.transactionType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UpdateInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Inventory Item";
            this.Load += new System.EventHandler(this.UpdateInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.updateInventoryGrid)).EndInit();
            this.operationsGroupBox.ResumeLayout(false);
            this.operationsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox transactionType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox itemNameTextBox;
        private System.Windows.Forms.Button itemNameFindButton;
        private System.Windows.Forms.DataGridView updateInventoryGrid;
        private System.Windows.Forms.GroupBox operationsGroupBox;
        private System.Windows.Forms.NumericUpDown numericValue;
        private System.Windows.Forms.Label operationNameLabel;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label operationHelp;
        private System.Windows.Forms.NumericUpDown inventoryID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}