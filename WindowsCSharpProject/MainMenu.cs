using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsCSharpProject
{
    public partial class MainMenu : Form
    {
        SqlConnection connection;

        public MainMenu()
        {
            InitializeComponent();
            connection = new SqlConnection(Properties.Resources.connectionString);
            connection.Open();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This project is completed by:\n1. Arshdeep Singh\n2. Kirpal Singh","Authors",
                MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Application.Exit();
        }

        private void addItems_Click(object sender, EventArgs e)
        {
            ManageItems manageItems = new ManageItems(connection);
            this.Hide();
            manageItems.ShowDialog();
            this.Show();
        }

        private void manageVendor_Click(object sender, EventArgs e)
        {
            ManageVendor vendor = new ManageVendor(connection);
            this.Hide();
            vendor.ShowDialog();
            this.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
        private void ExecuteQuery(int index)
        {
            SqlCommand command = connection.CreateCommand();
            string base_ = "SELECT PurchaseOrderID, PurchaseOrder.Quantity, Inventory.Name as 'Product', Vendor.Name as 'Vendor' " +
                  "FROM PurchaseOrder INNER JOIN Inventory " +
                  "ON PurchaseOrder.InventoryID = Inventory.InventoryID " +
                  "INNER JOIN Vendor " +
                  "ON Vendor.VendorID = PurchaseOrder.VendorID ";
            switch (index)
            {
                case 0:
                    command.CommandText = "SELECT Inventory.Name as \"Item Name\", " +
                  "Vendor.Name as \"Vendor Name\", " +
                  "Inventory.Quantity as \"Available\", " +
                  "MappingTable.ItemPrice as \"Vendor Price\" " +
                  "FROM Inventory " +
                  "INNER JOIN MappingTable " +
                  "ON Inventory.InventoryID = MappingTable.InventoryID " +
                  "INNER JOIN Vendor ON Vendor.VendorID = MappingTable.VendorID; ";
                    break;
                case 1:
                    command.CommandText = "SELECT InventoryID, Name, Quantity, Category FROM Inventory;";//Inventory alone
                    break;
                case 2:
                    command.CommandText = "SELECT  VendorID, Name, Address ,PhoneNumber FROM Vendor;"; break;
                case 3:
                    command.CommandText = base_+" WHERE Completed = 'Y'";
                    break;
                case 4:
                    command.CommandText = base_ + " WHERE Completed = 'N'";
                    break;
                default: return;
            }
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            reader.Close();
            dataGridView1.DataSource = table;
            dataGridView1.Enabled = false;
            dataGridView1.ClearSelection();
        }
        private void MainMenu_VisibleChanged(object sender, EventArgs e)
        {
            ExecuteQuery(comboBox1.SelectedIndex);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((ComboBox)(sender)).SelectedIndex;
            ExecuteQuery(index);
        }

        private void sendInvoice_Click(object sender, EventArgs e)
        {
            this.Hide();
            PurchaseOrder po = new PurchaseOrder(connection);
            po.ShowDialog();
            this.Show();
        }

        private void updateInventory_Click(object sender, EventArgs e)
        {
            UpdateInventory inventory = new UpdateInventory(connection);
            this.Hide();
            inventory.ShowDialog();
            this.Show();
        }
        
    }
}
