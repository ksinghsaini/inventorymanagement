using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsCSharpProject
{
    namespace Controllers
    {
        public class Store
        {
            public string name;
            public int inventoryID;
            public decimal price;
            public bool newRecord = false;
            public Store(string name, decimal price)
            {
                this.name = name;
                this.price = price;
            }
        }
        public class VendorRecord
        {
            string name, 
                address;
            long phoneNumber;
            public List<Store> stores;
            public long vendorID;
            public VendorRecord(long vendorID, long phoneNumber,
                string name, string address)
            {
                this.vendorID = vendorID;
                this.phoneNumber = phoneNumber;
                this.name = name;
                this.address = address;
                this.stores = new List<Store>();
            }
        }
        class Default
        {
            public static void ShowInfo(String message, String head = "INFORMATION")
            {
                MessageBox.Show(message, head,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            public static void ShowError(String message, String head = "ERROR")
            {
                MessageBox.Show(message,
                    head, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
