using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BirdShopManagement
{
    internal class DatabaseInitializer
    {
        public static void Initialize()
        {
            Console.WriteLine("Initializing Bird Shop Database...");

            try
            {
                DataAccess da = new DataAccess();

                // 1️⃣ Users
                if (!TableExists(da, "Users"))
                {
                    CreateUsersTable(da);
                    InsertDemoUsers(da);
                }

                // 2️⃣ Categories
                if (!TableExists(da, "Categories"))
                {
                    CreateCategoriesTable(da);
                    InsertDemoCategories(da);
                }

                // 3️⃣ Products
                if (!TableExists(da, "Products"))
                {
                    CreateProductsTable(da);
                    InsertDemoProducts(da);
                }

                // 4️⃣ Orders
                if (!TableExists(da, "Orders"))
                {
                    CreateOrdersTable(da);
                    InsertDemoOrders(da);
                }

                // 5️⃣ OrderItems
                if (!TableExists(da, "OrderItems"))
                {
                    CreateOrderItemsTable(da);
                    InsertDemoOrderItems(da);
                }

                Console.WriteLine("Bird Shop Database Ready ✅");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database init failed:\n" + ex.Message);
            }
        }

        // =========================
        // COMMON
        // =========================
        private static bool TableExists(DataAccess da, string tableName)
        {
            string sql = @"
                SELECT COUNT(*) 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_NAME = @table";

            SqlCommand cmd = new SqlCommand(sql, da.Sqlcon);
            cmd.Parameters.AddWithValue("@table", tableName);

            return (int)cmd.ExecuteScalar() > 0;
        }

        // =========================
        // USERS
        // =========================
        private static void CreateUsersTable(DataAccess da)
        {
            string sql = @"
            CREATE TABLE Users (
                Id INT IDENTITY(1,1) PRIMARY KEY,
                Name VARCHAR(100) NOT NULL,
                Email VARCHAR(150) NOT NULL UNIQUE,
                Password VARCHAR(255) NOT NULL,
                Role VARCHAR(10) NOT NULL CHECK (Role IN ('Admin','Employee','Customer')),
                CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
            )";

            da.ExecuteUpdateQuery(sql);
        }

        private static void InsertDemoUsers(DataAccess da)
        {
            string sql = @"
            INSERT INTO Users (Name, Email, Password, Role)
            VALUES
                ('Admin', 'admin@birdshop.com', '1234', 'Admin'),
                ('Employee1', 'emp1@birdshop.com', '1234', 'Employee'),
                ('Customer1', 'cust1@birdshop.com', '1234', 'Customer'),
                ('Customer2', 'cust2@birdshop.com', '1234', 'Customer')
            ";

            da.ExecuteUpdateQuery(sql);
        }

        // =========================
        // CATEGORIES
        // =========================
        private static void CreateCategoriesTable(DataAccess da)
        {
            string sql = @"
            CREATE TABLE Categories (
                Id INT IDENTITY(1,1) PRIMARY KEY,
                Name VARCHAR(100) NOT NULL,
                Description TEXT
            )";

            da.ExecuteUpdateQuery(sql);
        }

        private static void InsertDemoCategories(DataAccess da)
        {
            string sql = @"
            INSERT INTO Categories (Name, Description)
            VALUES
                ('Parrot', 'Colorful talking birds'),
                ('Pigeon', 'Domestic pigeons'),
                ('Finch', 'Small singing birds')
            ";

            da.ExecuteUpdateQuery(sql);
        }

        // =========================
        // PRODUCTS (BIRDS)
        // =========================
        private static void CreateProductsTable(DataAccess da)
        {
            string sql = @"
            CREATE TABLE Products (
                Id INT IDENTITY(1,1) PRIMARY KEY,
                Name VARCHAR(150) NOT NULL,
                CategoryId INT NOT NULL,
                Price DECIMAL(10,2) NOT NULL,
                Stock INT NOT NULL,
                AgeInMonths INT,
                HealthStatus VARCHAR(15) DEFAULT 'Good'
                    CHECK (HealthStatus IN ('Excellent','Good','Average')),
                
                CONSTRAINT FK_Products_Categories
                    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
            )";

            da.ExecuteUpdateQuery(sql);
        }

        private static void InsertDemoProducts(DataAccess da)
        {
            string sql = @"
            INSERT INTO Products (Name, CategoryId, Price, Stock, AgeInMonths, HealthStatus)
            VALUES
                ('African Grey Parrot', 1, 15000, 5, 12, 'Excellent'),
                ('Budgerigar', 1, 3000, 10, 6, 'Good'),
                ('White Pigeon', 2, 2000, 20, 8, 'Good'),
                ('Zebra Finch', 3, 1200, 15, 4, 'Average')
            ";

            da.ExecuteUpdateQuery(sql);
        }

        // =========================
        // ORDERS
        // =========================
        private static void CreateOrdersTable(DataAccess da)
        {
            string sql = @"
            CREATE TABLE Orders (
                Id INT IDENTITY(1,1) PRIMARY KEY,
                CustomerId INT NOT NULL,
                OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP,
                Status VARCHAR(15) DEFAULT 'Pending'
                    CHECK (Status IN ('Pending','Approved','Delivered')),
                TotalAmount DECIMAL(10,2),

                CONSTRAINT FK_Orders_Users
                    FOREIGN KEY (CustomerId) REFERENCES Users(Id)
            )";

            da.ExecuteUpdateQuery(sql);
        }

        private static void InsertDemoOrders(DataAccess da)
        {
            string sql = @"
            INSERT INTO Orders (CustomerId, Status, TotalAmount)
            VALUES
                (3, 'Pending', 18000),
                (4, 'Approved', 2000)
            ";

            da.ExecuteUpdateQuery(sql);
        }

        // =========================
        // ORDER ITEMS
        // =========================
        private static void CreateOrderItemsTable(DataAccess da)
        {
            string sql = @"
            CREATE TABLE OrderItems (
                Id INT IDENTITY(1,1) PRIMARY KEY,
                OrderId INT NOT NULL,
                ProductId INT NOT NULL,
                Quantity INT NOT NULL,
                Price DECIMAL(10,2) NOT NULL,

                CONSTRAINT FK_OrderItems_Orders
                    FOREIGN KEY (OrderId) REFERENCES Orders(Id)
                    ON DELETE CASCADE,

                CONSTRAINT FK_OrderItems_Products
                    FOREIGN KEY (ProductId) REFERENCES Products(Id)
            )";

            da.ExecuteUpdateQuery(sql);
        }

        private static void InsertDemoOrderItems(DataAccess da)
        {
            string sql = @"
            INSERT INTO OrderItems (OrderId, ProductId, Quantity, Price)
            VALUES
                (1, 1, 1, 15000),
                (1, 2, 1, 3000),
                (2, 3, 1, 2000)
            ";

            da.ExecuteUpdateQuery(sql);
        }
    }
}
