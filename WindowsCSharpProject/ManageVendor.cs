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
    public partial class ManageVendor : Form
    {
        List<Store> store1;
        SqlConnection connection;
        int lastPointer = -1;
        VendorRecord record;
        List<Store> original;
        List<int> deletions;
        // int vendorID;
        bool tipshown = false;
        public ManageVendor(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            store1 = new List<Store>();
        }
        private void UpdateProductList()
        {
            addPageListBox.Items.Clear();
            for (int i = 0; i < store1.Count; i++)
                addPageListBox.Items.Add(store1[i].name + " / "
                    + store1[i].price);
        }
        private void ManageVendor_Load(object sender, EventArgs e)
        {
            phoneNumber.Value = (decimal)(1000000000 + (8999999999 * new Random().NextDouble()));
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT TOP 10 Name FROM Inventory";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (!productNameComboBox.Items.Contains(reader["name"]))
                {
                    productNameComboBox.Items.Add(reader["Name"]);
                    searchComboBox.Items.Add(reader["Name"]);
                }
            }
            reader.Close();
        }
        private void clearProducts_Click(object sender, EventArgs e)
        {
            store1.Clear();
            UpdateProductList();
        }
        private void addProducts_Click(object sender, EventArgs e)
        {
            //TextBox4, NumericUpDown1
            AddStoreToList(productNameComboBox.Text, productPriceNumericUpDown.Value, store1);
            UpdateProductList();
        }
        private Store AddStoreToList(String name, decimal price, List<Store> list)
        {
            if (!String.IsNullOrEmpty(name))
            {
                if (price > 0)
                {
                    Store store = new Store(name, price);
                    if (AddToListSql(list, store, name))
                        return store;
                    else return null;
                }
                else Default.ShowError("Cannot add an item with $0 price", "Price Invalid");
            }
            else Default.ShowError("Cannot add an item will empty Name", "Name Empty");
            return null;
        }
        private bool AddToListSql(List<Store> list, Store store, string name)
        {
            for (int i = 0; i < list.Count; i++) if (list[i].name.Equals(store.name))
                { MessageBox.Show("Cannot add a duplicate record", "Error"); return false; }
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT InventoryID FROM Inventory where name = @name";
            command.Parameters.AddWithValue("@name", name);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                store.inventoryID = (int)reader["inventoryID"];
                list.Add(store);
                reader.Close();
                return true;
            }
            else Default.ShowError(
                "Cannot assign this product name to the vendor\n" +
                "Cause: No such product name exists!");
            reader.Close();
            return false;
        }

        private void searchOnAddPage_Click(object sender, EventArgs e)
        {
            SearchAndPut(productNameComboBox);
        }

        private void SearchAndPut(ComboBox commonCB)
        {
            if (String.IsNullOrEmpty(commonCB.Text))
                MessageBox.Show("Enter some partial text into the adjacent combobox to search");
            else
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT InventoryID, Name FROM Inventory WHERE Name like @name";
                command.Parameters.AddWithValue("@name",
                    String.Format("%{0}%", commonCB.Text));
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    commonCB.Items.Clear();
                    while (reader.Read())
                        if (!commonCB.Items.Contains(reader["Name"]))
                            commonCB.Items.Add(reader["Name"]);
                    if (commonCB.Items.Count > 0)
                        commonCB.SelectedIndex = 0;
                }
                else Default.ShowError("No result for given text. Try again with different value.");
                reader.Close();
            }
        }
        private int AddIntoMappingTable(List<Store> list, int vendorID)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO MappingTable (InventoryID, VendorID, ItemPrice) VALUES ";
            for (int i = 0; i < list.Count; i++)
            {
                command.CommandText = String.Concat(command.CommandText,
                    String.Format("{1} (@inventory{0},@vendor{0},@price{0}) ", i, i != 0 ? "," : ""));
                command.Parameters.AddWithValue(String.Format("@inventory{0}", i), list[i].inventoryID);
                command.Parameters.AddWithValue(String.Format("@vendor{0}", i), vendorID);
                command.Parameters.AddWithValue(String.Format("@price{0}", i), list[i].price);
            }
            return (command.ExecuteNonQuery());
        }
        private void addVendor_Click(object sender, EventArgs e)
        {
            String name = nameTextBox.Text.ToString();
            String address = addressTextBox.Text.ToString();
            long phoneNumber = (long)this.phoneNumber.Value;
            if (String.IsNullOrEmpty(name)) { Default.ShowError("Name for vendor cannot be empty!"); return; }
            if (String.IsNullOrEmpty(address)) { Default.ShowError("Address for vendor cannot be empty!"); return; }
            if (store1.Count == 0)
            {
                if (
                    MessageBox.Show(
                        "You linked \"NO\" products to the vendor\n" +
                        "Maybe you might have missed doing following: \n" +
                        "1. Clicking \"Assign Product to Vendor\" Button\n" +
                        "If not linking any product was what you intended, hit OK."
                        , "No Links",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question) == DialogResult.Cancel) return;
            }
            //That is all what is required when creating a record for a vendor, but what follows is a more
            //important stuff, particularly the one which help in creating a many-to-many relationship
            SqlCommand command = connection.CreateCommand();
            command.CommandText = //"BEGIN TRANSACTION;" +
                "INSERT INTO Vendor VALUES(@name,@address,@phone)";
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@phone", phoneNumber);
            try
            {
                if (command.ExecuteNonQuery() > 0)
                {
                    if (store1.Count > 0)
                    {
                        SqlCommand command_c = connection.CreateCommand();
                        command_c.CommandText = "SELECT IDENT_CURRENT('Vendor') AS \"SCOPE_IDENTITY\";";
                        //Found this on microsoft website, as a good solution to get the last identity value generated across current scope
                        SqlDataReader reader = command_c.ExecuteReader();
                        if (reader.Read())
                        {
                            int identity = (int)((decimal)reader["SCOPE_IDENTITY"]);
                            //Identity is the current working auto_increment
                            reader.Close();
                            int l = AddIntoMappingTable(store1, identity);
                            if ((l) == store1.Count)
                            {
                                Default.ShowInfo(String.Format("The Vendor \"{0}\" has now been added, and linked to {1} products.",
                                    name, l), "SUCCESS");
                            }
                            else Default.ShowError("Failure when adding records to the MappingTable, inserted: " + l, "FAILURE");
                        }
                        else
                            Default.ShowError("Could not get the identity for the last row inserted");
                        if (!reader.IsClosed) reader.Close();
                    }
                    else
                    {
                        Default.ShowInfo(
                            String.Format("The Vendor {0} has now been added but is not linked to any product(s).", name),
                                  "SUCCESS");
                    }
                }
                else MessageBox.Show("Fatal error, cannot add record to the database", "ERROR",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException)
            {
                Default.ShowError("UNIQUE KEY violation, you cannot have two vendors with same name");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int vendorID = (int)deleteNumericUpDown.Value;
            //This is the critical section of the code, as here we are deleting all the vendor information, and all the product info that is linked to the vendor
            //We must all tell our user that we have unlinked (x) number of product references from deleting the vendor
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) as \"count_total\" FROM MappingTable WHERE VendorID = @vendorID";
            command.Parameters.AddWithValue("@vendorID", vendorID);
            SqlDataReader reader = command.ExecuteReader();
            int records = 0;
            DialogResult result = DialogResult.Yes;
            if (reader.Read() && (records = (int)reader["count_total"]) > 0)
            {
                result = MessageBox.Show(
                    String.Format("This vendor is currently serving {0} products.\n" +
                    "Deleting the vendor will also delete all link data.\n" +
                    "Are you sure?", records),
                    "CONFIRMATION",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            reader.Close();
            if (result == DialogResult.Yes)//since no change will happens to result if hasRows is false, this will always be executed
            {
                String delete = "DELETE FROM PurchaseOrder WHERE VendorID = @vendorID;" +
                    "DELETE FROM Vendor WHERE VendorID = @vendorID;";
                command.CommandText = records > 0 ? "DELETE FROM MappingTable WHERE VendorID = @vendorID;" : delete;
                //No confirmation, no questions asked, just purge the record
                //There is a problem here as teh vendor records are purged from the mapping table, they are not removed from the vendor table
                //Try splitting the statement into two statements;/or try vendorID param to change to vendorID2, NO!!!
                if (command.ExecuteNonQuery() > 0)
                {
                    bool success = true;
                    if (records > 0)
                    {
                        command.CommandText = delete;
                        if (!(command.ExecuteNonQuery() > 0)) success = false;
                    }
                    if (success)
                        MessageBox.Show(String.Format(
                            "We have purged the vendor record clean, ID:{0}, Links:{1}"
                            , vendorID, records), "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable dataTable = ((DataTable)deletePageGridView.DataSource);
                    if (dataTable != null
                        && dataTable.Rows.Count > lastPointer)
                        dataTable.Rows[lastPointer].Delete();
                }
                else Default.ShowError("No Vendor exists for given ID");
            }
        }

        private void searchDeletePage_Click(object sender, EventArgs e)
        {
            string vendorName = vendorNameTextBox.Text;
            if (String.IsNullOrEmpty(vendorName))
                Default.ShowInfo(
                    "Enter something to start search\n" +
                    "The search performed is partial:contains()");
            else
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText =
                    "SELECT Vendor.VendorID,Vendor.Name,Vendor.PhoneNumber " +
                    "FROM Vendor " +
                    "WHERE Name LIKE @name";
                command.Parameters.AddWithValue("@name", String.Format("%{0}%", vendorName));
                DataTable table = new DataTable();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
                    deletePageGridView.DataSource = table;
                    if (table.Rows.Count > 0)
                    {
                        deleteNumericUpDown.Value = (int)deletePageGridView.Rows[0].Cells[0].Value;
                        lastPointer = 0;
                    }
                }
                else
                {
                    deletePageGridView.DataSource = null;
                    Default.ShowError("No results found for given vendor name", "NO RESULT FOUND");
                }
                reader.Close();
            }
        }
        private void TabUpdateSwitch(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 2)
            {
                vendorIDNumericUpDown.Value = 0;
                updateGroupBox.Enabled = false;
                commitButton.Enabled = discardButton.Enabled = false;
            }
        }
        private void searchButtonUpdateClick(object sender, EventArgs e)
        {
            SearchAndPut(searchComboBox);
        }

        private void addProductButtonClick(object sender, EventArgs e)
        {
            Store s = AddStoreToList(searchComboBox.Text, priceNumericUpDown.Value, record.stores);
            if (s != null)
            {
                s.newRecord = true;
                AddToListBox(s);
            }
        }

        private void Find_Click(object sender, EventArgs e)
        {
            //Every time we change the record, we wipe away all the pending changes
            deletions = new List<int>();
            original = new List<Store>();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Vendor WHERE VendorID = @vendorID";
            command.Parameters.AddWithValue("@vendorID", vendorIDNumericUpDown.Value);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                updateGroupBox.Text = "Vendor Properties - " + reader["Name"];
                record = new VendorRecord(
                    (int)reader["vendorID"],
                    (long)((decimal)reader["phoneNumber"]),
                    (string)reader["name"],
                    (string)reader["address"]);
                //Now after we have all the record information fetch information on mapping to the inventory table
                reader.Close();
                command.CommandText =
                    "SELECT Inventory.Name, MappingTable.InventoryID, MappingTable.MappingID, MappingTable.VendorID, MappingTable.ItemPrice " +
                    "FROM MappingTable " +
                    "INNER JOIN Inventory " +
                    "ON MappingTable.InventoryID = Inventory.InventoryID " +
                    "WHERE VendorID = @vendorID";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Store s1 = new Store((string)reader["Name"], (decimal)reader["ItemPrice"]);
                    s1.inventoryID = (int)reader["InventoryID"];
                    record.stores.Add(s1);
                    original.Add(s1);
                }
                updateGroupBox.Enabled =
                commitButton.Enabled =
                discardButton.Enabled = true;
                //Now fill the listBox
                updatePageListView.Items.Clear();
                foreach (Store s in record.stores)
                    AddToListBox(s);
            }
            else
            {
                Default.ShowError("No record for this vendor ID exists");
                updateGroupBox.Enabled =
                commitButton.Enabled =
                discardButton.Enabled = false;
            }
            reader.Close();
        }
        private void AddToListBox(Store store)
        {
            updatePageListView.Items.Add(new ListViewItem(new string[]{(store.newRecord ? -1 : store.inventoryID).ToString(),
                store.name.ToString(), store.price.ToString() }));
        }
        private void unlink_Click(object sender, EventArgs e)
        {
            if (!tipshown)
            {
                tipshown = true;
                Default.ShowInfo("Just a note.\nYou cannot add the same item again before commit.");
            }
            if (updatePageListView.CheckedItems.Count >= 0)
            {
                 foreach (ListViewItem i in updatePageListView.CheckedItems)
                    RemoveFromListBox(i.Index);
            }
        }

        private void RemoveFromListBox(int index)
        {
            int splitFirst = int.Parse(updatePageListView.Items[index].Text);
            String recordName = 
                updatePageListView.Items[index].SubItems[1].Text;
            //Get the index of the string from the deletions
            if (splitFirst > 0) { 
                deletions.Add(splitFirst);
            }
            else
                RemoveByName(record.stores, recordName);
            updatePageListView.Items.RemoveAt(index);
        }

        private void Commit_Click(object sender, EventArgs e)
        {
            List<Store> newItems = new List<Store>(record.stores.ToArray());
            foreach (Store store in original)
                newItems.Remove(store);
            bool fresh = true, nochange = true;
            if (newItems.Count > 0)
            {
                nochange = false;
                if (newItems.Count != AddIntoMappingTable(newItems, (int)record.vendorID))
                {
                    fresh = false;
                    //So we have some new mappings to add, remember, we only need to add the mapping as the record in vendor table already exists
                    Default.ShowError("Some error occured while linking products, Possible data corruption", "ERROR");
                }
            }
            if (deletions.Count > 0)
            {
                nochange = false;
                SqlCommand command = connection.CreateCommand();
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < deletions.Count; i++)
                {
                    builder.Append(i > 0 ? "," : String.Empty);
                    builder.Append(deletions[i]);
                }
                //We are using both prepared sql and concatenation to reduce the amount of code required
                command.CommandText = String.Format(
                    "DELETE FROM MappingTable WHERE VendorID = @vendorID AND InventoryID IN ({0})", builder.ToString());
                command.Parameters.AddWithValue("@vendorID", record.vendorID);//No way if there is nothing in myrecord.stores, you can delete anything from db
                if (!(command.ExecuteNonQuery() > 0))
                {
                    Default.ShowError("Some error occured while deleting records, Possible data corruption", "ERROR");
                    fresh = false;
                }
            }
            if (nochange)
                Default.ShowInfo("No change detected");
            else if (fresh)
            {
                Default.ShowInfo("Changes committed successfully!");
                Find_Click(null, null);
            }
        }

        private void RemoveByName(List<Store> s, string name)
        {
            foreach (Store s_ in s)
            {
                if (s_.name.Equals(name))
                {
                    s.Remove(s_); break;
                }
            }
        }

        private void Discard_Click(object sender, EventArgs e)
        {
            record.stores = new List<Store>(original.ToArray());
            //  updatePageListBox.Items.Clear();
            foreach (Store s in record.stores)
                AddToListBox(s);
            Default.ShowInfo("Reset complete");
        }

        private void deletePageGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                deleteNumericUpDown.Value = (int)deletePageGridView.Rows[e.RowIndex].Cells[0].Value;
                lastPointer = e.RowIndex;
            }
        }
    }
}
