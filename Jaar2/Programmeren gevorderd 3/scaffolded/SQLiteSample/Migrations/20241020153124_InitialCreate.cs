using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQLiteSample.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar (15)", nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: true),
                    Picture = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nchar (5)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar (40)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar (30)", nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar (30)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar (60)", nullable: true),
                    City = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar (10)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar (24)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar (24)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar (20)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar (10)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar (30)", nullable: true),
                    TitleOfCourtesy = table.Column<string>(type: "nvarchar (25)", nullable: true),
                    BirthDate = table.Column<string>(type: "datetime", nullable: true),
                    HireDate = table.Column<string>(type: "datetime", nullable: true),
                    Address = table.Column<string>(type: "nvarchar (60)", nullable: true),
                    City = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar (10)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar (24)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar (4)", nullable: true),
                    Photo = table.Column<byte[]>(type: "image", nullable: true),
                    Notes = table.Column<string>(type: "ntext", nullable: true),
                    ReportsTo = table.Column<int>(type: "INT", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar (255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTerritories",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "INT", nullable: false),
                    TerritoryId = table.Column<string>(type: "nvarchar] (20", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    ShipperId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar (40)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar (24)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.ShipperId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar (40)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar (30)", nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar (30)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar (60)", nullable: true),
                    City = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar (10)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar (24)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar (24)", nullable: true),
                    HomePage = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Territories",
                columns: table => new
                {
                    TerritoryId = table.Column<string>(type: "nvarchar] (20", nullable: false),
                    TerritoryDescription = table.Column<string>(type: "nchar] (50", nullable: false),
                    RegionId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<string>(type: "nchar (5)", nullable: true),
                    EmployeeId = table.Column<int>(type: "INT", nullable: true),
                    OrderDate = table.Column<string>(type: "datetime", nullable: true),
                    RequiredDate = table.Column<string>(type: "datetime", nullable: true),
                    ShippedDate = table.Column<string>(type: "datetime", nullable: true),
                    ShipVia = table.Column<int>(type: "INT", nullable: true),
                    Freight = table.Column<double>(type: "money", nullable: true, defaultValue: 0.0),
                    ShipName = table.Column<string>(type: "nvarchar (40)", nullable: true),
                    ShipAddress = table.Column<string>(type: "nvarchar (60)", nullable: true),
                    ShipCity = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    ShipRegion = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    ShipPostalCode = table.Column<string>(type: "nvarchar (10)", nullable: true),
                    ShipCountry = table.Column<string>(type: "nvarchar (15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Orders_Shippers_ShipVia",
                        column: x => x.ShipVia,
                        principalTable: "Shippers",
                        principalColumn: "ShipperId");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar (40)", nullable: false),
                    SupplierId = table.Column<int>(type: "INT", nullable: true),
                    CategoryId = table.Column<int>(type: "INT", nullable: true),
                    QuantityPerUnit = table.Column<string>(type: "nvarchar (20)", nullable: true),
                    UnitPrice = table.Column<double>(type: "money", nullable: true, defaultValue: 0.0),
                    UnitsInStock = table.Column<short>(type: "smallint", nullable: true, defaultValue: (short)0),
                    UnitsOnOrder = table.Column<short>(type: "smallint", nullable: true, defaultValue: (short)0),
                    ReorderLevel = table.Column<short>(type: "smallint", nullable: true, defaultValue: (short)0),
                    Discontinued = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "Order Details",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INT", nullable: false),
                    ProductId = table.Column<int>(type: "INT", nullable: false),
                    UnitPrice = table.Column<double>(type: "money", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    Discount = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order Details", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Order Details_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_Order Details_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "CategoryName",
                table: "Categories",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "City",
                table: "Customers",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "CompanyNameCustomers",
                table: "Customers",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "PostalCodeCustomers",
                table: "Customers",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "Region",
                table: "Customers",
                column: "Region");

            migrationBuilder.CreateIndex(
                name: "LastName",
                table: "Employees",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "PostalCodeEmployees",
                table: "Employees",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "OrderId",
                table: "Order Details",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "OrdersOrder_Details",
                table: "Order Details",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "ProductId",
                table: "Order Details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "ProductsOrder_Details",
                table: "Order Details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "CustomersOrders",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "EmployeesOrders",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "OrderDate",
                table: "Orders",
                column: "OrderDate");

            migrationBuilder.CreateIndex(
                name: "ShippedDate",
                table: "Orders",
                column: "ShippedDate");

            migrationBuilder.CreateIndex(
                name: "ShippersOrders",
                table: "Orders",
                column: "ShipVia");

            migrationBuilder.CreateIndex(
                name: "ShipPostalCode",
                table: "Orders",
                column: "ShipPostalCode");

            migrationBuilder.CreateIndex(
                name: "CategoriesProducts",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "ProductName",
                table: "Products",
                column: "ProductName");

            migrationBuilder.CreateIndex(
                name: "SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "SuppliersProducts",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "CompanyNameSuppliers",
                table: "Suppliers",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "PostalCodeSuppliers",
                table: "Suppliers",
                column: "PostalCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTerritories");

            migrationBuilder.DropTable(
                name: "Order Details");

            migrationBuilder.DropTable(
                name: "Territories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
