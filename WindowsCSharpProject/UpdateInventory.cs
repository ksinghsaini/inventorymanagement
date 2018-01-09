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
using WindowsCSharpProject.Controllers;

namespace WindowsCSharpProject
{
    public partial class UpdateInventory : Form
    {
        SqlConnection connection;
        public UpdateInventory(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }
        int operation = -1;
        private void itemNameFindButton_Click(object sender, EventArgs e)
        {
            string text = String.Format("%{0}%", itemNameTextBox.Text);
            if (!String.IsNullOrEmpty(text))
            {
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "SELECT InventoryID,Name,Quantity, DateUpdated FROM Inventory WHERE Name LIKE @name";
                sqlCommand.Parameters.AddWithValue("@name", text);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    updateInventoryGrid.DataSource = table;
                    inventoryID.Value = (int)updateInventoryGrid.Rows[0].Cells[0].Value;
                }
                else Default.ShowInfo("No result found for given inventory item name.");
                reader.Close();
            }
            else Default.ShowError("Please enter some text first.");
        }

        private void transactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = ((ComboBox)sender);
            operationsGroupBox.Enabled = (comboBox.SelectedIndex >= 0);
            if (comboBox.SelectedIndex >= 0)
            {
                operation = comboBox.SelectedIndex;
                string[] operations = new string[] { "Enter the purchase order ID :*", "Enter the quantity removed :*", "<ERROR>" };
                string[] operationHelp = new string[]
                {
                    "* You need to make a purchase order with a vendor and then record the unique ID, and enter the ID here.",
                    "* Enter the amount of quantity that was removed by last transaction."
                };
                operationNameLabel.Text = operations[comboBox.SelectedIndex];
                this.operationHelp.Text = operationHelp[comboBox.SelectedIndex];
            }
        }

        private void updateInventoryGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            inventoryID.Value = (int)((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            int inventoryID = (int)this.inventoryID.Value;
            if (!transactionType.Items.Contains(transactionType.Text) && operation != -1)
            {
                if (MessageBox.Show("Just letting you know we are performing operation : \n" + transactionType.Items[operation] +
                    "\nIs this what you intended?",
                    "Operation confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }
            else if (operation == -1)
            {
                Default.ShowError("No operation selected, code flow error.");
                return;
            }
            int thisValue = (int)numericValue.Value;
            //First check the ID entered by the user exists
            if (thisValue <= 0)
            {
                Default.ShowError("Operation Value for \"" +
                    (new string[] { "Purchase Order ID", "Quantity" })[operation] + "\" cannot be 0");
                return;
            }
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Quantity FROM Inventory WHERE InventoryID = @id";
            command.Parameters.AddWithValue("@id", inventoryID);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int onHandQuantity = (int)reader["Quantity"];
                reader.Close();
                switch (operation)
                {
                    case 0:
                        //First we need to get the information from purchaseorder table
                        //We don't deal with onhandquantity, but it insures that the corresponding inventory record exists
                        //For the completed Record attribute, Y is completed, other values mean not compeleted
                        {
                            command = connection.CreateCommand();
                            command.CommandText =
                                "SELECT Quantity,InventoryID,Completed " +
                                "FROM PurchaseOrder WHERE PurchaseOrderID = @orderID;";
                            command.Parameters.AddWithValue("@orderID", thisValue);
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                //Do some checks to make sure we are performing the transaction on correct record
                                int quantity = (int)reader["Quantity"];
                                int inventoryID_local = (int)reader["InventoryID"];
                                bool isCompleted = ((string)reader["Completed"]) == "Y";
                                reader.Close();
                                if (inventoryID == inventoryID_local)
                                {
                                    if (!isCompleted)
                                    {
                                        //Now we have confirmed that the purchase order record we found is for this inventoryID, and it is also not completed yet,
                                        //So we will process this record information now, set the completed property for this record to true
                                        command = connection.CreateCommand();
                                        command.CommandText =
                                            "UPDATE Inventory SET Quantity = Quantity + @quantity WHERE InventoryID = @inventoryID;" +
                                            "UPDATE PurchaseOrder SET Completed = 'Y' WHERE PurchaseOrderID = @purchaseID;";//Update the quantity, and set completed to true
                                        command.Parameters.AddWithValue("@quantity", quantity);
                                        command.Parameters.AddWithValue("@inventoryID", inventoryID);
                                        command.Parameters.AddWithValue("@purchaseID", thisValue);
                                        if (command.ExecuteNonQuery() > 0)
                                        {
                                            //Now we need to add this transaction to Transaction table as well
                                            //command = connection.CreateCommand();//Why not use the already created command
                                            command.CommandText = "INSERT INTO InventoryTransaction(TransactionDate,Quantity,TransactType,InventoryID) " +
                                                "VALUES (@date,@quantity,'A',@inventoryID);";
                                            command.Parameters.AddWithValue("@date", DateTime.Now);
                                            if (command.ExecuteNonQuery() == 1)
                                            {
                                                Default.ShowInfo("Operation(s) completed successfully");
                                            }
                                            else Default.ShowError("Purchase Order is processed successfully,\nBut could not add this transaction record to log(s).");
                                            RefreshGridView();
                                        }
                                        else Default.ShowError("An error occured on the server side.");
                                    }
                                    else Default.ShowError("This purchase order has already been completed.");
                                }
                                else Default.ShowError("The Purchase Order exists, but is for another inventory item.");
                            }
                            else Default.ShowError("No such Purchase Order Exists.");
                            if (!reader.IsClosed) reader.Close();
                        }
                        break;//Add Inventory Item -- we need to finish the purchase order form first
                    case 1:
                        if (onHandQuantity >= thisValue)
                        {
                            command = connection.CreateCommand();
                            DateTime now = DateTime.Now;
                            command.CommandText = "INSERT INTO InventoryTransaction(TransactionDate, Quantity, TransactType, InventoryID) VALUES" +
                                "(@date,@quantity,@type,@id);" +
                                "UPDATE Inventory SET Quantity = Quantity - @quantity WHERE InventoryID = @id";
                            command.Parameters.AddWithValue("@date", now);
                            command.Parameters.AddWithValue("@quantity", thisValue);
                            command.Parameters.AddWithValue("@type", 'R');
                            command.Parameters.AddWithValue("@id", inventoryID);
                            if (command.ExecuteNonQuery() > 0)
                            {
                                RefreshGridView();
                                Default.ShowInfo("Operation completed successfully.");
                            }
                            else Default.ShowError("SERVER error, cannot complete the transaction.");
                        }
                        else
                            Default.ShowError("Not enough quantity on hand to perform this transaction.");
                        break;//Remove Inventory Item
                    default:
                        Default.ShowError("This is not supposed to be seen by end user");
                        break;
                }
            }
            else Default.ShowError("The Specified Inventory ID does not exists.");
            if (!reader.IsClosed) reader.Close();
        }
        private void RefreshGridView()
        {
            if (!String.IsNullOrEmpty(itemNameTextBox.Text))
            {
                int count = updateInventoryGrid.SelectedRows.Count,
                    count2 = count > 0 ? updateInventoryGrid.SelectedRows[0].Index : -1;
                itemNameFindButton_Click(null, null);
                if (count2 != -1)
                {
                    DataGridViewRow rc =
                       updateInventoryGrid.Rows[count2 < updateInventoryGrid.Rows.Count ? count2 : 0];
                    rc.Selected = true;
                    inventoryID.Value = (int)rc.Cells[0].Value;
                }
            }
        }
        private void UpdateInventory_Load(object sender, EventArgs e)
        {
            transactionType.SelectedIndex = 0;
            toolTip1.SetToolTip(itemNameFindButton, "Find is only used to find the inventory item ID,\nNot required if you already have the ID");
        }
    }
}
