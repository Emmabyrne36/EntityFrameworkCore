using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreEF.WideWorldModel
{
    public partial class WideWorldImportersContext : DbContext
    {
        public WideWorldImportersContext()
        {
        }

        public WideWorldImportersContext(DbContextOptions<WideWorldImportersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<CityStaging> CityStaging { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerStaging> CustomerStaging { get; set; }
        public virtual DbSet<Date> Date { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeStaging> EmployeeStaging { get; set; }
        public virtual DbSet<EtlCutoff> EtlCutoff { get; set; }
        public virtual DbSet<Lineage> Lineage { get; set; }
        public virtual DbSet<Movement> Movement { get; set; }
        public virtual DbSet<MovementStaging> MovementStaging { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderStaging> OrderStaging { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<PaymentMethodStaging> PaymentMethodStaging { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<PurchaseStaging> PurchaseStaging { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<SaleStaging> SaleStaging { get; set; }
        public virtual DbSet<StockHolding> StockHolding { get; set; }
        public virtual DbSet<StockHoldingStaging> StockHoldingStaging { get; set; }
        public virtual DbSet<StockItem> StockItem { get; set; }
        public virtual DbSet<StockItemStaging> StockItemStaging { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SupplierStaging> SupplierStaging { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<TransactionStaging> TransactionStaging { get; set; }
        public virtual DbSet<TransactionType> TransactionType { get; set; }
        public virtual DbSet<TransactionTypeStaging> TransactionTypeStaging { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local);Database=WideWorldImportersDW;Trusted_connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityKey)
                    .HasName("PK_Dimension_City");

                entity.ToTable("City", "Dimension");

                entity.HasIndex(e => new { e.WwiCityId, e.ValidFrom, e.ValidTo })
                    .HasName("IX_Dimension_City_WWICityID");

                entity.Property(e => e.CityKey)
                    .HasColumnName("City Key")
                    .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[CityKey])");

                entity.Property(e => e.City1)
                    .IsRequired()
                    .HasColumnName("City")
                    .HasMaxLength(50);

                entity.Property(e => e.Continent)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.LatestRecordedPopulation).HasColumnName("Latest Recorded Population");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.SalesTerritory)
                    .IsRequired()
                    .HasColumnName("Sales Territory")
                    .HasMaxLength(50);

                entity.Property(e => e.StateProvince)
                    .IsRequired()
                    .HasColumnName("State Province")
                    .HasMaxLength(50);

                entity.Property(e => e.Subregion)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiCityId).HasColumnName("WWI City ID");
            });

            modelBuilder.Entity<CityStaging>(entity =>
            {
                entity.HasKey(e => e.CityStagingKey)
                    .HasName("PK_Integration_City_Staging");

                entity.ToTable("City_Staging", "Integration");

                entity.HasIndex(e => e.WwiCityId)
                    .HasName("IX_Integration_City_Staging_WWI_City_ID");

                entity.Property(e => e.CityStagingKey).HasColumnName("City Staging Key");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Continent)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.LatestRecordedPopulation).HasColumnName("Latest Recorded Population");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.SalesTerritory)
                    .IsRequired()
                    .HasColumnName("Sales Territory")
                    .HasMaxLength(50);

                entity.Property(e => e.StateProvince)
                    .IsRequired()
                    .HasColumnName("State Province")
                    .HasMaxLength(50);

                entity.Property(e => e.Subregion)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiCityId).HasColumnName("WWI City ID");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerKey)
                    .HasName("PK_Dimension_Customer");

                entity.ToTable("Customer", "Dimension");

                entity.HasIndex(e => new { e.WwiCustomerId, e.ValidFrom, e.ValidTo })
                    .HasName("IX_Dimension_Customer_WWICustomerID");

                entity.Property(e => e.CustomerKey)
                    .HasColumnName("Customer Key")
                    .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[CustomerKey])");

                entity.Property(e => e.BillToCustomer)
                    .IsRequired()
                    .HasColumnName("Bill To Customer")
                    .HasMaxLength(100);

                entity.Property(e => e.BuyingGroup)
                    .IsRequired()
                    .HasColumnName("Buying Group")
                    .HasMaxLength(50);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Customer1)
                    .IsRequired()
                    .HasColumnName("Customer")
                    .HasMaxLength(100);

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("Postal Code")
                    .HasMaxLength(10);

                entity.Property(e => e.PrimaryContact)
                    .IsRequired()
                    .HasColumnName("Primary Contact")
                    .HasMaxLength(50);

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiCustomerId).HasColumnName("WWI Customer ID");
            });

            modelBuilder.Entity<CustomerStaging>(entity =>
            {
                entity.HasKey(e => e.CustomerStagingKey)
                    .HasName("PK_Integration_Customer_Staging")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Customer_Staging", "Integration");

                entity.HasAnnotation("SqlServer:MemoryOptimized", true);

                entity.Property(e => e.CustomerStagingKey).HasColumnName("Customer Staging Key");

                entity.Property(e => e.BillToCustomer)
                    .IsRequired()
                    .HasColumnName("Bill To Customer")
                    .HasMaxLength(100);

                entity.Property(e => e.BuyingGroup)
                    .IsRequired()
                    .HasColumnName("Buying Group")
                    .HasMaxLength(50);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Customer)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("Postal Code")
                    .HasMaxLength(10);

                entity.Property(e => e.PrimaryContact)
                    .IsRequired()
                    .HasColumnName("Primary Contact")
                    .HasMaxLength(50);

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiCustomerId).HasColumnName("WWI Customer ID");
            });

            modelBuilder.Entity<Date>(entity =>
            {
                entity.HasKey(e => e.Date1)
                    .HasName("PK_Dimension_Date");

                entity.ToTable("Date", "Dimension");

                entity.Property(e => e.Date1)
                    .HasColumnName("Date")
                    .HasColumnType("date");

                entity.Property(e => e.CalendarMonthLabel)
                    .IsRequired()
                    .HasColumnName("Calendar Month Label")
                    .HasMaxLength(20);

                entity.Property(e => e.CalendarMonthNumber).HasColumnName("Calendar Month Number");

                entity.Property(e => e.CalendarYear).HasColumnName("Calendar Year");

                entity.Property(e => e.CalendarYearLabel)
                    .IsRequired()
                    .HasColumnName("Calendar Year Label")
                    .HasMaxLength(10);

                entity.Property(e => e.Day)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.DayNumber).HasColumnName("Day Number");

                entity.Property(e => e.FiscalMonthLabel)
                    .IsRequired()
                    .HasColumnName("Fiscal Month Label")
                    .HasMaxLength(20);

                entity.Property(e => e.FiscalMonthNumber).HasColumnName("Fiscal Month Number");

                entity.Property(e => e.FiscalYear).HasColumnName("Fiscal Year");

                entity.Property(e => e.FiscalYearLabel)
                    .IsRequired()
                    .HasColumnName("Fiscal Year Label")
                    .HasMaxLength(10);

                entity.Property(e => e.IsoWeekNumber).HasColumnName("ISO Week Number");

                entity.Property(e => e.Month)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ShortMonth)
                    .IsRequired()
                    .HasColumnName("Short Month")
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeKey)
                    .HasName("PK_Dimension_Employee");

                entity.ToTable("Employee", "Dimension");

                entity.HasIndex(e => new { e.WwiEmployeeId, e.ValidFrom, e.ValidTo })
                    .HasName("IX_Dimension_Employee_WWIEmployeeID");

                entity.Property(e => e.EmployeeKey)
                    .HasColumnName("Employee Key")
                    .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[EmployeeKey])");

                entity.Property(e => e.Employee1)
                    .IsRequired()
                    .HasColumnName("Employee")
                    .HasMaxLength(50);

                entity.Property(e => e.IsSalesperson).HasColumnName("Is Salesperson");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.PreferredName)
                    .IsRequired()
                    .HasColumnName("Preferred Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiEmployeeId).HasColumnName("WWI Employee ID");
            });

            modelBuilder.Entity<EmployeeStaging>(entity =>
            {
                entity.HasKey(e => e.EmployeeStagingKey)
                    .HasName("PK_Integration_Employee_Staging")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Employee_Staging", "Integration");

                entity.HasAnnotation("SqlServer:MemoryOptimized", true);

                entity.Property(e => e.EmployeeStagingKey).HasColumnName("Employee Staging Key");

                entity.Property(e => e.Employee)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsSalesperson).HasColumnName("Is Salesperson");

                entity.Property(e => e.PreferredName)
                    .IsRequired()
                    .HasColumnName("Preferred Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiEmployeeId).HasColumnName("WWI Employee ID");
            });

            modelBuilder.Entity<EtlCutoff>(entity =>
            {
                entity.HasKey(e => e.TableName)
                    .HasName("PK_Integration_ETL_Cutoff");

                entity.ToTable("ETL Cutoff", "Integration");

                entity.Property(e => e.TableName)
                    .HasColumnName("Table Name")
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.CutoffTime).HasColumnName("Cutoff Time");
            });

            modelBuilder.Entity<Lineage>(entity =>
            {
                entity.HasKey(e => e.LineageKey)
                    .HasName("PK_Integration_Lineage");

                entity.ToTable("Lineage", "Integration");

                entity.Property(e => e.LineageKey)
                    .HasColumnName("Lineage Key")
                    .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[LineageKey])");

                entity.Property(e => e.DataLoadCompleted).HasColumnName("Data Load Completed");

                entity.Property(e => e.DataLoadStarted).HasColumnName("Data Load Started");

                entity.Property(e => e.SourceSystemCutoffTime).HasColumnName("Source System Cutoff Time");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasColumnName("Table Name")
                    .HasMaxLength(128);

                entity.Property(e => e.WasSuccessful).HasColumnName("Was Successful");
            });

            modelBuilder.Entity<Movement>(entity =>
            {
                entity.HasKey(e => new { e.MovementKey, e.DateKey })
                    .HasName("PK_Fact_Movement")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Movement", "Fact");

                entity.HasIndex(e => e.DateKey)
                    .HasName("FK_Fact_Movement_Date_Key");

                entity.HasIndex(e => new { e.DateKey, e.CustomerKey })
                    .HasName("FK_Fact_Movement_Customer_Key");

                entity.HasIndex(e => new { e.DateKey, e.StockItemKey })
                    .HasName("FK_Fact_Movement_Stock_Item_Key");

                entity.HasIndex(e => new { e.DateKey, e.SupplierKey })
                    .HasName("FK_Fact_Movement_Supplier_Key");

                entity.HasIndex(e => new { e.DateKey, e.TransactionTypeKey })
                    .HasName("FK_Fact_Movement_Transaction_Type_Key");

                entity.HasIndex(e => new { e.DateKey, e.WwiStockItemTransactionId })
                    .HasName("IX_Integration_Movement_WWI_Stock_Item_Transaction_ID");

                entity.HasIndex(e => new { e.MovementKey, e.DateKey, e.StockItemKey, e.CustomerKey, e.SupplierKey, e.TransactionTypeKey, e.WwiStockItemTransactionId, e.WwiInvoiceId, e.WwiPurchaseOrderId, e.Quantity, e.LineageKey })
                    .HasName("CCX_Fact_Movement");

                entity.Property(e => e.MovementKey)
                    .HasColumnName("Movement Key")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DateKey)
                    .HasColumnName("Date Key")
                    .HasColumnType("date");

                entity.Property(e => e.CustomerKey).HasColumnName("Customer Key");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.SupplierKey).HasColumnName("Supplier Key");

                entity.Property(e => e.TransactionTypeKey).HasColumnName("Transaction Type Key");

                entity.Property(e => e.WwiInvoiceId).HasColumnName("WWI Invoice ID");

                entity.Property(e => e.WwiPurchaseOrderId).HasColumnName("WWI Purchase Order ID");

                entity.Property(e => e.WwiStockItemTransactionId).HasColumnName("WWI Stock Item Transaction ID");

                entity.HasOne(d => d.CustomerKeyNavigation)
                    .WithMany(p => p.Movement)
                    .HasForeignKey(d => d.CustomerKey)
                    .HasConstraintName("FK_Fact_Movement_Customer_Key_Dimension_Customer");

                entity.HasOne(d => d.DateKeyNavigation)
                    .WithMany(p => p.Movement)
                    .HasForeignKey(d => d.DateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Movement_Date_Key_Dimension_Date");

                entity.HasOne(d => d.StockItemKeyNavigation)
                    .WithMany(p => p.Movement)
                    .HasForeignKey(d => d.StockItemKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Movement_Stock_Item_Key_Dimension_Stock Item");

                entity.HasOne(d => d.SupplierKeyNavigation)
                    .WithMany(p => p.Movement)
                    .HasForeignKey(d => d.SupplierKey)
                    .HasConstraintName("FK_Fact_Movement_Supplier_Key_Dimension_Supplier");

                entity.HasOne(d => d.TransactionTypeKeyNavigation)
                    .WithMany(p => p.Movement)
                    .HasForeignKey(d => d.TransactionTypeKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Movement_Transaction_Type_Key_Dimension_Transaction Type");
            });

            modelBuilder.Entity<MovementStaging>(entity =>
            {
                entity.HasKey(e => e.MovementStagingKey)
                    .HasName("PK_Integration_Movement_Staging")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Movement_Staging", "Integration");

                entity.HasAnnotation("SqlServer:MemoryOptimized", true);

                entity.Property(e => e.MovementStagingKey).HasColumnName("Movement Staging Key");

                entity.Property(e => e.CustomerKey).HasColumnName("Customer Key");

                entity.Property(e => e.DateKey)
                    .HasColumnName("Date Key")
                    .HasColumnType("date");

                entity.Property(e => e.LastModifedWhen).HasColumnName("Last Modifed When");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.SupplierKey).HasColumnName("Supplier Key");

                entity.Property(e => e.TransactionTypeKey).HasColumnName("Transaction Type Key");

                entity.Property(e => e.WwiCustomerId).HasColumnName("WWI Customer ID");

                entity.Property(e => e.WwiInvoiceId).HasColumnName("WWI Invoice ID");

                entity.Property(e => e.WwiPurchaseOrderId).HasColumnName("WWI Purchase Order ID");

                entity.Property(e => e.WwiStockItemId).HasColumnName("WWI Stock Item ID");

                entity.Property(e => e.WwiStockItemTransactionId).HasColumnName("WWI Stock Item Transaction ID");

                entity.Property(e => e.WwiSupplierId).HasColumnName("WWI Supplier ID");

                entity.Property(e => e.WwiTransactionTypeId).HasColumnName("WWI Transaction Type ID");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => new { e.OrderKey, e.OrderDateKey })
                    .HasName("PK_Fact_Order")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Order", "Fact");

                entity.HasIndex(e => e.OrderDateKey)
                    .HasName("FK_Fact_Order_Order_Date_Key");

                entity.HasIndex(e => new { e.OrderDateKey, e.CityKey })
                    .HasName("FK_Fact_Order_City_Key");

                entity.HasIndex(e => new { e.OrderDateKey, e.CustomerKey })
                    .HasName("FK_Fact_Order_Customer_Key");

                entity.HasIndex(e => new { e.OrderDateKey, e.PickedDateKey })
                    .HasName("FK_Fact_Order_Picked_Date_Key");

                entity.HasIndex(e => new { e.OrderDateKey, e.PickerKey })
                    .HasName("FK_Fact_Order_Picker_Key");

                entity.HasIndex(e => new { e.OrderDateKey, e.SalespersonKey })
                    .HasName("FK_Fact_Order_Salesperson_Key");

                entity.HasIndex(e => new { e.OrderDateKey, e.StockItemKey })
                    .HasName("FK_Fact_Order_Stock_Item_Key");

                entity.HasIndex(e => new { e.OrderDateKey, e.WwiOrderId })
                    .HasName("IX_Integration_Order_WWI_Order_ID");

                entity.HasIndex(e => new { e.OrderKey, e.CityKey, e.CustomerKey, e.StockItemKey, e.OrderDateKey, e.PickedDateKey, e.SalespersonKey, e.PickerKey, e.WwiOrderId, e.WwiBackorderId, e.Description, e.Package, e.Quantity, e.UnitPrice, e.TaxRate, e.TotalExcludingTax, e.TaxAmount, e.TotalIncludingTax, e.LineageKey })
                    .HasName("CCX_Fact_Order");

                entity.Property(e => e.OrderKey)
                    .HasColumnName("Order Key")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.OrderDateKey)
                    .HasColumnName("Order Date Key")
                    .HasColumnType("date");

                entity.Property(e => e.CityKey).HasColumnName("City Key");

                entity.Property(e => e.CustomerKey).HasColumnName("Customer Key");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.Package)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PickedDateKey)
                    .HasColumnName("Picked Date Key")
                    .HasColumnType("date");

                entity.Property(e => e.PickerKey).HasColumnName("Picker Key");

                entity.Property(e => e.SalespersonKey).HasColumnName("Salesperson Key");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.TaxAmount)
                    .HasColumnName("Tax Amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxRate)
                    .HasColumnName("Tax Rate")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TotalExcludingTax)
                    .HasColumnName("Total Excluding Tax")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalIncludingTax)
                    .HasColumnName("Total Including Tax")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("Unit Price")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WwiBackorderId).HasColumnName("WWI Backorder ID");

                entity.Property(e => e.WwiOrderId).HasColumnName("WWI Order ID");

                entity.HasOne(d => d.CityKeyNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CityKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Order_City_Key_Dimension_City");

                entity.HasOne(d => d.CustomerKeyNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Order_Customer_Key_Dimension_Customer");

                entity.HasOne(d => d.OrderDateKeyNavigation)
                    .WithMany(p => p.OrderOrderDateKeyNavigation)
                    .HasForeignKey(d => d.OrderDateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Order_Order_Date_Key_Dimension_Date");

                entity.HasOne(d => d.PickedDateKeyNavigation)
                    .WithMany(p => p.OrderPickedDateKeyNavigation)
                    .HasForeignKey(d => d.PickedDateKey)
                    .HasConstraintName("FK_Fact_Order_Picked_Date_Key_Dimension_Date");

                entity.HasOne(d => d.PickerKeyNavigation)
                    .WithMany(p => p.OrderPickerKeyNavigation)
                    .HasForeignKey(d => d.PickerKey)
                    .HasConstraintName("FK_Fact_Order_Picker_Key_Dimension_Employee");

                entity.HasOne(d => d.SalespersonKeyNavigation)
                    .WithMany(p => p.OrderSalespersonKeyNavigation)
                    .HasForeignKey(d => d.SalespersonKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Order_Salesperson_Key_Dimension_Employee");

                entity.HasOne(d => d.StockItemKeyNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.StockItemKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Order_Stock_Item_Key_Dimension_Stock Item");
            });

            modelBuilder.Entity<OrderStaging>(entity =>
            {
                entity.HasKey(e => e.OrderStagingKey)
                    .HasName("PK_Integration_Order_Staging")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Order_Staging", "Integration");

                entity.HasAnnotation("SqlServer:MemoryOptimized", true);

                entity.Property(e => e.OrderStagingKey).HasColumnName("Order Staging Key");

                entity.Property(e => e.CityKey).HasColumnName("City Key");

                entity.Property(e => e.CustomerKey).HasColumnName("Customer Key");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.LastModifiedWhen).HasColumnName("Last Modified When");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.OrderDateKey)
                    .HasColumnName("Order Date Key")
                    .HasColumnType("date");

                entity.Property(e => e.Package).HasMaxLength(50);

                entity.Property(e => e.PickedDateKey)
                    .HasColumnName("Picked Date Key")
                    .HasColumnType("date");

                entity.Property(e => e.PickerKey).HasColumnName("Picker Key");

                entity.Property(e => e.SalespersonKey).HasColumnName("Salesperson Key");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.TaxAmount)
                    .HasColumnName("Tax Amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxRate)
                    .HasColumnName("Tax Rate")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TotalExcludingTax)
                    .HasColumnName("Total Excluding Tax")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalIncludingTax)
                    .HasColumnName("Total Including Tax")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("Unit Price")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WwiBackorderId).HasColumnName("WWI Backorder ID");

                entity.Property(e => e.WwiCityId).HasColumnName("WWI City ID");

                entity.Property(e => e.WwiCustomerId).HasColumnName("WWI Customer ID");

                entity.Property(e => e.WwiOrderId).HasColumnName("WWI Order ID");

                entity.Property(e => e.WwiPickerId).HasColumnName("WWI Picker ID");

                entity.Property(e => e.WwiSalespersonId).HasColumnName("WWI Salesperson ID");

                entity.Property(e => e.WwiStockItemId).HasColumnName("WWI Stock Item ID");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodKey)
                    .HasName("PK_Dimension_Payment_Method");

                entity.ToTable("Payment Method", "Dimension");

                entity.HasIndex(e => new { e.WwiPaymentMethodId, e.ValidFrom, e.ValidTo })
                    .HasName("IX_Dimension_Payment_Method_WWIPaymentMethodID");

                entity.Property(e => e.PaymentMethodKey)
                    .HasColumnName("Payment Method Key")
                    .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[PaymentMethodKey])");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.PaymentMethod1)
                    .IsRequired()
                    .HasColumnName("Payment Method")
                    .HasMaxLength(50);

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiPaymentMethodId).HasColumnName("WWI Payment Method ID");
            });

            modelBuilder.Entity<PaymentMethodStaging>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodStagingKey)
                    .HasName("PK_Integration_Payment_Method_Staging")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("PaymentMethod_Staging", "Integration");

                entity.HasAnnotation("SqlServer:MemoryOptimized", true);

                entity.Property(e => e.PaymentMethodStagingKey).HasColumnName("Payment Method Staging Key");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasColumnName("Payment Method")
                    .HasMaxLength(50);

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiPaymentMethodId).HasColumnName("WWI Payment Method ID");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => new { e.PurchaseKey, e.DateKey })
                    .HasName("PK_Fact_Purchase")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Purchase", "Fact");

                entity.HasIndex(e => e.DateKey)
                    .HasName("FK_Fact_Purchase_Date_Key");

                entity.HasIndex(e => new { e.DateKey, e.StockItemKey })
                    .HasName("FK_Fact_Purchase_Stock_Item_Key");

                entity.HasIndex(e => new { e.DateKey, e.SupplierKey })
                    .HasName("FK_Fact_Purchase_Supplier_Key");

                entity.HasIndex(e => new { e.PurchaseKey, e.DateKey, e.SupplierKey, e.StockItemKey, e.WwiPurchaseOrderId, e.OrderedOuters, e.OrderedQuantity, e.ReceivedOuters, e.Package, e.IsOrderFinalized, e.LineageKey })
                    .HasName("CCX_Fact_Purchase");

                entity.Property(e => e.PurchaseKey)
                    .HasColumnName("Purchase Key")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DateKey)
                    .HasColumnName("Date Key")
                    .HasColumnType("date");

                entity.Property(e => e.IsOrderFinalized).HasColumnName("Is Order Finalized");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.OrderedOuters).HasColumnName("Ordered Outers");

                entity.Property(e => e.OrderedQuantity).HasColumnName("Ordered Quantity");

                entity.Property(e => e.Package)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ReceivedOuters).HasColumnName("Received Outers");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.SupplierKey).HasColumnName("Supplier Key");

                entity.Property(e => e.WwiPurchaseOrderId).HasColumnName("WWI Purchase Order ID");

                entity.HasOne(d => d.DateKeyNavigation)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.DateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Purchase_Date_Key_Dimension_Date");

                entity.HasOne(d => d.StockItemKeyNavigation)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.StockItemKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Purchase_Stock_Item_Key_Dimension_Stock Item");

                entity.HasOne(d => d.SupplierKeyNavigation)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.SupplierKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Purchase_Supplier_Key_Dimension_Supplier");
            });

            modelBuilder.Entity<PurchaseStaging>(entity =>
            {
                entity.HasKey(e => e.PurchaseStagingKey)
                    .HasName("PK_Integration_Purchase_Staging")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Purchase_Staging", "Integration");

                entity.HasAnnotation("SqlServer:MemoryOptimized", true);

                entity.Property(e => e.PurchaseStagingKey).HasColumnName("Purchase Staging Key");

                entity.Property(e => e.DateKey)
                    .HasColumnName("Date Key")
                    .HasColumnType("date");

                entity.Property(e => e.IsOrderFinalized).HasColumnName("Is Order Finalized");

                entity.Property(e => e.LastModifiedWhen).HasColumnName("Last Modified When");

                entity.Property(e => e.OrderedOuters).HasColumnName("Ordered Outers");

                entity.Property(e => e.OrderedQuantity).HasColumnName("Ordered Quantity");

                entity.Property(e => e.Package).HasMaxLength(50);

                entity.Property(e => e.ReceivedOuters).HasColumnName("Received Outers");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.SupplierKey).HasColumnName("Supplier Key");

                entity.Property(e => e.WwiPurchaseOrderId).HasColumnName("WWI Purchase Order ID");

                entity.Property(e => e.WwiStockItemId).HasColumnName("WWI Stock Item ID");

                entity.Property(e => e.WwiSupplierId).HasColumnName("WWI Supplier ID");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => new { e.SaleKey, e.InvoiceDateKey })
                    .HasName("PK_Fact_Sale")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Sale", "Fact");

                entity.HasIndex(e => e.InvoiceDateKey)
                    .HasName("FK_Fact_Sale_Invoice_Date_Key");

                entity.HasIndex(e => new { e.InvoiceDateKey, e.BillToCustomerKey })
                    .HasName("FK_Fact_Sale_Bill_To_Customer_Key");

                entity.HasIndex(e => new { e.InvoiceDateKey, e.CityKey })
                    .HasName("FK_Fact_Sale_City_Key");

                entity.HasIndex(e => new { e.InvoiceDateKey, e.CustomerKey })
                    .HasName("FK_Fact_Sale_Customer_Key");

                entity.HasIndex(e => new { e.InvoiceDateKey, e.DeliveryDateKey })
                    .HasName("FK_Fact_Sale_Delivery_Date_Key");

                entity.HasIndex(e => new { e.InvoiceDateKey, e.SalespersonKey })
                    .HasName("FK_Fact_Sale_Salesperson_Key");

                entity.HasIndex(e => new { e.InvoiceDateKey, e.StockItemKey })
                    .HasName("FK_Fact_Sale_Stock_Item_Key");

                entity.HasIndex(e => new { e.SaleKey, e.CityKey, e.CustomerKey, e.BillToCustomerKey, e.StockItemKey, e.InvoiceDateKey, e.DeliveryDateKey, e.SalespersonKey, e.WwiInvoiceId, e.Description, e.Package, e.Quantity, e.UnitPrice, e.TaxRate, e.TotalExcludingTax, e.TaxAmount, e.Profit, e.TotalIncludingTax, e.TotalDryItems, e.TotalChillerItems, e.LineageKey })
                    .HasName("CCX_Fact_Sale");

                entity.Property(e => e.SaleKey)
                    .HasColumnName("Sale Key")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.InvoiceDateKey)
                    .HasColumnName("Invoice Date Key")
                    .HasColumnType("date");

                entity.Property(e => e.BillToCustomerKey).HasColumnName("Bill To Customer Key");

                entity.Property(e => e.CityKey).HasColumnName("City Key");

                entity.Property(e => e.CustomerKey).HasColumnName("Customer Key");

                entity.Property(e => e.DeliveryDateKey)
                    .HasColumnName("Delivery Date Key")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.Package)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Profit).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SalespersonKey).HasColumnName("Salesperson Key");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.TaxAmount)
                    .HasColumnName("Tax Amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxRate)
                    .HasColumnName("Tax Rate")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TotalChillerItems).HasColumnName("Total Chiller Items");

                entity.Property(e => e.TotalDryItems).HasColumnName("Total Dry Items");

                entity.Property(e => e.TotalExcludingTax)
                    .HasColumnName("Total Excluding Tax")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalIncludingTax)
                    .HasColumnName("Total Including Tax")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("Unit Price")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WwiInvoiceId).HasColumnName("WWI Invoice ID");

                entity.HasOne(d => d.BillToCustomerKeyNavigation)
                    .WithMany(p => p.SaleBillToCustomerKeyNavigation)
                    .HasForeignKey(d => d.BillToCustomerKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Sale_Bill_To_Customer_Key_Dimension_Customer");

                entity.HasOne(d => d.CityKeyNavigation)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.CityKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Sale_City_Key_Dimension_City");

                entity.HasOne(d => d.CustomerKeyNavigation)
                    .WithMany(p => p.SaleCustomerKeyNavigation)
                    .HasForeignKey(d => d.CustomerKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Sale_Customer_Key_Dimension_Customer");

                entity.HasOne(d => d.DeliveryDateKeyNavigation)
                    .WithMany(p => p.SaleDeliveryDateKeyNavigation)
                    .HasForeignKey(d => d.DeliveryDateKey)
                    .HasConstraintName("FK_Fact_Sale_Delivery_Date_Key_Dimension_Date");

                entity.HasOne(d => d.InvoiceDateKeyNavigation)
                    .WithMany(p => p.SaleInvoiceDateKeyNavigation)
                    .HasForeignKey(d => d.InvoiceDateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Sale_Invoice_Date_Key_Dimension_Date");

                entity.HasOne(d => d.SalespersonKeyNavigation)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.SalespersonKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Sale_Salesperson_Key_Dimension_Employee");

                entity.HasOne(d => d.StockItemKeyNavigation)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.StockItemKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Sale_Stock_Item_Key_Dimension_Stock Item");
            });

            modelBuilder.Entity<SaleStaging>(entity =>
            {
                entity.HasKey(e => e.SaleStagingKey)
                    .HasName("PK_Integration_Sale_Staging")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Sale_Staging", "Integration");

                entity.HasAnnotation("SqlServer:MemoryOptimized", true);

                entity.Property(e => e.SaleStagingKey).HasColumnName("Sale Staging Key");

                entity.Property(e => e.BillToCustomerKey).HasColumnName("Bill To Customer Key");

                entity.Property(e => e.CityKey).HasColumnName("City Key");

                entity.Property(e => e.CustomerKey).HasColumnName("Customer Key");

                entity.Property(e => e.DeliveryDateKey)
                    .HasColumnName("Delivery Date Key")
                    .HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.InvoiceDateKey)
                    .HasColumnName("Invoice Date Key")
                    .HasColumnType("date");

                entity.Property(e => e.LastModifiedWhen).HasColumnName("Last Modified When");

                entity.Property(e => e.Package).HasMaxLength(50);

                entity.Property(e => e.Profit).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SalespersonKey).HasColumnName("Salesperson Key");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.TaxAmount)
                    .HasColumnName("Tax Amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxRate)
                    .HasColumnName("Tax Rate")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TotalChillerItems).HasColumnName("Total Chiller Items");

                entity.Property(e => e.TotalDryItems).HasColumnName("Total Dry Items");

                entity.Property(e => e.TotalExcludingTax)
                    .HasColumnName("Total Excluding Tax")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalIncludingTax)
                    .HasColumnName("Total Including Tax")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("Unit Price")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WwiBillToCustomerId).HasColumnName("WWI Bill To Customer ID");

                entity.Property(e => e.WwiCityId).HasColumnName("WWI City ID");

                entity.Property(e => e.WwiCustomerId).HasColumnName("WWI Customer ID");

                entity.Property(e => e.WwiInvoiceId).HasColumnName("WWI Invoice ID");

                entity.Property(e => e.WwiSalespersonId).HasColumnName("WWI Salesperson ID");

                entity.Property(e => e.WwiStockItemId).HasColumnName("WWI Stock Item ID");
            });

            modelBuilder.Entity<StockHolding>(entity =>
            {
                entity.HasKey(e => e.StockHoldingKey)
                    .HasName("PK_Fact_Stock_Holding")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Stock Holding", "Fact");

                entity.HasIndex(e => e.StockItemKey)
                    .HasName("FK_Fact_Stock_Holding_Stock_Item_Key");

                entity.HasIndex(e => new { e.StockHoldingKey, e.StockItemKey, e.QuantityOnHand, e.BinLocation, e.LastStocktakeQuantity, e.LastCostPrice, e.ReorderLevel, e.TargetStockLevel, e.LineageKey })
                    .HasName("CCX_Fact_Stock_Holding");

                entity.Property(e => e.StockHoldingKey).HasColumnName("Stock Holding Key");

                entity.Property(e => e.BinLocation)
                    .IsRequired()
                    .HasColumnName("Bin Location")
                    .HasMaxLength(20);

                entity.Property(e => e.LastCostPrice)
                    .HasColumnName("Last Cost Price")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LastStocktakeQuantity).HasColumnName("Last Stocktake Quantity");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.QuantityOnHand).HasColumnName("Quantity On Hand");

                entity.Property(e => e.ReorderLevel).HasColumnName("Reorder Level");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.TargetStockLevel).HasColumnName("Target Stock Level");

                entity.HasOne(d => d.StockItemKeyNavigation)
                    .WithMany(p => p.StockHolding)
                    .HasForeignKey(d => d.StockItemKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Stock_Holding_Stock_Item_Key_Dimension_Stock Item");
            });

            modelBuilder.Entity<StockHoldingStaging>(entity =>
            {
                entity.HasKey(e => e.StockHoldingStagingKey)
                    .HasName("PK_Integration_Stock_Holding_Staging")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("StockHolding_Staging", "Integration");

                entity.HasAnnotation("SqlServer:MemoryOptimized", true);

                entity.Property(e => e.StockHoldingStagingKey).HasColumnName("Stock Holding Staging Key");

                entity.Property(e => e.BinLocation)
                    .HasColumnName("Bin Location")
                    .HasMaxLength(20);

                entity.Property(e => e.LastCostPrice)
                    .HasColumnName("Last Cost Price")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LastStocktakeQuantity).HasColumnName("Last Stocktake Quantity");

                entity.Property(e => e.QuantityOnHand).HasColumnName("Quantity On Hand");

                entity.Property(e => e.ReorderLevel).HasColumnName("Reorder Level");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.TargetStockLevel).HasColumnName("Target Stock Level");

                entity.Property(e => e.WwiStockItemId).HasColumnName("WWI Stock Item ID");
            });

            modelBuilder.Entity<StockItem>(entity =>
            {
                entity.HasKey(e => e.StockItemKey)
                    .HasName("PK_Dimension_Stock_Item");

                entity.ToTable("Stock Item", "Dimension");

                entity.HasIndex(e => new { e.WwiStockItemId, e.ValidFrom, e.ValidTo })
                    .HasName("IX_Dimension_Stock_Item_WWIStockItemID");

                entity.Property(e => e.StockItemKey)
                    .HasColumnName("Stock Item Key")
                    .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[StockItemKey])");

                entity.Property(e => e.Barcode).HasMaxLength(50);

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BuyingPackage)
                    .IsRequired()
                    .HasColumnName("Buying Package")
                    .HasMaxLength(50);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.IsChillerStock).HasColumnName("Is Chiller Stock");

                entity.Property(e => e.LeadTimeDays).HasColumnName("Lead Time Days");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.QuantityPerOuter).HasColumnName("Quantity Per Outer");

                entity.Property(e => e.RecommendedRetailPrice)
                    .HasColumnName("Recommended Retail Price")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SellingPackage)
                    .IsRequired()
                    .HasColumnName("Selling Package")
                    .HasMaxLength(50);

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.StockItem1)
                    .IsRequired()
                    .HasColumnName("Stock Item")
                    .HasMaxLength(100);

                entity.Property(e => e.TaxRate)
                    .HasColumnName("Tax Rate")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TypicalWeightPerUnit)
                    .HasColumnName("Typical Weight Per Unit")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("Unit Price")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiStockItemId).HasColumnName("WWI Stock Item ID");
            });

            modelBuilder.Entity<StockItemStaging>(entity =>
            {
                entity.HasKey(e => e.StockItemStagingKey)
                    .HasName("PK_Integration_Stock_Item_Staging")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("StockItem_Staging", "Integration");

                entity.HasAnnotation("SqlServer:MemoryOptimized", true);

                entity.Property(e => e.StockItemStagingKey).HasColumnName("Stock Item Staging Key");

                entity.Property(e => e.Barcode).HasMaxLength(50);

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BuyingPackage)
                    .IsRequired()
                    .HasColumnName("Buying Package")
                    .HasMaxLength(50);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.IsChillerStock).HasColumnName("Is Chiller Stock");

                entity.Property(e => e.LeadTimeDays).HasColumnName("Lead Time Days");

                entity.Property(e => e.QuantityPerOuter).HasColumnName("Quantity Per Outer");

                entity.Property(e => e.RecommendedRetailPrice)
                    .HasColumnName("Recommended Retail Price")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SellingPackage)
                    .IsRequired()
                    .HasColumnName("Selling Package")
                    .HasMaxLength(50);

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.StockItem)
                    .IsRequired()
                    .HasColumnName("Stock Item")
                    .HasMaxLength(100);

                entity.Property(e => e.TaxRate)
                    .HasColumnName("Tax Rate")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TypicalWeightPerUnit)
                    .HasColumnName("Typical Weight Per Unit")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("Unit Price")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiStockItemId).HasColumnName("WWI Stock Item ID");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SupplierKey)
                    .HasName("PK_Dimension_Supplier");

                entity.ToTable("Supplier", "Dimension");

                entity.HasIndex(e => new { e.WwiSupplierId, e.ValidFrom, e.ValidTo })
                    .HasName("IX_Dimension_Supplier_WWISupplierID");

                entity.Property(e => e.SupplierKey)
                    .HasColumnName("Supplier Key")
                    .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[SupplierKey])");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.PaymentDays).HasColumnName("Payment Days");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("Postal Code")
                    .HasMaxLength(10);

                entity.Property(e => e.PrimaryContact)
                    .IsRequired()
                    .HasColumnName("Primary Contact")
                    .HasMaxLength(50);

                entity.Property(e => e.Supplier1)
                    .IsRequired()
                    .HasColumnName("Supplier")
                    .HasMaxLength(100);

                entity.Property(e => e.SupplierReference)
                    .HasColumnName("Supplier Reference")
                    .HasMaxLength(20);

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiSupplierId).HasColumnName("WWI Supplier ID");
            });

            modelBuilder.Entity<SupplierStaging>(entity =>
            {
                entity.HasKey(e => e.SupplierStagingKey)
                    .HasName("PK_Integration_Supplier_Staging")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Supplier_Staging", "Integration");

                entity.HasAnnotation("SqlServer:MemoryOptimized", true);

                entity.Property(e => e.SupplierStagingKey).HasColumnName("Supplier Staging Key");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PaymentDays).HasColumnName("Payment Days");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("Postal Code")
                    .HasMaxLength(10);

                entity.Property(e => e.PrimaryContact)
                    .IsRequired()
                    .HasColumnName("Primary Contact")
                    .HasMaxLength(50);

                entity.Property(e => e.Supplier)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SupplierReference)
                    .HasColumnName("Supplier Reference")
                    .HasMaxLength(20);

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiSupplierId).HasColumnName("WWI Supplier ID");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => new { e.TransactionKey, e.DateKey })
                    .HasName("PK_Fact_Transaction")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Transaction", "Fact");

                entity.HasIndex(e => e.DateKey)
                    .HasName("FK_Fact_Transaction_Date_Key");

                entity.HasIndex(e => new { e.DateKey, e.BillToCustomerKey })
                    .HasName("FK_Fact_Transaction_Bill_To_Customer_Key");

                entity.HasIndex(e => new { e.DateKey, e.CustomerKey })
                    .HasName("FK_Fact_Transaction_Customer_Key");

                entity.HasIndex(e => new { e.DateKey, e.PaymentMethodKey })
                    .HasName("FK_Fact_Transaction_Payment_Method_Key");

                entity.HasIndex(e => new { e.DateKey, e.SupplierKey })
                    .HasName("FK_Fact_Transaction_Supplier_Key");

                entity.HasIndex(e => new { e.DateKey, e.TransactionTypeKey })
                    .HasName("FK_Fact_Transaction_Transaction_Type_Key");

                entity.HasIndex(e => new { e.TransactionKey, e.DateKey, e.CustomerKey, e.BillToCustomerKey, e.SupplierKey, e.TransactionTypeKey, e.PaymentMethodKey, e.WwiCustomerTransactionId, e.WwiSupplierTransactionId, e.WwiInvoiceId, e.WwiPurchaseOrderId, e.SupplierInvoiceNumber, e.TotalExcludingTax, e.TaxAmount, e.TotalIncludingTax, e.OutstandingBalance, e.IsFinalized, e.LineageKey })
                    .HasName("CCX_Fact_Transaction");

                entity.Property(e => e.TransactionKey)
                    .HasColumnName("Transaction Key")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DateKey)
                    .HasColumnName("Date Key")
                    .HasColumnType("date");

                entity.Property(e => e.BillToCustomerKey).HasColumnName("Bill To Customer Key");

                entity.Property(e => e.CustomerKey).HasColumnName("Customer Key");

                entity.Property(e => e.IsFinalized).HasColumnName("Is Finalized");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.OutstandingBalance)
                    .HasColumnName("Outstanding Balance")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentMethodKey).HasColumnName("Payment Method Key");

                entity.Property(e => e.SupplierInvoiceNumber)
                    .HasColumnName("Supplier Invoice Number")
                    .HasMaxLength(20);

                entity.Property(e => e.SupplierKey).HasColumnName("Supplier Key");

                entity.Property(e => e.TaxAmount)
                    .HasColumnName("Tax Amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalExcludingTax)
                    .HasColumnName("Total Excluding Tax")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalIncludingTax)
                    .HasColumnName("Total Including Tax")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransactionTypeKey).HasColumnName("Transaction Type Key");

                entity.Property(e => e.WwiCustomerTransactionId).HasColumnName("WWI Customer Transaction ID");

                entity.Property(e => e.WwiInvoiceId).HasColumnName("WWI Invoice ID");

                entity.Property(e => e.WwiPurchaseOrderId).HasColumnName("WWI Purchase Order ID");

                entity.Property(e => e.WwiSupplierTransactionId).HasColumnName("WWI Supplier Transaction ID");

                entity.HasOne(d => d.BillToCustomerKeyNavigation)
                    .WithMany(p => p.TransactionBillToCustomerKeyNavigation)
                    .HasForeignKey(d => d.BillToCustomerKey)
                    .HasConstraintName("FK_Fact_Transaction_Bill_To_Customer_Key_Dimension_Customer");

                entity.HasOne(d => d.CustomerKeyNavigation)
                    .WithMany(p => p.TransactionCustomerKeyNavigation)
                    .HasForeignKey(d => d.CustomerKey)
                    .HasConstraintName("FK_Fact_Transaction_Customer_Key_Dimension_Customer");

                entity.HasOne(d => d.DateKeyNavigation)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.DateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Transaction_Date_Key_Dimension_Date");

                entity.HasOne(d => d.PaymentMethodKeyNavigation)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.PaymentMethodKey)
                    .HasConstraintName("FK_Fact_Transaction_Payment_Method_Key_Dimension_Payment Method");

                entity.HasOne(d => d.SupplierKeyNavigation)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.SupplierKey)
                    .HasConstraintName("FK_Fact_Transaction_Supplier_Key_Dimension_Supplier");

                entity.HasOne(d => d.TransactionTypeKeyNavigation)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.TransactionTypeKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Transaction_Transaction_Type_Key_Dimension_Transaction Type");
            });

            modelBuilder.Entity<TransactionStaging>(entity =>
            {
                entity.HasKey(e => e.TransactionStagingKey)
                    .HasName("PK_Integration_Transaction_Staging")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Transaction_Staging", "Integration");

                entity.HasAnnotation("SqlServer:MemoryOptimized", true);

                entity.Property(e => e.TransactionStagingKey).HasColumnName("Transaction Staging Key");

                entity.Property(e => e.BillToCustomerKey).HasColumnName("Bill To Customer Key");

                entity.Property(e => e.CustomerKey).HasColumnName("Customer Key");

                entity.Property(e => e.DateKey)
                    .HasColumnName("Date Key")
                    .HasColumnType("date");

                entity.Property(e => e.IsFinalized).HasColumnName("Is Finalized");

                entity.Property(e => e.LastModifiedWhen).HasColumnName("Last Modified When");

                entity.Property(e => e.OutstandingBalance)
                    .HasColumnName("Outstanding Balance")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentMethodKey).HasColumnName("Payment Method Key");

                entity.Property(e => e.SupplierInvoiceNumber)
                    .HasColumnName("Supplier Invoice Number")
                    .HasMaxLength(20);

                entity.Property(e => e.SupplierKey).HasColumnName("Supplier Key");

                entity.Property(e => e.TaxAmount)
                    .HasColumnName("Tax Amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalExcludingTax)
                    .HasColumnName("Total Excluding Tax")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalIncludingTax)
                    .HasColumnName("Total Including Tax")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransactionTypeKey).HasColumnName("Transaction Type Key");

                entity.Property(e => e.WwiBillToCustomerId).HasColumnName("WWI Bill To Customer ID");

                entity.Property(e => e.WwiCustomerId).HasColumnName("WWI Customer ID");

                entity.Property(e => e.WwiCustomerTransactionId).HasColumnName("WWI Customer Transaction ID");

                entity.Property(e => e.WwiInvoiceId).HasColumnName("WWI Invoice ID");

                entity.Property(e => e.WwiPaymentMethodId).HasColumnName("WWI Payment Method ID");

                entity.Property(e => e.WwiPurchaseOrderId).HasColumnName("WWI Purchase Order ID");

                entity.Property(e => e.WwiSupplierId).HasColumnName("WWI Supplier ID");

                entity.Property(e => e.WwiSupplierTransactionId).HasColumnName("WWI Supplier Transaction ID");

                entity.Property(e => e.WwiTransactionTypeId).HasColumnName("WWI Transaction Type ID");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.HasKey(e => e.TransactionTypeKey)
                    .HasName("PK_Dimension_Transaction_Type");

                entity.ToTable("Transaction Type", "Dimension");

                entity.HasIndex(e => new { e.WwiTransactionTypeId, e.ValidFrom, e.ValidTo })
                    .HasName("IX_Dimension_Transaction_Type_WWITransactionTypeID");

                entity.Property(e => e.TransactionTypeKey)
                    .HasColumnName("Transaction Type Key")
                    .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[TransactionTypeKey])");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.TransactionType1)
                    .IsRequired()
                    .HasColumnName("Transaction Type")
                    .HasMaxLength(50);

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiTransactionTypeId).HasColumnName("WWI Transaction Type ID");
            });

            modelBuilder.Entity<TransactionTypeStaging>(entity =>
            {
                entity.HasKey(e => e.TransactionTypeStagingKey)
                    .HasName("PK_Integration_Transaction_Type_Staging")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("TransactionType_Staging", "Integration");

                entity.HasAnnotation("SqlServer:MemoryOptimized", true);

                entity.Property(e => e.TransactionTypeStagingKey).HasColumnName("Transaction Type Staging Key");

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasColumnName("Transaction Type")
                    .HasMaxLength(50);

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiTransactionTypeId).HasColumnName("WWI Transaction Type ID");
            });

            modelBuilder.HasSequence<int>("CityKey");

            modelBuilder.HasSequence<int>("CustomerKey");

            modelBuilder.HasSequence<int>("EmployeeKey");

            modelBuilder.HasSequence<int>("LineageKey");

            modelBuilder.HasSequence<int>("PaymentMethodKey");

            modelBuilder.HasSequence<int>("StockItemKey");

            modelBuilder.HasSequence<int>("SupplierKey");

            modelBuilder.HasSequence<int>("TransactionTypeKey");
        }
    }
}
