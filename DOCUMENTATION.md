# GreenLife Organic Store Management System - Complete Documentation

## Table of Contents
1. [Introduction](#1-introduction)
2. [System Requirements](#2-system-requirements)
   - 2.1 [Hardware Requirements](#21-hardware-requirements)
   - 2.2 [Software Requirements](#22-software-requirements)
3. [Detailed Instructions to Run](#3-detailed-instructions-to-run)
4. [System Architecture](#4-system-architecture)
   - 4.1 [Presentation Layer](#41-presentation-layer)
   - 4.2 [Business Logic Layer](#42-business-logic-layer)
   - 4.3 [Data Layer](#43-data-layer)
5. [Database Design](#5-database-design)
6. [User Interface Design](#6-user-interface-design)
   - 6.1 [Login Interface](#61-login-interface)
   - 6.2 [Admin Dashboard](#62-admin-dashboard)
   - 6.3 [Customer Dashboard](#63-customer-dashboard)
7. [Programming Techniques Used](#7-programming-techniques-used)
8. [User Guide](#8-user-guide)
   - 8.1 [Admin User Guide](#81-admin-user-guide)
   - 8.2 [Customer User Guide](#82-customer-user-guide)
9. [Class Relationships](#9-class-relationships)
   - 9.1 [Description of Classes' Properties and Methods](#91-description-of-classes-properties-and-methods)
10. [Explanation of Search Algorithms Used](#10-explanation-of-search-algorithms-used)
11. [Personal Reflection](#11-personal-reflection)
    - 11.1 [Experience with C#](#111-experience-with-c)
    - 11.2 [Experience with Visual Studio](#112-experience-with-visual-studio)
    - 11.3 [Challenges Faced and Solutions Applied](#113-challenges-faced-and-solutions-applied)
    - 11.4 [Personal Growth and Learning Outcome](#114-personal-growth-and-learning-outcome)
12. [Conclusion](#12-conclusion)
13. [References](#13-references)

---

## 1. Introduction

**GreenLife Organic Store Management System** is a comprehensive Windows Forms desktop application developed using C# and .NET 10.0 framework. The system is designed to facilitate the complete management of an organic product store, providing distinct functionalities for administrators and customers.

### Purpose
The primary purpose of this system is to:
- Enable efficient management of organic products inventory
- Facilitate seamless online shopping experience for customers
- Provide comprehensive order tracking and management
- Generate detailed sales and inventory reports
- Maintain secure user authentication and authorization

### Scope
The system encompasses:
- **User Management**: Registration, authentication, and role-based access control
- **Product Management**: CRUD operations for organic products with categorization
- **Shopping Cart**: Add, update, and remove items functionality
- **Order Processing**: Complete checkout workflow with order tracking
- **Inventory Management**: Stock monitoring with low-stock alerts
- **Reporting**: Sales reports and data export capabilities

### Target Users
- **Administrators**: Store managers responsible for product and order management
- **Customers**: End-users who browse products and place orders

---

## 2. System Requirements

### 2.1 Hardware Requirements

**Minimum Requirements:**
- **Processor**: Intel Core i3 or equivalent (2.0 GHz)
- **RAM**: 4 GB
- **Storage**: 500 MB free disk space
- **Display**: 1024 x 768 resolution
- **Network**: Internet connection (for database connectivity)

**Recommended Requirements:**
- **Processor**: Intel Core i5 or higher (2.5 GHz+)
- **RAM**: 8 GB or more
- **Storage**: 1 GB free disk space (SSD preferred)
- **Display**: 1920 x 1080 resolution or higher
- **Network**: Broadband internet connection

### 2.2 Software Requirements

**Required Software:**
- **Operating System**: Windows 10 or Windows 11 (64-bit)
- **Framework**: .NET 10.0 Runtime or SDK
- **Database**: Microsoft SQL Server 2019 or later (Express Edition or higher)
- **SQL Server Instance**: localhost\SQLEXPRESS (default configuration)

**Development Tools (for building from source):**
- Visual Studio 2022 (Community, Professional, or Enterprise)
- JetBrains Rider (alternative IDE)
- .NET 10.0 SDK

**NuGet Dependencies:**
- `System.Data.SqlClient` (v4.8.6) - Database connectivity
- `BCrypt.Net-Next` (v4.0.3) - Password hashing
- `iTextSharp.LGPLv2.Core` (v3.4.23) - PDF generation
- `EPPlus` (v7.0.5) - Excel export functionality

---

## 3. Detailed Instructions to Run

### Step 1: Prerequisites Installation

1. **Install .NET 10.0 SDK:**
   - Download from: https://dotnet.microsoft.com/download/dotnet/10.0
   - Run the installer and follow the installation wizard
   - Verify installation: Open PowerShell and run `dotnet --version`

2. **Install SQL Server:**
   - Download SQL Server 2019 Express from Microsoft's official website
   - During installation, select "SQLEXPRESS" as the instance name
   - Enable mixed mode authentication
   - Remember the SA password (if prompted)

### Step 2: Project Setup

1. **Clone or Extract the Project:**
   ```powershell
   # Navigate to your projects directory
   cd "D:\My Projects"
   
   # If cloning from repository
   git clone [repository-url] GreenLifeOrganicManagementSystem
   ```

2. **Open the Project:**
   - Launch Visual Studio 2022 or JetBrains Rider
   - Open `GreenLifeOrganicManagementSystem.sln`
   - Wait for NuGet packages to restore automatically

3. **Verify Database Configuration:**
   - Open `Data/DatabaseContext.cs`
   - Verify the connection string:
     ```csharp
     Server: localhost\SQLEXPRESS
     Database: GreenLifeDB
     Authentication: Integrated Security (Windows Authentication)
     ```

### Step 3: Build and Run

1. **Restore NuGet Packages:**
   ```powershell
   dotnet restore "GreenLife Organic Management System/GreenLife Organic Management System.csproj"
   ```

2. **Build the Solution:**
   - In Visual Studio: Press `Ctrl + Shift + B` or select Build > Build Solution
   - Or via command line:
     ```powershell
     dotnet build
     ```

3. **Run the Application:**
   - In Visual Studio: Press `F5` to run with debugging or `Ctrl + F5` to run without debugging
   - Or via command line:
     ```powershell
     dotnet run --project "GreenLife Organic Management System/GreenLife Organic Management System.csproj"
     ```

### Step 4: First Time Setup

**Database Auto-Initialization:**
- On first launch, the application automatically:
  1. Creates the `GreenLifeDB` database if it doesn't exist
  2. Creates all required tables (Users, Products, Orders, OrderItems, Reviews, Discounts)
  3. Inserts a default admin account
  4. Populates sample organic products

**Default Admin Credentials:**
- **Username**: `admin`
- **Password**: `admin123`

**Important**: Change the default admin password immediately after first login for security purposes.

### Step 5: Troubleshooting

**Common Issues:**

1. **SQL Server Connection Error:**
   - Ensure SQL Server service is running:
     ```powershell
     Get-Service | Where-Object {$_.Name -like "*SQL*"}
     ```
   - If not running, start the service:
     ```powershell
     Start-Service MSSQL$SQLEXPRESS
     ```

2. **Database Creation Failed:**
   - Verify Windows Authentication is enabled
   - Ensure your Windows user has permissions to create databases
   - Try running Visual Studio as Administrator

3. **Missing Dependencies:**
   - Clear NuGet cache:
     ```powershell
     dotnet nuget locals all --clear
     ```
   - Restore packages again:
     ```powershell
     dotnet restore --force
     ```

---

## 4. System Architecture

The GreenLife Organic Store Management System follows a **Three-Tier Architecture** pattern, separating concerns into distinct layers for better maintainability, scalability, and testability.

### 4.1 Presentation Layer

**Location**: `Forms/` directory

**Responsibility**: User Interface and User Interaction

**Components:**

1. **Authentication Forms:**
   - `LoginForm.cs` - User authentication interface
   - `RegisterForm.cs` - New customer registration

2. **Admin Forms:**
   - `AdminDashboardForm.cs` - Main admin control panel
   - `ProductManagementForm.cs` - Product CRUD operations
   - `CustomerManagementForm.cs` - Customer account management
   - `OrderManagementForm.cs` - Order processing and status updates
   - `ReportsForm.cs` - Sales and inventory reports

3. **Customer Forms:**
   - `CustomerDashboardForm.cs` - Product browsing and shopping
   - `CartForm.cs` - Shopping cart management
   - `CheckoutForm.cs` - Order placement
   - `MyOrdersForm.cs` - Order history and tracking
   - `ProfileForm.cs` - User profile management

**Design Patterns:**
- **Model-View-Pattern**: Forms act as views displaying data from models
- **Event-Driven Architecture**: Button clicks and user interactions trigger business logic
- **Data Binding**: DataGridView controls bound to data sources for automatic updates

### 4.2 Business Logic Layer

**Location**: `Services/` and `Utilities/` directories

**Responsibility**: Business Rules and Application Logic

**Components:**

1. **Services:**
   - `AuthenticationService.cs`
     - User login validation
     - Password verification using BCrypt
     - User registration
     - Session management integration
   
   - `CartService.cs`
     - In-memory shopping cart management
     - Add/remove items
     - Quantity updates
     - Total calculation

2. **Utilities:**
   - `SessionManager.cs`
     - Current user tracking
     - Role-based access control
     - Login state management
   
   - `Validator.cs`
     - Email format validation (Regex)
     - Phone number validation
     - Price and quantity validation
     - Password strength checking
   
   - `ExportHelper.cs`
     - Excel export using EPPlus
     - Report generation
     - Data formatting

**Business Rules Implemented:**
- Password must be at least 6 characters
- Product prices cannot be negative
- Stock quantity cannot go below zero
- Orders must have at least one item
- Low stock threshold is 10 units
- Admin users have full system access
- Customer users can only view their own orders

### 4.3 Data Layer

**Location**: `Data/` and `Data/Repositories/` directories

**Responsibility**: Data Access and Database Operations

**Components:**

1. **DatabaseContext.cs:**
   - Connection string management
   - Database initialization
   - Schema creation
   - Sample data seeding
   - Connection factory method

2. **Repositories (Repository Pattern):**
   
   - `UserRepository.cs`
     - User CRUD operations
     - Username existence check
     - Customer retrieval
   
   - `ProductRepository.cs`
     - Product CRUD operations
     - Search and filtering
     - Category management
     - Stock updates
     - Low stock alerts
   
   - `OrderRepository.cs`
     - Order creation
     - Order history retrieval
     - Order status updates
     - Sales calculations
   
   - `ReviewRepository.cs`
     - Product review management
     - Rating calculations

**Data Access Patterns:**
- **Repository Pattern**: Abstract data access logic
- **ADO.NET**: Direct database access using SqlClient
- **Connection Pooling**: Efficient database connection management
- **Parameterized Queries**: SQL injection prevention

---

## 5. Database Design

### Database Name: `GreenLifeDB`

### Entity Relationship Diagram (ERD) Description:

**Entities and Relationships:**
- Users (1) ---- (N) Orders
- Orders (1) ---- (N) OrderItems
- Products (1) ---- (N) OrderItems
- Products (1) ---- (N) Reviews
- Users (1) ---- (N) Reviews
- Discounts (0..1) ---- (N) Orders

### Table Structures:

#### 1. Users Table
```sql
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Address NVARCHAR(255),
    Role INT NOT NULL,                    -- 0: Admin, 1: Customer
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
)
```

**Purpose**: Stores user account information for both administrators and customers.

**Key Fields:**
- `PasswordHash`: Stores BCrypt-hashed passwords (never plain text)
- `Role`: Enum value determining user access level
- `IsActive`: Soft delete flag

#### 2. Products Table
```sql
CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    Description NVARCHAR(500),
    Price DECIMAL(10,2) NOT NULL,
    StockQuantity INT NOT NULL DEFAULT 0,
    Supplier NVARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE(),
    LastUpdated DATETIME,
    IsActive BIT DEFAULT 1,
    DiscountPercentage DECIMAL(5,2)
)
```

**Purpose**: Maintains organic product inventory.

**Key Fields:**
- `Category`: Product classification (Fruits, Vegetables, Dairy, etc.)
- `DiscountPercentage`: Optional discount (e.g., 10.00 for 10% off)
- `StockQuantity`: Current inventory level

#### 3. Orders Table
```sql
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT NOT NULL,
    OrderDate DATETIME DEFAULT GETDATE(),
    Status INT NOT NULL DEFAULT 0,        -- 0: Pending, 1: Processing, 2: Shipped, 3: Delivered, 4: Cancelled
    TotalAmount DECIMAL(10,2) NOT NULL,
    DiscountAmount DECIMAL(10,2) DEFAULT 0,
    FinalAmount DECIMAL(10,2) NOT NULL,
    ShippingAddress NVARCHAR(255) NOT NULL,
    Notes NVARCHAR(500),
    ShippedDate DATETIME,
    DeliveredDate DATETIME,
    FOREIGN KEY (CustomerId) REFERENCES Users(UserId)
)
```

**Purpose**: Records customer orders.

**Key Fields:**
- `Status`: Order processing stage (enum)
- `FinalAmount`: Total after discounts
- `ShippedDate`, `DeliveredDate`: Tracking timestamps

#### 4. OrderItems Table
```sql
CREATE TABLE OrderItems (
    OrderItemId INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    ProductName NVARCHAR(100) NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL,
    DiscountApplied DECIMAL(10,2),
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
)
```

**Purpose**: Line items for each order (many-to-many relationship between Orders and Products).

**Key Fields:**
- `ProductName`: Snapshot at time of order (in case product name changes)
- `UnitPrice`: Price at time of purchase
- `Subtotal`: Quantity × UnitPrice

#### 5. Reviews Table
```sql
CREATE TABLE Reviews (
    ReviewId INT PRIMARY KEY IDENTITY(1,1),
    ProductId INT NOT NULL,
    CustomerId INT NOT NULL,
    Rating INT NOT NULL CHECK (Rating >= 1 AND Rating <= 5),
    Comment NVARCHAR(500),
    ReviewDate DATETIME DEFAULT GETDATE(),
    IsVerifiedPurchase BIT DEFAULT 0,
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
    FOREIGN KEY (CustomerId) REFERENCES Users(UserId)
)
```

**Purpose**: Product ratings and customer feedback.

**Key Fields:**
- `Rating`: 1-5 star rating (constrained)
- `IsVerifiedPurchase`: Indicates if customer actually bought the product

#### 6. Discounts Table
```sql
CREATE TABLE Discounts (
    DiscountId INT PRIMARY KEY IDENTITY(1,1),
    Code NVARCHAR(50) UNIQUE NOT NULL,
    Type INT NOT NULL,                    -- 0: Percentage, 1: FixedAmount
    Value DECIMAL(10,2) NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    MinimumPurchase DECIMAL(10,2) DEFAULT 0,
    IsActive BIT DEFAULT 1,
    UsageLimit INT,
    UsageCount INT DEFAULT 0
)
```

**Purpose**: Promotional discount codes.

**Key Fields:**
- `Code`: Unique coupon code
- `Type`: Percentage or fixed amount discount
- `UsageLimit`: Maximum number of times code can be used

### Database Indexes (Implicit and Recommended):

**Implicit (via Primary Keys and Unique Constraints):**
- Primary keys automatically create clustered indexes
- Unique constraints create non-clustered indexes

**Recommended Additional Indexes:**
```sql
CREATE INDEX IX_Orders_CustomerId ON Orders(CustomerId);
CREATE INDEX IX_Orders_OrderDate ON Orders(OrderDate DESC);
CREATE INDEX IX_Products_Category ON Products(Category);
CREATE INDEX IX_Products_IsActive ON Products(IsActive);
CREATE INDEX IX_OrderItems_OrderId ON OrderItems(OrderId);
```

### Data Integrity Constraints:

1. **Referential Integrity**: Foreign key constraints ensure data consistency
2. **Check Constraints**: Rating values limited to 1-5 range
3. **Not Null Constraints**: Essential fields must have values
4. **Unique Constraints**: Username and discount codes must be unique
5. **Default Values**: Timestamps, active flags, and quantities have sensible defaults

---

## 6. User Interface Design

### 6.1 Login Interface

**Form**: `LoginForm.cs`

**Purpose**: Entry point for all users to authenticate into the system.

**UI Components:**
- **Username TextBox**: Input field for username
- **Password TextBox**: Masked input field (UseSystemPasswordChar = true)
- **Show Password Checkbox**: Toggles password visibility
- **Login Button**: Authenticates user credentials
- **Register Button**: Opens registration form for new customers
- **Logo/Title**: GreenLife branding

**Workflow:**
1. User enters username and password
2. Optional: Toggle password visibility
3. Click Login button
4. System validates credentials via AuthenticationService
5. On success:
   - If Admin: Navigate to AdminDashboardForm
   - If Customer: Navigate to CustomerDashboardForm
6. On failure: Display error message

**Validation:**
- Required field checks for username and password
- Password hashing verification using BCrypt
- Account active status check

**Default Credentials:**
- Admin: username = `admin`, password = `admin123`

### 6.2 Admin Dashboard

**Form**: `AdminDashboardForm.cs`

**Purpose**: Central control panel for administrators to manage the entire system.

**UI Sections:**

1. **Header Section:**
   - Welcome message: "Welcome, [Admin Name]!"
   - Current date/time display
   - Logout button

2. **Statistics Panel:**
   - Total Products count
   - Low Stock alerts (count with red warning if > 0)
   - Total Orders count
   - Total Sales amount ($)

3. **Navigation Menu (Button Panel):**
   - **Product Management**: Opens ProductManagementForm
   - **Customer Management**: Opens CustomerManagementForm
   - **Order Management**: Opens OrderManagementForm
   - **Reports**: Opens ReportsForm
   - **Logout**: Ends session and returns to LoginForm

**Key Features:**
- Real-time statistics displayed on load
- Color-coded alerts (red for low stock warnings)
- Quick access to all admin functionalities
- Auto-refresh dashboard data after closing child forms

**Layout:**
```
+------------------------------------------+
|  Welcome, Administrator!     [Logout]   |
+------------------------------------------+
|  Statistics Dashboard                   |
|  +------------+  +------------+          |
|  | Products:  |  | Low Stock: |          |
|  |    150     |  |     5      |          |
|  +------------+  +------------+          |
|  +------------+  +------------+          |
|  | Orders:    |  | Sales:     |          |
|  |    87      |  |  $12,345   |          |
|  +------------+  +------------+          |
|                                          |
|  Management Tools                        |
|  +------------+  +------------+          |
|  | Products   |  | Customers  |          |
|  +------------+  +------------+          |
|  +------------+  +------------+          |
|  | Orders     |  | Reports    |          |
|  +------------+  +------------+          |
+------------------------------------------+
```

### 6.3 Customer Dashboard

**Form**: `CustomerDashboardForm.cs`

**Purpose**: Main shopping interface for customers to browse and purchase organic products.

**UI Components:**

1. **Header Section:**
   - Welcome message: "Welcome, [Customer Name]!"
   - Cart badge/icon showing item count
   - Navigation buttons:
     - View Cart
     - My Orders
     - Profile
     - Logout

2. **Search and Filter Panel:**
   - Search TextBox: Search by product name or description
   - Category ComboBox: Filter by category (All, Fruits, Vegetables, Dairy, etc.)
   - Min Price TextBox: Minimum price filter
   - Max Price TextBox: Maximum price filter
   - Search Button: Apply filters

3. **Product Display Grid (DataGridView):**
   - Columns displayed:
     - Name (180px width)
     - Category (100px width)
     - Description (250px width)
     - Price (formatted as currency)
     - Final Price/Discounted Price (if discount applies)
     - Stock Quantity (labeled "In Stock")
   
   - Hidden columns: ProductId, Supplier, CreatedAt, LastUpdated, IsActive, DiscountPercentage

4. **Product Actions:**
   - Quantity NumericUpDown: Select quantity to add
   - Add to Cart Button: Add selected product to cart

**Workflow:**
1. Customer browses products in grid
2. Optional: Apply filters/search
3. Select product row
4. Specify quantity
5. Click Add to Cart
6. Cart badge updates with item count
7. Proceed to View Cart when ready to checkout

**Key Features:**
- Dynamic product filtering
- Real-time price display with discounts
- Stock availability visibility
- Responsive cart counter
- Category-based browsing

**Layout:**
```
+--------------------------------------------------+
|  Welcome, John Doe!                   Cart: [3]  |
|  [View Cart] [My Orders] [Profile] [Logout]     |
+--------------------------------------------------+
|  Search & Filter                                 |
|  [Search: _______] [Category: v] [Min: __] [Max: __] [Search] |
+--------------------------------------------------+
|  Product List                                    |
|  +--------------------------------------------+  |
|  | Name      | Category | Price | Stock | ...  |  |
|  +--------------------------------------------+  |
|  | Apples    | Fruits   | $3.99 |  100  | ...  |  |
|  | Bananas   | Fruits   | $2.49 |  150  | ...  |  |
|  | Carrots   | Veggies  | $1.99 |   80  | ...  |  |
|  +--------------------------------------------+  |
|                                                  |
|  Quantity: [_3_] [Add to Cart]                  |
+--------------------------------------------------+
```

### Additional UI Forms:

#### ProductManagementForm (Admin)
- DataGridView for product listing
- Input fields for Name, Category, Description, Price, Stock, Supplier, Discount%
- CRUD buttons: Add, Save, Edit, Delete
- Search functionality
- Validation indicators

#### OrderManagementForm (Admin)
- Order list with status indicators
- Order details panel
- Status update buttons (Process, Ship, Deliver, Cancel)
- Customer information display
- Order items breakdown

#### CartForm (Customer)
- Cart items grid
- Quantity update controls
- Remove item buttons
- Clear cart button
- Total amount display
- Checkout button

#### CheckoutForm (Customer)
- Shipping address input
- Order summary
- Notes/special instructions field
- Order total display
- Place Order button
- Cancel button

#### ReportsForm (Admin)
- Date range selectors
- Report type selection
- Generate report button
- Export to Excel button
- Report preview area

---

## 7. Programming Techniques Used

### 7.1 Object-Oriented Programming (OOP) Principles

**1. Encapsulation:**
- **Private fields with public properties**: All model classes use property getters/setters
  ```csharp
  public class Product {
      public int ProductId { get; set; }
      private decimal price;
      public decimal Price { 
          get => price; 
          set => price = value >= 0 ? value : 0; 
      }
  }
  ```
- **Access modifiers**: Appropriate use of public, private, and protected
- **Data hiding**: Repository classes hide database connection logic

**2. Inheritance:**
- All forms inherit from `System.Windows.Forms.Form`
- Repository classes could extend a base repository (extensibility consideration)
- Model classes share common patterns

**3. Polymorphism:**
- Method overloading in repositories (GetAllProducts with optional parameters)
- Interface implementations (IDisposable for database connections)

**4. Abstraction:**
- Repository pattern abstracts data access
- Service classes abstract business logic from UI
- Models represent abstract entities

### 7.2 Design Patterns

**1. Repository Pattern:**
```csharp
public class ProductRepository {
    public List<Product> GetAllProducts() { /* ... */ }
    public Product GetProductById(int id) { /* ... */ }
    public bool CreateProduct(Product product) { /* ... */ }
    // Abstracts data access complexity
}
```

**2. Singleton Pattern:**
- `SessionManager` maintains single instance of current user
- `CartService` uses static members for cart state

**3. Factory Pattern:**
- `DatabaseContext.GetConnection()` creates database connections
- Centralized connection management

**4. Model-View Pattern:**
- Forms (Views) display data from Models
- Separation of concerns between UI and data

### 7.3 LINQ (Language Integrated Query)

Used extensively for data manipulation:

```csharp
// Filtering customers
customers = customers.Where(c => 
    c.Username.ToLower().Contains(searchTerm) ||
    c.FullName.ToLower().Contains(searchTerm)
).ToList();

// Calculating totals
var totalSales = orders.Sum(o => o.FinalAmount);

// Transforming cart items to order items
order.OrderItems = cartItems.Select(ci => new OrderItem {
    ProductId = ci.Product.ProductId,
    Quantity = ci.Quantity,
    // ...
}).ToList();

// Checking if any low stock items exist
bool hasLowStock = products.Any(p => p.StockQuantity <= 10);
```

### 7.4 ADO.NET for Database Access

**Parameterized Queries** (SQL Injection Prevention):
```csharp
using var command = new SqlCommand(
    "SELECT * FROM Products WHERE ProductId = @ProductId", 
    connection
);
command.Parameters.AddWithValue("@ProductId", productId);
```

**Connection Management**:
```csharp
using var connection = DatabaseContext.GetConnection();
connection.Open();
// Automatic disposal via 'using' statement
```

**Transaction Support** (for order creation):
```csharp
using var transaction = connection.BeginTransaction();
try {
    // Insert order
    // Insert order items
    transaction.Commit();
} catch {
    transaction.Rollback();
}
```

### 7.5 Password Security

**BCrypt Hashing**:
```csharp
// Registration
var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

// Login verification
bool isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
```

- Industry-standard one-way hashing
- Built-in salt generation
- Resistance to rainbow table attacks

### 7.6 Input Validation

**Regular Expressions**:
```csharp
public static bool IsValidEmail(string email) {
    var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    return regex.IsMatch(email);
}

public static bool IsValidPhoneNumber(string phone) {
    var regex = new Regex(@"^[\d\s\-\(\)]{10,15}$");
    return regex.IsMatch(phone);
}
```

**Type Validation**:
```csharp
public static bool IsValidPrice(string price) {
    return decimal.TryParse(price, out var value) && value >= 0;
}
```

### 7.7 Exception Handling

**Try-Catch Blocks**:
```csharp
try {
    // Database operations
} catch (SqlException ex) {
    // Specific SQL errors
    MessageBox.Show($"Database error: {ex.Message}");
} catch (Exception ex) {
    // General errors
    MessageBox.Show($"An error occurred: {ex.Message}");
}
```

### 7.8 Event-Driven Programming

**Button Click Events**:
```csharp
private void btnLogin_Click(object sender, EventArgs e) {
    // Event handler logic
}
```

**Form Events**:
```csharp
private void Form_Load(object sender, EventArgs e) {
    // Initialize data on form load
}
```

### 7.9 Data Binding

**DataGridView Binding**:
```csharp
dgvProducts.DataSource = products;
```

Automatic synchronization between data source and UI controls.

### 7.10 File I/O and Excel Export

**EPPlus Library Usage**:
```csharp
using var package = new ExcelPackage();
var worksheet = package.Workbook.Worksheets.Add("Orders");
// Populate cells
package.SaveAs(new FileInfo(filePath));
```

### 7.11 Computed Properties

```csharp
public class Product {
    public decimal Price { get; set; }
    public decimal? DiscountPercentage { get; set; }
    
    public decimal DiscountedPrice => DiscountPercentage.HasValue 
        ? Price * (1 - DiscountPercentage.Value / 100) 
        : Price;
}
```

### 7.12 Nullable Reference Types

```csharp
public User? GetUserByUsername(string username) {
    // Returns null if not found
}

public string? Notes { get; set; } // Optional field
```

### 7.13 Tuple Return Values

```csharp
public (bool success, User? user, string message) Login(string username, string password) {
    // Return multiple values without creating a custom class
    return (true, user, "Login successful!");
}
```

### 7.14 String Interpolation

```csharp
lblWelcome.Text = $"Welcome, {SessionManager.CurrentUser?.FullName}!";
lblTotal.Text = $"Total: ${total:N2}";
```

---

## 8. User Guide

### 8.1 Admin User Guide

#### 8.1.1 Logging In
1. Launch the application
2. Enter username: `admin`
3. Enter password: `admin123` (default, should be changed)
4. Click "Login"
5. You will be directed to the Admin Dashboard

#### 8.1.2 Managing Products

**Adding a New Product:**
1. From Admin Dashboard, click "Product Management"
2. Click "Add" button
3. Fill in the following fields:
   - **Name**: Product name (e.g., "Organic Tomatoes")
   - **Category**: Select from dropdown (Fruits, Vegetables, Dairy, etc.)
   - **Description**: Brief product description
   - **Price**: Enter price (e.g., 3.99)
   - **Stock Quantity**: Initial inventory count
   - **Supplier**: Supplier name (optional)
   - **Discount %**: Optional discount percentage (e.g., 10 for 10% off)
4. Click "Save"
5. Product will appear in the grid

**Editing a Product:**
1. Select product from the grid
2. Click "Edit" button
3. Modify desired fields
4. Click "Save"

**Deleting a Product:**
1. Select product from the grid
2. Click "Delete" button
3. Confirm deletion
4. Product is soft-deleted (IsActive = false)

**Searching Products:**
1. Enter search term in search box
2. Select category filter (optional)
3. Click "Search"
4. Results appear in grid

#### 8.1.3 Managing Customers

1. From Admin Dashboard, click "Customer Management"
2. View all registered customers in the grid
3. **Search Customers:**
   - Enter search term (username, name, or email)
   - Click "Search"
4. **Toggle Customer Status:**
   - Select customer
   - Click "Activate" or "Deactivate"
5. View customer details:
   - Username
   - Full Name
   - Email
   - Phone Number
   - Registration Date
   - Active Status

#### 8.1.4 Managing Orders

1. From Admin Dashboard, click "Order Management"
2. View all orders with:
   - Order ID
   - Customer Name
   - Order Date
   - Current Status
   - Total Amount
3. **View Order Details:**
   - Select order from grid
   - Details appear in panel showing:
     - Customer information
     - Shipping address
     - Order items with quantities and prices
     - Status history
4. **Update Order Status:**
   - Select order
   - Click appropriate status button:
     - "Process Order" (Pending → Processing)
     - "Ship Order" (Processing → Shipped)
     - "Deliver Order" (Shipped → Delivered)
     - "Cancel Order" (Any → Cancelled)
5. **Filter Orders:**
   - By status
   - By date range
   - By customer

#### 8.1.5 Generating Reports

1. From Admin Dashboard, click "Reports"
2. **Sales Report:**
   - Select date range (Start Date, End Date)
   - Click "Generate Sales Report"
   - View summary:
     - Total orders
     - Total revenue
     - Average order value
     - Orders by status
3. **Stock Report:**
   - Click "Generate Stock Report"
   - View products with:
     - Current stock levels
     - Low stock items highlighted
     - Stock value
4. **Export to Excel:**
   - After generating a report
   - Click "Export to Excel"
   - Choose save location
   - Excel file created with report data

#### 8.1.6 Dashboard Overview

- **Total Products**: Count of active products
- **Low Stock Alerts**: Products with stock ≤ 10 units (red if > 0)
- **Total Orders**: All orders in system
- **Total Sales**: Sum of all order final amounts
- Dashboard auto-refreshes when returning from management forms

#### 8.1.7 Logging Out

1. Click "Logout" button from any admin form
2. Confirm logout
3. Returns to Login screen

### 8.2 Customer User Guide

#### 8.2.1 Creating an Account

1. From Login screen, click "Register"
2. Fill in registration form:
   - **Username**: Unique username (required)
   - **Password**: Minimum 6 characters (required)
   - **Confirm Password**: Must match password
   - **Email**: Valid email format (required)
   - **Full Name**: Your full name (required)
   - **Phone Number**: 10-15 digits (optional)
   - **Address**: Shipping address (optional, but needed for orders)
3. Click "Register"
4. Success message appears
5. Return to Login screen and log in

#### 8.2.2 Logging In

1. Enter your username
2. Enter your password
3. Optional: Check "Show Password" to verify
4. Click "Login"
5. Directed to Customer Dashboard

#### 8.2.3 Browsing Products

1. Upon login, all active products are displayed
2. **View Product Information:**
   - Product Name
   - Category
   - Description
   - Original Price
   - Final Price (if discount applied)
   - Stock Availability
3. **Using Filters:**
   - **Search Box**: Enter product name or keywords
   - **Category Dropdown**: Select specific category
   - **Price Range**: Enter min and max prices
   - Click "Search" to apply filters
4. **Clear Filters**: Select "All Categories" and clear search box

#### 8.2.4 Adding Items to Cart

1. Select a product from the grid (click on row)
2. Specify quantity in the NumericUpDown control
3. Click "Add to Cart"
4. Confirmation message appears
5. Cart badge updates with total item count

**Notes:**
- Cannot add more than available stock
- Duplicate products increase quantity in cart
- Cart persists during session

#### 8.2.5 Managing Shopping Cart

1. Click "View Cart" button
2. Cart form displays:
   - Product names
   - Quantities
   - Unit prices
   - Subtotals
   - Total amount
3. **Update Quantity:**
   - Select item
   - Enter new quantity
   - Click "Update"
4. **Remove Item:**
   - Select item
   - Click "Remove"
5. **Clear Cart:**
   - Click "Clear Cart"
   - Confirm action
6. **Proceed to Checkout:**
   - Click "Checkout"

#### 8.2.6 Placing an Order

1. From Cart, click "Checkout"
2. Checkout form appears with:
   - **Shipping Address**: Pre-filled from profile (editable)
   - **Order Summary**: List of items and total
   - **Notes**: Optional delivery instructions
3. Verify shipping address is correct
4. Add any special notes
5. Review order total
6. Click "Place Order"
7. Order confirmation message with Order ID
8. Cart is cleared
9. Return to dashboard

**Important**: Ensure shipping address is complete and accurate.

#### 8.2.7 Viewing Order History

1. From Customer Dashboard, click "My Orders"
2. View all your orders with:
   - Order ID
   - Order Date
   - Status (Pending, Processing, Shipped, Delivered, Cancelled)
   - Final Amount
3. **View Order Details:**
   - Select order from list
   - Details panel shows:
     - Order date and status
     - Shipping address
     - List of items with quantities and prices
     - Total and discount information
4. **Track Order:**
   - Status updates show order progress
   - Pending → Processing → Shipped → Delivered

#### 8.2.8 Managing Profile

1. From Customer Dashboard, click "Profile"
2. View and edit your information:
   - Username (read-only)
   - Email
   - Full Name
   - Phone Number
   - Address
3. Make desired changes
4. Click "Update Profile"
5. Confirmation message appears

**Password Change:**
1. In Profile form
2. Click "Change Password" button
3. Enter current password
4. Enter new password (min 6 characters)
5. Confirm new password
6. Click "Save"

#### 8.2.9 Logging Out

1. Click "Logout" button
2. Confirm logout
3. Returns to Login screen
4. Cart is cleared on logout

#### 8.2.10 Tips for Best Experience

- **Keep your profile updated**: Accurate address ensures smooth delivery
- **Check stock availability**: Products with low stock may sell out quickly
- **Review your cart**: Double-check quantities before checkout
- **Track your orders**: Monitor order status in "My Orders"
- **Secure your account**: Use a strong password and log out when finished

---

## 9. Class Relationships

### Class Diagram Overview

```
┌─────────────────┐       ┌──────────────────┐       ┌─────────────────┐
│     User        │       │     Product      │       │     Order       │
├─────────────────┤       ├──────────────────┤       ├─────────────────┤
│ - UserId        │◄──┐   │ - ProductId      │◄──┐   │ - OrderId       │
│ - Username      │   │   │ - Name           │   │   │ - CustomerId    │
│ - PasswordHash  │   │   │ - Category       │   │   │ - OrderDate     │
│ - Email         │   │   │ - Price          │   │   │ - Status        │
│ - Role          │   │   │ - StockQuantity  │   │   │ - TotalAmount   │
│ - IsActive      │   │   │ - DiscountPct    │   │   │ - FinalAmount   │
└─────────────────┘   │   └──────────────────┘   │   └─────────────────┘
                      │                          │            │
                      │   ┌──────────────────┐   │            │
                      └───┤    Review        │   │            │
                          ├──────────────────┤   │            │
                          │ - ReviewId       │   │            │
                          │ - ProductId (FK) │───┘            │
                          │ - CustomerId(FK) │                │
                          │ - Rating         │                │
                          └──────────────────┘                │
                                                              │
        ┌─────────────────────────────────────────────────────┘
        │
        ▼
┌─────────────────┐
│   OrderItem     │
├─────────────────┤
│ - OrderItemId   │
│ - OrderId (FK)  │◄───┐
│ - ProductId(FK) │    │
│ - Quantity      │    │
│ - UnitPrice     │    │
└─────────────────┘    │
                       │
                 (Many-to-Many
                  via OrderItem)
```

### Key Relationships:

1. **User → Order**: One-to-Many
   - One user (customer) can have many orders
   - Each order belongs to one customer

2. **Order → OrderItem**: One-to-Many
   - One order contains many order items
   - Each order item belongs to one order

3. **Product → OrderItem**: One-to-Many
   - One product can appear in many order items
   - Each order item references one product

4. **User → Review**: One-to-Many
   - One user can write many reviews
   - Each review written by one user

5. **Product → Review**: One-to-Many
   - One product can have many reviews
   - Each review is for one product

6. **Order ↔ Product**: Many-to-Many (via OrderItem)
   - Orders and Products have indirect many-to-many relationship
   - OrderItem is the junction/bridge table

### Service and Repository Dependencies:

```
┌───────────────────┐
│   LoginForm       │
└────────┬──────────┘
         │ uses
         ▼
┌───────────────────┐        ┌──────────────────┐
│ Authentication    │        │  SessionManager  │
│    Service        │───────►│   (Singleton)    │
└────────┬──────────┘        └──────────────────┘
         │ uses
         ▼
┌───────────────────┐
│  UserRepository   │
└────────┬──────────┘
         │ uses
         ▼
┌───────────────────┐
│ DatabaseContext   │
└───────────────────┘
```

### 9.1 Description of Classes' Properties and Methods

#### Model Classes

##### **User.cs**
```csharp
public class User {
    // Properties
    public int UserId { get; set; }              // Primary key
    public string Username { get; set; }          // Unique identifier
    public string PasswordHash { get; set; }      // BCrypt hashed password
    public string Email { get; set; }             // Contact email
    public string FullName { get; set; }          // Display name
    public string PhoneNumber { get; set; }       // Contact number
    public string Address { get; set; }           // Shipping address
    public UserRole Role { get; set; }            // Admin or Customer
    public DateTime CreatedAt { get; set; }       // Registration date
    public bool IsActive { get; set; }            // Account status
}
```

**Purpose**: Represents a system user (admin or customer)
**Relationships**: One-to-Many with Orders and Reviews

##### **Product.cs**
```csharp
public class Product {
    // Properties
    public int ProductId { get; set; }            // Primary key
    public string Name { get; set; }              // Product name
    public string Category { get; set; }          // Product category
    public string Description { get; set; }       // Product details
    public decimal Price { get; set; }            // Original price
    public int StockQuantity { get; set; }        // Current inventory
    public string Supplier { get; set; }          // Supplier name
    public DateTime CreatedAt { get; set; }       // Creation date
    public DateTime? LastUpdated { get; set; }    // Last modification
    public bool IsActive { get; set; }            // Visibility status
    public decimal? DiscountPercentage { get; set; } // Optional discount
    
    // Computed Properties
    public decimal DiscountedPrice => 
        DiscountPercentage.HasValue 
            ? Price * (1 - DiscountPercentage.Value / 100) 
            : Price;                              // Final price after discount
    
    // Methods
    public bool IsLowStock(int threshold = 10) => 
        StockQuantity <= threshold;               // Check if stock is low
}
```

**Purpose**: Represents an organic product in the inventory
**Relationships**: One-to-Many with OrderItems and Reviews

##### **Order.cs**
```csharp
public class Order {
    // Properties
    public int OrderId { get; set; }              // Primary key
    public int CustomerId { get; set; }           // Foreign key to User
    public DateTime OrderDate { get; set; }       // Order timestamp
    public OrderStatus Status { get; set; }       // Current order status
    public decimal TotalAmount { get; set; }      // Subtotal before discount
    public decimal DiscountAmount { get; set; }   // Total discount applied
    public decimal FinalAmount { get; set; }      // Final payable amount
    public string ShippingAddress { get; set; }   // Delivery address
    public string? Notes { get; set; }            // Customer notes
    public DateTime? ShippedDate { get; set; }    // Shipping timestamp
    public DateTime? DeliveredDate { get; set; }  // Delivery timestamp
    
    // Navigation Properties
    public List<OrderItem> OrderItems { get; set; } // Order line items
    public string CustomerName { get; set; }      // For display (denormalized)
}
```

**Purpose**: Represents a customer order
**Relationships**: Many-to-One with User, One-to-Many with OrderItems

##### **OrderItem.cs**
```csharp
public class OrderItem {
    // Properties
    public int OrderItemId { get; set; }          // Primary key
    public int OrderId { get; set; }              // Foreign key to Order
    public int ProductId { get; set; }            // Foreign key to Product
    public string ProductName { get; set; }       // Product name snapshot
    public int Quantity { get; set; }             // Quantity ordered
    public decimal UnitPrice { get; set; }        // Price at time of order
    public decimal Subtotal { get; set; }         // Quantity × UnitPrice
    public decimal? DiscountApplied { get; set; } // Item-level discount
}
```

**Purpose**: Represents individual line items in an order
**Relationships**: Many-to-One with Order and Product

##### **CartItem.cs**
```csharp
public class CartItem {
    // Properties
    public Product Product { get; set; }          // Product reference
    public int Quantity { get; set; }             // Quantity in cart
    
    // Computed Property
    public decimal Subtotal => 
        Product.DiscountedPrice * Quantity;       // Line total
}
```

**Purpose**: Temporary cart item (not persisted to database)
**Relationships**: References Product

##### **Review.cs**
```csharp
public class Review {
    // Properties
    public int ReviewId { get; set; }             // Primary key
    public int ProductId { get; set; }            // Foreign key to Product
    public int CustomerId { get; set; }           // Foreign key to User
    public int Rating { get; set; }               // 1-5 stars
    public string Comment { get; set; }           // Review text
    public DateTime ReviewDate { get; set; }      // Timestamp
    public bool IsVerifiedPurchase { get; set; }  // Purchase verification
}
```

**Purpose**: Represents customer product reviews
**Relationships**: Many-to-One with Product and User

##### **Enums.cs**
```csharp
public enum UserRole {
    Admin,      // = 0
    Customer    // = 1
}

public enum OrderStatus {
    Pending,    // = 0 (Order placed)
    Processing, // = 1 (Being prepared)
    Shipped,    // = 2 (Dispatched)
    Delivered,  // = 3 (Completed)
    Cancelled   // = 4 (Cancelled)
}

public enum DiscountType {
    Percentage,   // = 0 (e.g., 10%)
    FixedAmount   // = 1 (e.g., $5 off)
}
```

**Purpose**: Enumeration types for type-safe constants

#### Repository Classes

##### **UserRepository.cs**
```csharp
public class UserRepository {
    // Methods
    public User? GetUserByUsername(string username)
        // Returns user by username or null if not found
        
    public User? GetUserById(int userId)
        // Returns user by ID or null if not found
        
    public List<User> GetAllCustomers()
        // Returns all users with Customer role
        
    public bool CreateUser(User user)
        // Inserts new user, returns success status
        
    public bool UpdateUser(User user)
        // Updates existing user, returns success status
        
    public bool UsernameExists(string username)
        // Checks if username is taken
        
    private User MapUser(SqlDataReader reader)
        // Maps database row to User object
}
```

**Purpose**: Data access for User entity
**Dependencies**: DatabaseContext

##### **ProductRepository.cs**
```csharp
public class ProductRepository {
    // Methods
    public List<Product> GetAllProducts(bool includeInactive = false)
        // Returns all products, optionally including inactive ones
        
    public Product? GetProductById(int productId)
        // Returns product by ID or null if not found
        
    public List<Product> SearchProducts(
        string searchTerm, 
        string? category = null, 
        decimal? minPrice = null, 
        decimal? maxPrice = null)
        // Searches products with filters
        
    public List<string> GetCategories()
        // Returns distinct list of product categories
        
    public bool CreateProduct(Product product)
        // Inserts new product
        
    public bool UpdateProduct(Product product)
        // Updates existing product
        
    public bool DeleteProduct(int productId)
        // Soft deletes product (sets IsActive = false)
        
    public List<Product> GetLowStockProducts(int threshold = 10)
        // Returns products with stock <= threshold
        
    public bool UpdateStock(int productId, int quantity)
        // Updates product stock quantity
        
    private Product MapProduct(SqlDataReader reader)
        // Maps database row to Product object
}
```

**Purpose**: Data access for Product entity
**Dependencies**: DatabaseContext

##### **OrderRepository.cs**
```csharp
public class OrderRepository {
    // Methods
    public int CreateOrder(Order order)
        // Creates order with items, returns new OrderId
        // Uses transaction for atomicity
        
    public List<Order> GetOrdersByCustomer(int customerId)
        // Returns all orders for specific customer
        
    public List<Order> GetAllOrders()
        // Returns all orders with customer names
        
    public Order? GetOrderById(int orderId)
        // Returns order with items or null if not found
        
    public List<OrderItem> GetOrderItems(
        int orderId, 
        SqlConnection? connection = null)
        // Returns items for specific order
        
    public bool UpdateOrderStatus(int orderId, OrderStatus status)
        // Updates order status and timestamps
        
    public decimal GetTotalSales(
        DateTime? startDate = null, 
        DateTime? endDate = null)
        // Calculates total sales in date range
        
    private Order MapOrder(SqlDataReader reader)
        // Maps database row to Order object
        
    private OrderItem MapOrderItem(SqlDataReader reader)
        // Maps database row to OrderItem object
}
```

**Purpose**: Data access for Order and OrderItem entities
**Dependencies**: DatabaseContext, ProductRepository (for stock updates)

#### Service Classes

##### **AuthenticationService.cs**
```csharp
public class AuthenticationService {
    // Fields
    private readonly UserRepository _userRepository;
    
    // Methods
    public (bool success, User? user, string message) Login(
        string username, 
        string password)
        // Validates credentials, returns tuple with result
        // - Checks username exists
        // - Verifies password with BCrypt
        // - Checks account is active
        
    public (bool success, string message) Register(
        string username, 
        string password, 
        string email, 
        string fullName, 
        string phoneNumber, 
        string address)
        // Creates new customer account
        // - Checks username availability
        // - Hashes password with BCrypt
        // - Creates user with Customer role
}
```

**Purpose**: Handles authentication and registration
**Dependencies**: UserRepository, BCrypt library

##### **CartService.cs**
```csharp
public static class CartService {
    // Static Field
    private static List<CartItem> _cartItems = new();
    
    // Methods
    public static void AddToCart(Product product, int quantity)
        // Adds item to cart or updates quantity if exists
        
    public static void UpdateQuantity(int productId, int quantity)
        // Updates item quantity, removes if quantity <= 0
        
    public static void RemoveFromCart(int productId)
        // Removes item from cart
        
    public static List<CartItem> GetCartItems()
        // Returns all cart items
        
    public static decimal GetCartTotal()
        // Calculates total cart value
        
    public static int GetCartCount()
        // Returns total item count
        
    public static void ClearCart()
        // Empties the cart
        
    public static bool IsEmpty()
        // Checks if cart has items
}
```

**Purpose**: In-memory shopping cart management
**Dependencies**: None (static singleton pattern)

#### Utility Classes

##### **SessionManager.cs**
```csharp
public static class SessionManager {
    // Properties
    public static User? CurrentUser { get; set; }
        // Currently logged-in user
        
    public static bool IsLoggedIn => CurrentUser != null;
        // Checks if user is logged in
        
    public static bool IsAdmin => 
        CurrentUser?.Role == UserRole.Admin;
        // Checks if current user is admin
        
    public static bool IsCustomer => 
        CurrentUser?.Role == UserRole.Customer;
        // Checks if current user is customer
    
    // Methods
    public static void Logout()
        // Clears current user session
}
```

**Purpose**: Session state management
**Dependencies**: None (static singleton)

##### **Validator.cs**
```csharp
public static class Validator {
    // Methods
    public static bool IsValidEmail(string email)
        // Validates email format using regex
        // Pattern: ^[^@\s]+@[^@\s]+\.[^@\s]+$
        
    public static bool IsValidPhoneNumber(string phoneNumber)
        // Validates phone number format
        // Allows digits, spaces, hyphens, parentheses
        // Length: 10-15 characters
        
    public static bool IsValidPrice(string price)
        // Validates price is non-negative decimal
        
    public static bool IsValidQuantity(string quantity)
        // Validates quantity is non-negative integer
        
    public static bool IsValidPassword(string password)
        // Validates password is at least 6 characters
        
    public static bool IsNotEmpty(string value)
        // Checks if string is not null or whitespace
}
```

**Purpose**: Input validation utilities
**Dependencies**: System.Text.RegularExpressions

##### **ExportHelper.cs**
```csharp
public static class ExportHelper {
    // Methods
    public static void ExportOrdersToExcel(
        List<Order> orders, 
        string filePath)
        // Exports orders to Excel file
        // Columns: OrderId, Customer, Date, Status, Total, Final Amount
        
    public static void ExportProductsToExcel(
        List<Product> products, 
        string filePath)
        // Exports products to Excel file
        // Columns: ProductId, Name, Category, Price, Stock, Supplier
}
```

**Purpose**: Data export functionality
**Dependencies**: EPPlus library

##### **DatabaseContext.cs**
```csharp
public class DatabaseContext {
    // Fields
    private static readonly string ConnectionString = GetConnectionString();
    
    // Methods
    private static string GetConnectionString()
        // Builds connection string for GreenLifeDB
        
    private static void EnsureDatabaseExists(
        string serverName, 
        string dbName)
        // Creates database if it doesn't exist
        
    public static SqlConnection GetConnection()
        // Returns new SqlConnection (factory method)
        
    public static void InitializeDatabase()
        // Creates all tables if they don't exist
        // Inserts default admin user
        // Inserts sample products
        
    private static void ExecuteNonQuery(
        SqlConnection connection, 
        string query, 
        params SqlParameter[] parameters)
        // Helper for executing non-query SQL
        
    private static object? ExecuteScalar(
        SqlConnection connection, 
        string query, 
        params SqlParameter[] parameters)
        // Helper for executing scalar SQL
        
    private static void InsertSampleProducts(SqlConnection connection)
        // Seeds database with sample products
}
```

**Purpose**: Database initialization and connection management
**Dependencies**: System.Data.SqlClient

---

## 10. Explanation of Search Algorithms Used

### 10.1 Database-Level Search (Primary Approach)

The system primarily uses **SQL-based searching** leveraging the database's built-in query optimization:

#### Product Search Implementation:
```csharp
public List<Product> SearchProducts(
    string searchTerm, 
    string? category = null, 
    decimal? minPrice = null, 
    decimal? maxPrice = null)
{
    var query = "SELECT * FROM Products WHERE IsActive = 1";
    
    if (!string.IsNullOrWhiteSpace(searchTerm))
        query += " AND (Name LIKE @SearchTerm OR Description LIKE @SearchTerm)";
    
    if (!string.IsNullOrWhiteSpace(category))
        query += " AND Category = @Category";
    
    if (minPrice.HasValue)
        query += " AND Price >= @MinPrice";
    
    if (maxPrice.HasValue)
        query += " AND Price <= @MaxPrice";
    
    query += " ORDER BY Name";
    
    // Execute query with parameters
}
```

**Algorithm**: SQL LIKE Operator
- **Complexity**: O(n) where n = number of products
- **Optimization**: Database indexes on Name, Category columns improve performance
- **Pattern Matching**: `%searchTerm%` allows substring matching
- **Case Sensitivity**: Case-insensitive by default in SQL Server

**Advantages:**
- Utilizes database indexing
- Efficient for large datasets
- Multiple filter criteria combined
- Reduces memory footprint (filtering at source)

### 10.2 Linear Search (Client-Side)

Used for **customer search** in admin panel:

```csharp
private void btnSearch_Click(object sender, EventArgs e)
{
    var searchTerm = txtSearch.Text.Trim().ToLower();
    var customers = _userRepository.GetAllCustomers();
    
    if (!string.IsNullOrWhiteSpace(searchTerm))
    {
        customers = customers.Where(c => 
            c.Username.ToLower().Contains(searchTerm) ||
            c.FullName.ToLower().Contains(searchTerm) ||
            c.Email.ToLower().Contains(searchTerm)
        ).ToList();
    }
    
    dgvCustomers.DataSource = customers;
}
```

**Algorithm**: Linear Search with LINQ
- **Complexity**: O(n) where n = number of customers
- **Method**: Iterate through all items checking condition
- **Filtering**: Multiple field search (Username, FullName, Email)

**LINQ Breakdown:**
1. `GetAllCustomers()` retrieves all records
2. `Where()` filters items matching predicate
3. `.ToLower()` ensures case-insensitive comparison
4. `Contains()` checks substring presence
5. `||` (OR) operator checks multiple fields

**Advantages:**
- Simple implementation
- Suitable for small datasets (typical customer count)
- Flexible multi-field searching

**Disadvantages:**
- Loads all data into memory
- Inefficient for very large datasets

### 10.3 Index-Based Search (DataGridView)

DataGridView provides **built-in search** functionality:

```csharp
// Select row by ID
foreach (DataGridViewRow row in dgvProducts.Rows)
{
    if ((int)row.Cells["ProductId"].Value == productId)
    {
        row.Selected = true;
        dgvProducts.CurrentCell = row.Cells[0];
        break;
    }
}
```

**Algorithm**: Linear iteration with early exit
- **Complexity**: O(n) worst case, O(1) best case
- **Optimization**: Break statement stops search after finding match

### 10.4 Dictionary Lookup (Not Implemented, but Recommended)

For **category filtering**, a Dictionary could optimize repeated lookups:

```csharp
// Hypothetical optimization
Dictionary<string, List<Product>> categorizedProducts = products
    .GroupBy(p => p.Category)
    .ToDictionary(g => g.Key, g => g.ToList());

// O(1) average case lookup
var fruits = categorizedProducts["Fruits"];
```

**Algorithm**: Hash Table Lookup
- **Complexity**: O(1) average case
- **Use Case**: When same categories searched frequently

### 10.5 Sorting Algorithms

**SQL Server Sorting** (used in queries):
```sql
ORDER BY Name
ORDER BY OrderDate DESC
ORDER BY StockQuantity
```

- **Algorithm**: Typically uses **QuickSort** or **MergeSort** variants
- **Complexity**: O(n log n)
- **Database Optimization**: Uses indexes if available

**LINQ Sorting** (client-side):
```csharp
var sortedProducts = products.OrderBy(p => p.Name).ToList();
var recentOrders = orders.OrderByDescending(o => o.OrderDate).ToList();
```

- **Algorithm**: **IntroSort** (Introspective Sort)
- IntroSort = QuickSort + HeapSort + InsertionSort
- **Complexity**: O(n log n) guaranteed
- Adaptive algorithm switching based on data characteristics

### 10.6 Filtering with LINQ

**Multiple Conditions**:
```csharp
var filteredProducts = products
    .Where(p => p.IsActive)
    .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
    .Where(p => category == null || p.Category == category)
    .ToList();
```

**Algorithm**: Sequential filtering (lazy evaluation)
- Each `Where()` creates a filter layer
- Execution deferred until `.ToList()` called
- **Complexity**: O(n) per filter, combined O(n)

### 10.7 Search Performance Analysis

| Search Type | Algorithm | Time Complexity | Space Complexity | Use Case |
|-------------|-----------|-----------------|------------------|----------|
| Product Search | SQL LIKE | O(n) | O(1) | Main product search |
| Customer Search | Linear (LINQ) | O(n) | O(n) | Admin customer lookup |
| Order Lookup by ID | SQL Index | O(log n)* | O(1) | Order details |
| Category Filter | SQL WHERE | O(n) | O(1) | Category browsing |
| Price Range | SQL WHERE | O(n) | O(1) | Price filtering |

*With database index

### 10.8 Potential Optimizations

**1. Full-Text Search** (SQL Server feature):
```sql
CREATE FULLTEXT INDEX ON Products(Name, Description)
```
- Faster text searching
- Supports complex queries
- Better for large text fields

**2. Caching Frequently Accessed Data**:
```csharp
private static List<string>? _cachedCategories;
public List<string> GetCategories()
{
    if (_cachedCategories == null)
        _cachedCategories = /* load from DB */;
    return _cachedCategories;
}
```

**3. Pagination**:
```sql
SELECT * FROM Products
ORDER BY ProductId
OFFSET @PageSize * (@PageNumber - 1) ROWS
FETCH NEXT @PageSize ROWS ONLY
```
- Reduces memory usage
- Improves initial load time

### 10.9 Why These Algorithms Were Chosen

1. **SQL LIKE for Product Search**:
   - Database handles heavy lifting
   - Efficient for networked environments
   - Built-in optimization

2. **Linear Search for Customers**:
   - Simple implementation
   - Small dataset (typically < 1000 customers)
   - O(n) acceptable for this scale

3. **Database Indexing**:
   - Primary keys auto-indexed
   - Foreign keys benefit from indexes
   - Significant performance gain for lookups

4. **No Binary Search Used**:
   - Products/orders not sorted by searchable fields
   - SQL indexes more efficient than manual binary search
   - LINQ OrderBy uses optimized sorting internally

---

## 11. Personal Reflection

### 11.1 Experience with C#

#### What I Learned:

**1. Language Features:**
- **Nullable Reference Types**: C# 10's nullable annotations helped prevent null reference exceptions
- **Tuple Return Values**: Simplified methods that need to return multiple values
  ```csharp
  (bool success, User? user, string message) Login(...)
  ```
- **String Interpolation**: Made string construction more readable
  ```csharp
  $"Welcome, {user.Name}!"
  ```
- **LINQ**: Powerful data manipulation without loops
- **Async/Await**: Though not heavily used, understanding for future scalability

**2. Object-Oriented Principles:**
- **Encapsulation**: Properties with getters/setters for controlled access
- **Inheritance**: All forms inherit from Form base class
- **Polymorphism**: Method overloading in repositories
- **Abstraction**: Repository pattern abstracts data access complexity

**3. C# Ecosystem:**
- **NuGet Packages**: Dependency management and third-party library integration
- **ADO.NET**: Direct database access and understanding SQL integration
- **Windows Forms**: Event-driven UI programming
- **BCrypt.Net**: Password security implementation

#### Challenges and Insights:

**Challenge 1: Understanding Async/Sync Database Operations**
- Initial confusion about when to use async methods
- Learned that for WinForms, synchronous is often simpler
- Future improvement: Implement async for better responsiveness

**Challenge 2: Null Reference Handling**
- Nullable reference types initially confusing
- Using `User?` vs `User` required understanding
- Null-conditional operator (`?.`) became very useful

**Challenge 3: LINQ Query Syntax**
- Lambda expressions vs query syntax decision
- Chose lambda for consistency and brevity
- Understanding deferred execution was key

**What I Appreciate About C#:**
- **Type Safety**: Compile-time error catching
- **IntelliSense**: Excellent IDE support
- **Modern Features**: Keeps evolving with useful features
- **Cross-Platform**: Potential with .NET Core/10+

### 11.2 Experience with Visual Studio

#### IDE Features That Enhanced Development:

**1. IntelliSense and Code Completion:**
- Auto-complete saved significant typing
- Parameter hints prevented errors
- Quick info tooltips provided inline documentation

**2. Refactoring Tools:**
- Rename symbol across solution
- Extract method functionality
- Quick fixes for common issues

**3. Debugging Tools:**
- **Breakpoints**: Essential for tracking logic flow
- **Watch Window**: Monitoring variable values
- **Call Stack**: Understanding execution path
- **Immediate Window**: Testing expressions during debug

**4. Designer Tools:**
- **Windows Forms Designer**: Visual UI construction
- **Property Grid**: Easy control configuration
- Drag-and-drop reduced boilerplate code

**5. Solution Explorer:**
- Project structure organization
- Quick file navigation
- Search functionality

**6. NuGet Package Manager:**
- Easy dependency installation
- Package version management
- Update notifications

**7. Git Integration:**
- Built-in version control
- Diff view for changes
- Commit and push from IDE

**8. Error List:**
- Real-time error detection
- Warning indicators
- Quick navigation to issues

#### Productivity Tips Discovered:

- **Ctrl + .**: Quick actions and refactorings
- **F12**: Go to definition
- **Ctrl + Shift + F**: Find in files (project-wide search)
- **Ctrl + K, Ctrl + D**: Auto-format document
- **F5**: Start debugging
- **Ctrl + F5**: Start without debugging
- **Bookmarks**: Mark important code locations

#### Challenges with Visual Studio:

**1. Initial Complexity:**
- Overwhelming number of windows and options
- Took time to learn keyboard shortcuts
- Configuration options initially confusing

**2. Performance:**
- Can be resource-intensive
- Occasional lag with large solutions
- Startup time on older machines

**3. Designer Bugs:**
- Windows Forms Designer occasionally corrupted
- Manual .Designer.cs editing sometimes necessary
- Regenerating designer code could lose changes

**Alternative IDE Tried: JetBrains Rider**
- Faster performance
- Better code analysis
- Different UI paradigm
- Both viable options

### 11.3 Challenges Faced and Solutions Applied

#### Challenge 1: Database Connection Issues

**Problem:**
- Initial SQL Server connection errors
- "Login failed for user" messages
- Database not found errors

**Root Cause:**
- SQL Server service not running
- Wrong connection string format
- Database not created

**Solution:**
```csharp
private static void EnsureDatabaseExists(string serverName, string dbName)
{
    // Connect to master database
    // Check if database exists
    // Create if doesn't exist
}
```
- Implemented auto-database creation
- Added error handling with descriptive messages
- Verified SQL Server service status

**Lesson Learned**: Always handle environment setup in code; don't assume infrastructure exists.

#### Challenge 2: Password Security

**Problem:**
- Initially stored passwords in plain text (in early development)
- Realized massive security vulnerability

**Solution:**
```csharp
// Registration
var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

// Login
bool isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
```
- Integrated BCrypt.Net library
- Implemented one-way hashing
- Never store plain text passwords

**Lesson Learned**: Security cannot be an afterthought; implement from the start.

#### Challenge 3: Shopping Cart State Management

**Problem:**
- Cart data lost between forms
- Needed persistent cart during session

**Initial Approach (Failed):**
- Tried passing cart between forms via constructor

**Improved Solution:**
```csharp
public static class CartService {
    private static List<CartItem> _cartItems = new();
    // Static singleton pattern
}
```
- Static service maintains cart state
- Accessible from any form
- Cleared on logout

**Lesson Learned**: Choose appropriate state management patterns for different scenarios.

#### Challenge 4: DataGridView Data Binding

**Problem:**
- Changes to objects didn't reflect in grid
- Grid showed stale data

**Solution:**
```csharp
dgvProducts.DataSource = null; // Clear binding
dgvProducts.DataSource = products; // Rebind
```
- Refresh data source after changes
- Implemented reload methods

**Alternative Approach:**
- Use BindingList<T> for automatic updates
  ```csharp
  BindingList<Product> bindingList = new BindingList<Product>(products);
  dgvProducts.DataSource = bindingList;
  ```

**Lesson Learned**: Understand data binding mechanisms and their limitations.

#### Challenge 5: SQL Injection Vulnerability

**Problem:**
- Initially used string concatenation for queries
- Vulnerable to SQL injection attacks

**Bad Code (Early Version):**
```csharp
// DON'T DO THIS!
var query = "SELECT * FROM Users WHERE Username = '" + username + "'";
```

**Corrected Solution:**
```csharp
var query = "SELECT * FROM Users WHERE Username = @Username";
command.Parameters.AddWithValue("@Username", username);
```
- Used parameterized queries throughout
- Prevents SQL injection

**Lesson Learned**: Always use parameterized queries; never concatenate user input into SQL.

#### Challenge 6: Form Navigation and Lifecycle

**Problem:**
- Multiple instances of forms created
- Memory leaks from not closing forms
- Navigation flow confusing

**Solution:**
```csharp
// Proper form navigation
this.Hide(); // Hide current form
var newForm = new TargetForm();
newForm.FormClosed += (s, args) => this.Close(); // Cleanup
newForm.Show();
```
- Implemented proper form lifecycle management
- Used events for cleanup
- ShowDialog() for modal forms, Show() for modeless

**Lesson Learned**: Manage form lifecycle carefully to prevent resource leaks.

#### Challenge 7: Handling Decimal Precision

**Problem:**
- Currency calculations had rounding errors
- Subtotal didn't always match sum of items

**Solution:**
```csharp
public decimal Price { get; set; } // decimal, not float
// DECIMAL(10,2) in database
// Math.Round(value, 2) when needed
```
- Use `decimal` type for currency
- Proper database column types
- Round consistently

**Lesson Learned**: Use appropriate data types for financial calculations.

#### Challenge 8: Exception Handling Consistency

**Problem:**
- Inconsistent error handling
- Some errors crashed application
- User-unfriendly error messages

**Solution:**
```csharp
try {
    // Operation
} catch (SqlException ex) {
    // Database-specific handling
    MessageBox.Show($"Database error: {ex.Message}", "Error", ...);
} catch (Exception ex) {
    // General handling
    MessageBox.Show($"An error occurred: {ex.Message}", "Error", ...);
}
```
- Standardized try-catch blocks
- User-friendly error messages
- Logging (could be improved)

**Lesson Learned**: Comprehensive exception handling improves user experience and debugging.

### 11.4 Personal Growth and Learning Outcome

#### Technical Skills Acquired:

1. **Full-Stack Desktop Application Development**
   - UI design with Windows Forms
   - Business logic implementation
   - Database design and integration
   - Complete CRUD operations

2. **Software Architecture**
   - Three-tier architecture
   - Repository pattern
   - Separation of concerns
   - Modular code organization

3. **Database Management**
   - SQL Server administration
   - Schema design
   - Query optimization
   - Data relationships

4. **Security Practices**
   - Password hashing
   - SQL injection prevention
   - Input validation
   - Role-based access control

5. **Version Control (if used)**
   - Git workflow
   - Commit best practices
   - Branch management

#### Soft Skills Developed:

1. **Problem-Solving**
   - Breaking down complex problems
   - Researching solutions
   - Debugging systematically

2. **Time Management**
   - Planning development phases
   - Prioritizing features
   - Meeting deadlines

3. **Documentation**
   - Code comments
   - This comprehensive documentation
   - User guide creation

4. **Attention to Detail**
   - Data validation
   - Edge case handling
   - User experience refinement

#### Areas for Future Improvement:

1. **Asynchronous Programming**
   - Implement async/await for database operations
   - Improve UI responsiveness

2. **Unit Testing**
   - Write unit tests for repositories
   - Service layer testing
   - Improve code reliability

3. **Design Patterns**
   - Implement more patterns (Observer, Factory, etc.)
   - Better understand when to apply each

4. **Advanced SQL**
   - Stored procedures
   - Database triggers
   - Performance tuning

5. **UI/UX Design**
   - More modern UI frameworks (WPF, Avalonia)
   - Better visual design
   - Accessibility features

#### What I Would Do Differently:

1. **Start with Design Documents**
   - Complete requirements analysis
   - Database schema design upfront
   - UI mockups before coding

2. **Implement Testing from Start**
   - Test-Driven Development (TDD)
   - Automated testing

3. **Better Project Structure**
   - More granular folder organization
   - Separate test project
   - Configuration management

4. **Logging System**
   - Implement comprehensive logging
   - Error tracking
   - Performance monitoring

5. **Use Modern UI Framework**
   - Consider WPF for richer UI
   - MVVM pattern
   - Data binding improvements

#### Key Takeaways:

1. **Planning is Crucial**: Good design upfront prevents rework
2. **Security Matters**: Implement security from the beginning
3. **User Experience is Important**: Think from user's perspective
4. **Code Quality**: Clean, readable code is maintainable code
5. **Continuous Learning**: Technology evolves; keep learning
6. **Documentation**: Good documentation helps everyone, including future you

#### Impact on Future Projects:

This project provided a solid foundation for:
- Understanding full application lifecycle
- Working with databases professionally
- Building user-centric applications
- Applying software engineering principles
- Confidence in C# and .NET development

---

## 12. Conclusion

The **GreenLife Organic Store Management System** successfully demonstrates the development of a comprehensive desktop application using C# and .NET technologies. The project achieved its primary objectives:

### Achievements:

1. **Functional System**: Fully operational store management platform with distinct admin and customer interfaces

2. **Robust Architecture**: Three-tier architecture ensuring maintainability, scalability, and separation of concerns

3. **Data Integrity**: Properly designed database with referential integrity, constraints, and optimized queries

4. **Security**: Implemented industry-standard password hashing and SQL injection prevention

5. **User Experience**: Intuitive interfaces for both administrators and customers with comprehensive functionality

6. **Complete Feature Set**:
   - User authentication and registration
   - Product catalog management
   - Shopping cart and checkout
   - Order processing and tracking
   - Inventory management with low-stock alerts
   - Sales reporting and data export

### Technical Accomplishments:

- **Clean Code**: Organized project structure following best practices
- **Design Patterns**: Repository pattern for data access abstraction
- **LINQ Integration**: Efficient data manipulation and querying
- **Error Handling**: Comprehensive exception handling throughout
- **Input Validation**: Multiple validation layers for data integrity
- **Database Auto-Initialization**: Seamless first-run setup

### Limitations and Known Issues:

1. **Single-User Concurrency**: No multi-user conflict resolution (e.g., two users buying last item)
2. **No Offline Mode**: Requires constant database connectivity
3. **Limited Reporting**: Basic reports; could be more comprehensive
4. **No Payment Integration**: Checkout simulation only
5. **Fixed Database**: Hardcoded to localhost SQL Server

### Future Enhancements:

1. **Web Version**: Convert to ASP.NET Core web application for accessibility
2. **Mobile App**: Develop mobile client for customers
3. **Advanced Reporting**: Graphical dashboards, trend analysis
4. **Email Notifications**: Order confirmations, shipping updates
5. **Payment Gateway**: Integrate real payment processing
6. **Product Images**: Visual product catalog
7. **Review System**: Complete product review functionality
8. **Discount System**: Implement promo codes and coupons
9. **Inventory Alerts**: Automated low-stock notifications
10. **Analytics**: Business intelligence and sales analytics

### Personal Conclusion:

This project was an invaluable learning experience that bridged theoretical knowledge with practical application development. It reinforced the importance of:

- **Proper Planning**: Design decisions made early have lasting impact
- **Security First**: Security cannot be bolted on later
- **User-Centric Design**: Software must serve user needs
- **Clean Code**: Maintainability is as important as functionality
- **Continuous Improvement**: Software is never truly "finished"

The skills acquired—from database design to UI development, from security implementation to documentation—form a strong foundation for future software development endeavors. This project demonstrates not just technical competence, but also the ability to deliver a complete, functional application that solves real-world problems.

### Final Thoughts:

The **GreenLife Organic Store Management System** stands as a testament to the power of modern development tools and frameworks. While there is always room for improvement, the system successfully accomplishes its goals and provides a solid platform for future enhancements. Most importantly, it represents significant personal and professional growth in software development.

---

## 13. References

### Documentation and Official Resources:

1. **Microsoft .NET Documentation**
   - URL: https://docs.microsoft.com/en-us/dotnet/
   - Topics: C# language reference, .NET framework documentation

2. **Microsoft SQL Server Documentation**
   - URL: https://docs.microsoft.com/en-us/sql/
   - Topics: T-SQL reference, database design, performance tuning

3. **Windows Forms Documentation**
   - URL: https://docs.microsoft.com/en-us/dotnet/desktop/winforms/
   - Topics: Form controls, event handling, data binding

4. **ADO.NET Documentation**
   - URL: https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/
   - Topics: Database connectivity, SqlCommand, SqlDataReader

5. **LINQ Documentation**
   - URL: https://docs.microsoft.com/en-us/dotnet/csharp/linq/
   - Topics: Query syntax, lambda expressions, standard query operators

### NuGet Packages:

6. **BCrypt.Net-Next**
   - URL: https://www.nuget.org/packages/BCrypt.Net-Next/
   - Version: 4.0.3
   - Purpose: Password hashing and verification

7. **EPPlus**
   - URL: https://www.nuget.org/packages/EPPlus/
   - Version: 7.0.5
   - Purpose: Excel file generation and manipulation
   - License: Polyform Noncommercial

8. **iTextSharp.LGPLv2.Core**
   - URL: https://www.nuget.org/packages/iTextSharp.LGPLv2.Core/
   - Version: 3.4.23
   - Purpose: PDF generation (future enhancement)

9. **System.Data.SqlClient**
   - URL: https://www.nuget.org/packages/System.Data.SqlClient/
   - Version: 4.8.6
   - Purpose: SQL Server database connectivity

### Books and Learning Resources:

10. **C# 10 in a Nutshell** by Joseph Albahari and Ben Albahari
    - Publisher: O'Reilly Media
    - Topics: C# language features, .NET framework

11. **Pro ASP.NET Core 6** by Adam Freeman
    - Publisher: Apress
    - Topics: .NET architecture, design patterns

12. **Database Design for Mere Mortals** by Michael J. Hernandez
    - Publisher: Addison-Wesley
    - Topics: Database normalization, schema design

### Online Tutorials and Guides:

13. **Stack Overflow**
    - URL: https://stackoverflow.com/
    - Used for: Troubleshooting specific issues, best practices

14. **C# Corner**
    - URL: https://www.c-sharpcorner.com/
    - Topics: C# tutorials, code samples, articles

15. **GitHub**
    - URL: https://github.com/
    - Purpose: Version control, code hosting, open-source references

16. **Code Project**
    - URL: https://www.codeproject.com/
    - Topics: Windows Forms tutorials, ADO.NET examples

### Design Patterns and Architecture:

17. **Repository Pattern**
    - Reference: Microsoft Architecture Guide
    - URL: https://docs.microsoft.com/en-us/dotnet/architecture/

18. **Three-Tier Architecture**
    - Reference: Microsoft Application Architecture Guide
    - Concepts: Presentation, Business Logic, Data layers

### Security References:

19. **OWASP (Open Web Application Security Project)**
    - URL: https://owasp.org/
    - Topics: SQL injection prevention, password hashing

20. **BCrypt Algorithm**
    - Original paper: "A Future-Adaptable Password Scheme" by Niels Provos and David Mazières
    - Purpose: Understanding password hashing

### Tools and Software:

21. **Visual Studio 2022**
    - Publisher: Microsoft
    - URL: https://visualstudio.microsoft.com/
    - Purpose: IDE for development

22. **SQL Server Management Studio (SSMS)**
    - Publisher: Microsoft
    - Purpose: Database management and query execution

23. **Git for Windows**
    - URL: https://gitforwindows.org/
    - Purpose: Version control (if used)

### Additional Learning Resources:

24. **Microsoft Learn**
    - URL: https://learn.microsoft.com/
    - Free interactive tutorials and learning paths

25. **Pluralsight**
    - URL: https://www.pluralsight.com/
    - Video courses on C#, .NET, and software development

26. **YouTube Channels**
    - IAmTimCorey (C# tutorials)
    - Kudvenkat (.NET and SQL Server)
    - Programming with Mosh (general programming)

### Community Forums:

27. **Reddit - r/csharp**
    - URL: https://www.reddit.com/r/csharp/
    - Community discussions and help

28. **Microsoft Q&A**
    - URL: https://learn.microsoft.com/en-us/answers/
    - Official Microsoft support forums

### Standards and Best Practices:

29. **C# Coding Conventions**
    - URL: https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
    - Naming conventions, code organization

30. **Database Normalization Rules**
    - Reference: Codd's Normal Forms (1NF, 2NF, 3NF)
    - Applied in database design

### Acknowledgments:

- **Microsoft**: For comprehensive documentation and free development tools
- **Stack Overflow Community**: For troubleshooting assistance
- **Open Source Contributors**: BCrypt, EPPlus, and other library maintainers
- **Educational Institutions**: For foundational programming knowledge

---

**Document Version**: 1.0  
**Last Updated**: February 18, 2026  
**Author**: [Your Name]  
**Project**: GreenLife Organic Store Management System  
**Technology Stack**: C# 10, .NET 10.0, Windows Forms, SQL Server  

---

**End of Documentation**
