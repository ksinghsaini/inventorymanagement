using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsCSharpProject.Controllers;

namespace WindowsCSharpProject
{
    public partial class PurchaseOrder : Form
    {
        SqlConnection connection;
        List<int> pks1, pks2;
        //pks - Primary Key Store, that is used to store the corresponding primary key for the items in the combobox
        //So that the database need not to search it again based on name instead
        //Motto - Make client do a little hard work, so that server don't need to do a lot of heavylifting
        public PurchaseOrder(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                comboBox2.Items.Clear();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Inventory.Name, Inventory.InventoryID FROM Inventory " +
                     "INNER JOIN MappingTable " +
                     "ON Inventory.InventoryID = MappingTable.InventoryID " +
                     "INNER JOIN Vendor ON Vendor.VendorID = MappingTable.VendorID " +
                     "WHERE Vendor.Name= @name; ";
                cmd.Parameters.AddWithValue("@name", comboBox1.SelectedItem);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    pks2 = new List<int>();
                    while (dr.Read())
                    {
                        comboBox2.Items.Add((string)dr["Name"]);
                        pks2.Add((int)dr["InventoryID"]);
                    }
                }
                else Default.ShowError("Nothing to order with this vendor, No products found for this vendor.");
                dr.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0 && comboBox2.SelectedIndex >= 0)
            {
                if (numericUpDown1.Value > 0)
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText =
                        "INSERT INTO PurchaseOrder(Quantity,PurchaseDate,InventoryID,VendorID,Completed) " +
                        "VALUES(@quantity,@date,@inventoryID,@vendorID,'N')";
                    cmd.Parameters.AddWithValue("@quantity", numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@vendorID", pks1[comboBox1.SelectedIndex]);
                    cmd.Parameters.AddWithValue("@inventoryID", pks2[comboBox2.SelectedIndex]);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        if (MessageBox.Show("Transaction Completed.\nDo you need the receipt for this transaction?", "RECEIPT", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cmd.CommandText = "SELECT IDENT_CURRENT('PurchaseOrder') AS po_identity,ItemPrice FROM MappingTable "+
                                "WHERE InventoryID = @InventoryID AND VendorID = @vendorID";
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                long identity = (long)(decimal)reader["po_identity"];
                                decimal price = (decimal)reader["ItemPrice"];
                                String formatString = String.Format(
                                    "Transaction ID : {0}\n" +
                                    "Quantity : {1}\n" +
                                    "Price : ${2}\n" +
                                    "You can use the transaction ID to complete this purchase order from Update Inventory",
                                    identity,
                                    numericUpDown1.Value,
                                    Math.Round(numericUpDown1.Value * price, 2)
                                    );
                                Default.ShowInfo(formatString, "Transaction Receipt");
                            }
                            else Default.ShowError("Could not get the transaction ID from the server.");
                            reader.Close();
                        }
                    }
                    else Default.ShowError("Server error, could not setup the purchase order");
                }
                else Default.ShowError("Quantity must be greater than 0");
            }
            else Default.ShowError("Vendor and Product Name cannot be empty!");
        }

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            pks1 = new List<int>();
            comboBox1.Items.Clear();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Vendor.Name, VendorID FROM Vendor";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                while (dr.Read())
                {
                    comboBox1.Items.Add((string)dr["Name"]);
                    pks1.Add((int)dr["VendorID"]);
                }
            else
            {
                Default.ShowError("No vendor found, please add a vendor first before using this form.");
                this.Close();
            }
            dr.Close();
        }
    }
}
