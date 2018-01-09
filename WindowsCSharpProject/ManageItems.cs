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
    public partial class ManageItems : Form
    {
        SqlConnection sqlConnection;
        public ManageItems(SqlConnection connection)
        {
            InitializeComponent();
            sqlConnection = connection;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            String commandText = "SELECT InventoryID,Name,Quantity FROM Inventory WHERE ";
            object searchFormat = 0;
            if (!String.IsNullOrEmpty(searchText.Text)
                || searchType.SelectedIndex == 2)
            {
                switch (searchType.SelectedIndex)
                {
                    case 0://Which is the index for Primary key 
                        commandText += "InventoryID = @searchText";
                        int result = 0;
                        if (!int.TryParse(searchText.Text, out result))
                        {
                            MessageBox.Show("You have selected search type InventoryID, which require search text to be an integer",
                                "Invalid Search Text Data Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else searchFormat = result;
                        break;
                    case 1://Which is the index for Item Name
                        commandText += " Name LIKE @searchText";
                        searchFormat = "%" + searchText.Text + "%";
                        break;
                    case 2:
                        commandText += " '1' = '1'";
                        break;
                    default://Other cases are invalid, and show an error dialog, if such case occurs
                        MessageBox.Show("Please select a valid search type.", "Search Type Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = commandText;
                command.Parameters.AddWithValue("@searchText", searchFormat);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("NO result found for given search criteria", "NO Result found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                reader.Close();
            }
            else
            {
                MessageBox.Show("Search Text cannot be null or empty", "Search Text Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void addItem_Click(object sender, EventArgs e)
        {
            String name = nameTextBox.Text;
            decimal quantity = quantityNumeric.Value;
            decimal dte = dteNumeric.Value;
            String category = (String)categoryComboBox.SelectedItem;
            if (String.IsNullOrEmpty(name)) { Default.ShowError("Item Name cannot be null or empty!"); return; }
            if (quantity < 1) { Default.ShowError("Quantity cannot be less than or equals zero."); return; }
            if (String.IsNullOrEmpty(category)) { Default.ShowError("Select a valid category type."); return; }
            DateTime dateTime = DateTime.Now;
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO Inventory(Name, Quantity, DateUpdated, DaysToExpiry, Category) VALUES " +
                "(@name,@quantity,@dateUpdated,@dateToExpire,@category)";
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@dateUpdated", dateTime);
            if (dte == 0) dte = -1;
            command.Parameters.AddWithValue("@dateToExpire", dte);
            command.Parameters.AddWithValue("@category", category);
            try
            {
                if (command.ExecuteNonQuery() > 0)
                    MessageBox.Show("Added the item to the database", "SUCCESS", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            catch (SqlException)
            {
                MessageBox.Show("Could not add this item to the tracking list,\nPOSSIBLE CAUSE: Another item with same name already exists"
                    , "ERROR", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete the record with ID " + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "?\n" +
                "Deleting a record also remove all data associated.", "Delete Record"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = 
                    "DELETE FROM MappingTable WHERE InventoryID = @id;" +
                    "DELETE FROM InventoryTransaction WHERE InventoryID = @id;" +
                    "DELETE FROM PurchaseOrder WHERE InventoryID = @id;"+
                    "DELETE FROM Inventory WHERE InventoryID = @id;";
                sqlCommand.Parameters.AddWithValue("@id", dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Record has been deleted!");
                    dataGridView1.Rows.RemoveAt(e.RowIndex);

                }
                else MessageBox.Show("We could not remove this record, an error occured!");
            }
        }

        private void ManageItems_Load(object sender, EventArgs e)
        {
            quantityNumeric.Value = new Random().Next(20, 20000);
        }
    }
}
