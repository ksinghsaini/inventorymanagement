DROP DATABASE Project;
GO
CREATE DATABASE Project;
GO
USE Project;
GO
--Make sure that the block is aligned to 1024 bytes, so that multiple of block falls on 1024 byte boundary
CREATE TABLE Inventory
			(InventoryID INTEGER PRIMARY KEY IDENTITY(1,1), --4
			Name	 VARCHAR(60) NOT NULL, --60
			Quantity	 INTEGER  NOT NULL, --4
			DateUpdated		Date, --Date is 8 bytes storage
			DaysToExpiry INTEGER, --4
			Category VARCHAR(40) NOT NULL, --40
			TagInfo	  VARCHAR(8), --8 UNUSED, is only used to set user information
			--Total Block Size is 128, which is 128*8=1024 block, so a single disk access can fetch 8-16 block(s) of data
			);

--Category
--Raw-Material
--Work-In-Progress
--Finished-Goods
--Packing-Material

GO
CREATE TABLE Vendor
			(VendorID INTEGER PRIMARY KEY  IDENTITY(1,1), --4 bytes
			Name		  VARCHAR(30) NOT NULL, --40 Bytes
			Address		  VARCHAR(89) NOT NULL, --128 Bytes, we store address of the vendor in case we need to send invoice by Mail
			PhoneNumber NUMERIC(10,0) CHECK ( PhoneNumber >=1000000000)
			-- 9 Bytes, What???
			--Totalling 89+30+9=128 bytes
			);

GO

CREATE TABLE MappingTable
			(--Mapping table is the table, that is used to implement a many-to-many relationship between two tables,
			 --as the database has no inbuild many-to-many relationship, many-to-many is primary-to-foreign, or one-to-many realtionship on both sides of the junction table
			 MappingID INTEGER PRIMARY KEY  IDENTITY(1,1),
			 InventoryID	INTEGER  NOT NULL,
			 VendorID		INTEGER  NOT NULL,
			 --We also need to store other variables associated with the many-to-many relationship
			 ItemPrice NUMERIC(16,4) NOT NULL --9 Bytes Storage
			 );
GO

DROP TABLE IF EXISTS dbo.PurchaseOrder;
CREATE TABLE PurchaseOrder(
	PurchaseOrderId INTEGER PRIMARY KEY  IDENTITY(1,1),
	Quantity INTEGER NOT NULL,
	PurchaseDate DATE NOT NULL,
	InventoryID INTEGER NOT NULL,-- must link to a inventory record
	VendorID INTEGER NOT NULL,--also must link to a vendor record
	Completed CHAR NOT NULL
	);

GO

DROP TABLE IF EXISTS InventoryTransaction;
CREATE TABLE InventoryTransaction(
	InventoryTransactionID INTEGER PRIMARY KEY  IDENTITY(1,1),
	TransactionDate DATE NOT NULL,
	Quantity INTEGER NOT NULL,
	TransactType CHAR CHECK (TransactType IN ( 'A','R')),
	InventoryID INTEGER FOREIGN KEY REFERENCES Inventory(InventoryID)
	);

GO

ALTER TABLE MappingTable ADD CONSTRAINT fk_Inventory_InventoryID FOREIGN KEY(InventoryID) REFERENCES Inventory(InventoryID);
ALTER TABLE MappingTable ADD CONSTRAINT fk_Vendor_VendorID FOREIGN KEY(VendorID) REFERENCES Vendor(VendorID);
ALTER TABLE Inventory ADD CONSTRAINT unique_Name UNIQUE(Name);
ALTER TABLE Vendor ADD CONSTRAINT unique_VendorName UNIQUE(Name);
ALTER TABLE PurchaseOrder ADD CONSTRAINT fk_PurchaseOrder_inventoryID FOREIGN KEY(InventoryID) REFERENCES Inventory(InventoryID);
ALTER TABLE PurchaseOrder ADD CONSTRAINT fk_PurchaseOrder_vendorID FOREIGN KEY(VendorID) REFERENCES Vendor(VendorID);

--I added some queries and other working people, who are working on this project along with me needs to see those changes too, so I need to update it with the online git server.